using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public AuthorController(IAuthorService authorService,IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpPost("add")]
        public IActionResult AddAuthor(AddAuthorDto addAuthorDto)
        {
            var result = _authorService.Add(addAuthorDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(UpdateAuthorDto updateAuthorDto)
        {
            var result = _authorService.Update(updateAuthorDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{authorId}")]
        public IActionResult DeleteById(string authorId)
        {
            var result = _authorService.DeleteById(authorId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(string id)
        {
            var result = _authorService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("all/{startPageIndex}/{dataCountPerPage}")]
        public IActionResult GetAllAuthors(int startPageIndex,int dataCountPerPage)
        {
            var result = _authorService.GetAll(startPageIndex,dataCountPerPage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("all/{startPageIndex}")]
        public IActionResult GetAllAuthors(int startPageIndex)
        {
            var result = _authorService.GetAll(startPageIndex,25); // Default
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{authorId}/books")]
        public IActionResult GetAllBooks(string authorId)
        {
            var result = _bookService.GetBooksByAuthorId(authorId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
