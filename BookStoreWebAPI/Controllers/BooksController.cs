using BookStore.Business.Services.BookService;
using BookStoreWebAPI.DataAcces.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }



        //Get All Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var response = await _bookService.GetALLBooksAsync();
            return Ok(response);
        }

        //Get a Book by ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookService.GetBookByIdAsync(id);
            return Ok(response);
        }

        //Add a Book
        [HttpPost]

        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var response = await _bookService.AddBookAsync(book);
            return Ok(response);
        }

        //Update a Book
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditBook(int id, [FromBody] Book book)
        {

            var response = await _bookService.EditBookAsync(id, book);
            return Ok(response);
        }

        //Delete a Book
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);
            return Ok(response);
        }


    }
}
