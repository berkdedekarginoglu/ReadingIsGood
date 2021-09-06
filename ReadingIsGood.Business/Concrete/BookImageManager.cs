using Microsoft.AspNetCore.Http;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        private readonly IBookImageDal _bookImageDal;
        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }
        public  IResult Add(AddBookImageDto addBookImageDto)
        {
            var createdBookImage = new BookImage
            {
                Id = Guid.NewGuid().ToString(),
                BookId = addBookImageDto.BookId,
                ImagePath = addBookImageDto.ImagePath,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            };

           _bookImageDal.Add(createdBookImage);
            return new SuccessResult("Book image added");
        }

        
    }
}
