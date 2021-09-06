using AutoMapper;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Mapper2.Autofac;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private readonly ICategoryDal _categoryDal;
        
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult CheckCategories(string[] categoryIds)
        {
            foreach (var id in categoryIds)
                if (_categoryDal.Get(y => y.Id == id) == null)
                    return new ErrorResult("Category not found");
            return new SuccessResult();
        }

        public IResult Add(AddCategoryDto addCategoryDto)
        {
            var createdCategory = new Category
            {
                Id = Guid.NewGuid().ToString(),
                ParentId = addCategoryDto.ParentId,
                Name = addCategoryDto.Name
            };

            _categoryDal.Add(createdCategory);
            return new SuccessResult("Category added");
        }


        public IDataResult<ICollection<GetCategoryDto>> GetAllCategories()
        {
            var categories = _categoryDal.GetAll();
            if (categories == null)
                return new ErrorDataResult<ICollection<GetCategoryDto>>();
            return new SuccessDataResult<ICollection<GetCategoryDto>>(ObjectMapper.Mapper.Map<ICollection<GetCategoryDto>>(categories));
        }

        
    }
}
