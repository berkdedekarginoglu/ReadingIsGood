using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly ICategoryService _categorySerivce;
        public CategoryController(ICategoryService categoryService)
        {
            _categorySerivce = categoryService;
            
        }

        [HttpPost("add")]

        public IActionResult AddCategory(AddCategoryDto addCategoryDto)
        {
            var result = _categorySerivce.Add(addCategoryDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categorySerivce.GetAllCategories();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        
    }
}
