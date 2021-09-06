using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpPost("add")]
        public IActionResult Add(AddBookDto addBookDto)
        {
            var result = _bookService.Add(addBookDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpPut("update")]
        public IActionResult Update(UpdateBookDto updateBookDto)
        {
            var result = _bookService.Update(updateBookDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(string id)
        {
            var result =  _bookService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycategory/{categoryId}/{currentPage}")]
        public IActionResult GetBooksByCategoryId(string categoryId, int currentPage)
        {
            var result = _bookService.GetBooksByCategoryId(categoryId, currentPage, 10); //Default
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycategory/{categoryId}/{currentPage}/{dataPerPage}")]
        public IActionResult GetBooksByCategoryId(string categoryId, int currentPage, int dataPerPage)
        {
            var result = _bookService.GetBooksByCategoryId(categoryId, currentPage, dataPerPage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyauthor/{authorId}/{currentPage}")]
        public IActionResult GetBooksByAuthorId(string authorId, int currentPage)
        {
            var result = _bookService.GetBooksByAuthorId(authorId, currentPage, 10); //Default
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyauthor/{authorId}/{currentPage}/{dataPerPage}")]
        public IActionResult GetBooksByAuthorId(string authorId, int currentPage, int dataPerPage)
        {
            var result = _bookService.GetBooksByAuthorId(authorId, currentPage, dataPerPage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getrecorderlevels/{nearRecorder}/{currentPage}")]

        public IActionResult GetRecorderLeves(int nearRecorder,int currentPage)
        {
            var result = _bookService.GetOnRecorderLevels(nearRecorder, currentPage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
