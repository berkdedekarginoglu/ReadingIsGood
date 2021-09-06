using AutoMapper;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Adapters.ISBNService;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.Mapper2.Autofac;
using ReadingIsGood.Business.ValidationRules.FluentValidation;
using ReadingIsGood.Core.Aspects.Autofac.Authorization;
using ReadingIsGood.Core.Aspects.Autofac.Validation;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadingIsGood.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookCategoryService _bookCategoryService;
        private readonly IBookDal _bookDal;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IISBNService _isbnService;
        public BookManager(IBookDal bookDal,IAuthorService authorService,
            ICategoryService categoryService,IBookCategoryService bookCategoryService,IISBNService isbnService)
        {
            _bookCategoryService = bookCategoryService;
            _categoryService = categoryService;
            _authorService = authorService;
            _bookDal = bookDal;
            _isbnService = isbnService;
        }
        

        [ValidationAspect(typeof(BookValidator),Priority =1)]
     
        public IResult Add(AddBookDto addBookDto)
        {
            var checkRules = BusinessRules.Run(_categoryService.CheckCategories(addBookDto.CategoryIds.ToArray()),
                _isbnService.VerifyISBN(addBookDto.ISBN), _authorService.GetById(addBookDto.AuthorId),CheckYearOfPublic(addBookDto.YearOfPublication));

            if (!checkRules.Success)
                return new ErrorResult(checkRules.Message);
            
            var id = Guid.NewGuid().ToString();
            var createdBook = ObjectMapper.Mapper.Map<Book>(addBookDto);
            createdBook.Id = id;

             _bookDal.Add(createdBook);

            var addBookCategoryDto = new AddBookCategoryDto { BookId = id, CategoryIds = addBookDto.CategoryIds };
            var bookCategory = _bookCategoryService.Add(addBookCategoryDto);

            if (!bookCategory.Success)
                return new ErrorResult(bookCategory.Message);

            return new SuccessResult(Messages.BookAdded);
        }

        [ValidationAspect(typeof(BookValidator), Priority = 1)]
        public IResult Update(UpdateBookDto updateBookDto)
        {
            var checkRules = BusinessRules.Run(_categoryService.CheckCategories(updateBookDto.CategoryIds.ToArray()),
              _isbnService.VerifyISBN(updateBookDto.ISBN), _authorService.GetById(updateBookDto.AuthorId), CheckYearOfPublic(updateBookDto.YearOfPublication));

            if (!checkRules.Success)
                return new ErrorResult(checkRules.Message);

            var selectedBook = _bookDal.Get(x => x.ISBN == updateBookDto.ISBN);
            if (selectedBook == null)
                return new ErrorResult(Messages.BookNotFound);

            var newBook = ObjectMapper.Mapper.Map(updateBookDto, selectedBook);
            newBook.UpdatedAt = DateTime.Now;

            _bookDal.Update(newBook);
            return new SuccessResult(Messages.BookUpdated);
        }

        public IResult DeleteById(string id)
        {
            var selectedBook = _bookDal.Get(x => x.Id == id);
            if (selectedBook == null)
                return new ErrorResult(Messages.BookNotFound);

            selectedBook.IsActive = false;
            _bookDal.Update(selectedBook);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<ICollection<GetBookDto>> GetBooksByCategoryId(string categoryId,int currentPage=1,int dataPerPage=10)
        {
            var checkRules = BusinessRules.Run(CheckCurrentPage(currentPage), CheckDataPerPage(dataPerPage),
                _categoryService.CheckCategories(new string[] { categoryId }));

            if (!checkRules.Success)
                return new ErrorDataResult<ICollection<GetBookDto>>(checkRules.Message);

            var books = _bookDal.GetBooksByCategoryId(categoryId,currentPage,dataPerPage);
            
            return new SuccessDataResult<ICollection<GetBookDto>>(ObjectMapper.Mapper.Map<ICollection<GetBookDto>>(books));
        }

        public IDataResult<ICollection<GetBookDto>> GetBooksByAuthorId(string authorId, int currentPage = 1, int dataPerPage = 10)
        {
            var checkRules = BusinessRules.Run(CheckCurrentPage(currentPage), CheckDataPerPage(dataPerPage),
                _authorService.GetById(authorId));

            if (!checkRules.Success)
                return new ErrorDataResult<ICollection<GetBookDto>>(checkRules.Message);

            var selectedBooks =  _bookDal.GetBooksByAuthorId(authorId,currentPage,dataPerPage);
           
            return new SuccessDataResult<ICollection<GetBookDto>>(ObjectMapper.Mapper.Map<ICollection<GetBookDto>>(selectedBooks));
        }

        public IDataResult<GetBookDto> GetById(string bookId)
        {
            var selectedBook = _bookDal.Get(x => x.Id == bookId);
            if (selectedBook == null)
                return new ErrorDataResult<GetBookDto>();
            return new SuccessDataResult<GetBookDto>(ObjectMapper.Mapper.Map<GetBookDto>(selectedBook));
        }


        [SecuredOperation("Admin,Moderator,Get.RecorderStocks")]
        public IDataResult<IEnumerable<Book>> GetOnRecorderLevels(int nearRecorder,int currentPage)
        {
            var selectedBooks = _bookDal.GetAll(
                x => x.ReorderLevel == x.UnitsInStock ||
                x.ReorderLevel + nearRecorder == x.UnitsInStock ||
                x.ReorderLevel == x.UnitsInStock + nearRecorder)
                .Skip(((currentPage - 1) * 25)).Take(25);

            return new SuccessDataResult<IEnumerable<Book>>(selectedBooks);
        }

        private IResult CheckYearOfPublic(int yearOfPublic)
        {
            return (yearOfPublic <= 2300 && yearOfPublic >= 1200) ? new SuccessResult() : new ErrorResult(Messages.BooksYearOfPublicNotValid);
        }
        private IResult CheckDataPerPage(int dataPerPage)
        {
            return dataPerPage <= 10 ? new SuccessResult() : new ErrorResult(Messages.GetDataPerPageLimitExceeded);
        }
        private IResult CheckCurrentPage(int currentPage)
        {
            return currentPage > 0 ? new SuccessResult() : new ErrorResult(Messages.GetDataCurrentPageMustBeGreaterThenZero);
        }

    }
}
