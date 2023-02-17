using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController: BaseApiController
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM book)
        {
            var updated = _booksService.UpdateBookById(id, book);
            return Ok(updated);
        }
        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var result = _booksService.DeleteBookById(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}