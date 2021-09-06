using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.Mapper2.Autofac;
using ReadingIsGood.Business.ValidationRules.FluentValidation;
using ReadingIsGood.Core.Aspects.Autofac.Validation;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Add(AddAuthorDto author)
        {
            var createdAuthor = new Author
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            _authorDal.Add(createdAuthor);
            return new SuccessResult(Messages.AuthorAdded);
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public IResult Update(UpdateAuthorDto updateAuthorDto)
        {
            var selectedAuthor = _authorDal.Get(x => x.Id == updateAuthorDto.Id);
            if (selectedAuthor == null)
                return new ErrorResult(Messages.AuthorNotFound);

            selectedAuthor.FirstName = updateAuthorDto.ModifiedFirstName;
            selectedAuthor.LastName = updateAuthorDto.ModifiedLastName;
            selectedAuthor.UpdatedAt = DateTime.Now;


            _authorDal.Update(selectedAuthor);

            return new SuccessResult(Messages.AuthorUpdated);
        }
        public IResult DeleteById(string id)
        {
            var selectedAuthor = _authorDal.Get(x => x.Id == id);
            if (selectedAuthor == null)
                return new ErrorResult(Messages.AuthorNotFound);

            selectedAuthor.IsActive = false;
            _authorDal.Update(selectedAuthor);
            return new SuccessResult(Messages.AuthorDeleted);
        }
        public IDataResult<ICollection<GetAuthorDto>> GetAll(int currentPage, int dataPerPage)
        {
            var rulesCheck = BusinessRules.Run(CheckDataPerPage(dataPerPage),CheckCurrentPage(currentPage));
            if (!rulesCheck.Success)
                return new ErrorDataResult<ICollection<GetAuthorDto>>(rulesCheck.Message);

            var selectedAuthors = _authorDal.GetAll(currentPage, dataPerPage);
            if (selectedAuthors == null)
                return new ErrorDataResult<ICollection<GetAuthorDto>>(Messages.AuthorNotFound);

            return new SuccessDataResult<ICollection<GetAuthorDto>>(
                ObjectMapper.Mapper.Map<ICollection<GetAuthorDto>>(selectedAuthors));
                
        }
        public IDataResult<GetAuthorDto> GetById(string id)
        {
            var selectedAuthor =  _authorDal.Get(x => x.Id == id);
            if (selectedAuthor == null)
                return new ErrorDataResult<GetAuthorDto>(Messages.AuthorNotFound);
            return new SuccessDataResult<GetAuthorDto>(ObjectMapper.Mapper.Map<GetAuthorDto>(selectedAuthor));
        }
        private IResult CheckDataPerPage(int dataPerPage)
        {
            return dataPerPage <= 25 ? new SuccessResult() : new ErrorResult(Messages.GetDataPerPageLimitExceeded);
        }
        private IResult CheckCurrentPage(int currentPage)
        {
            return currentPage > 0 ? new SuccessResult() : new ErrorResult(Messages.GetDataCurrentPageMustBeGreaterThenZero);
        }
    }
}
