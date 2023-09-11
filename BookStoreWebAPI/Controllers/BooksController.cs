using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Title1",
                Author="Author1",
                PublicationDate = 2023,
            },

            new Book
            {
                Id=2,
                Title = "Title2",
                Author="Author2",
                PublicationDate = 2021,
            },

                new Book
            {
                Id=3,
                Title = "Title3",
                Author="Author3",
                PublicationDate = 2022,
            }


        };

        //Get All Books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(books);
        }

        //Get a Book by ID
        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                return NotFound($"There is no book for this id : {id}");
            }

            return Ok(exsitingBook);
        }

        //Add a Book
        [HttpPost]

        public IActionResult AddBook([FromBody] Book book)
        {
            var maxID = books.Max(b => b.Id);
            var newBook = new Book
            {
                Id = maxID + 1,
                Title = book.Title,
                Author = book.Author,
                PublicationDate = book.PublicationDate,
            };

            books.Add(newBook);

            return Ok(newBook);
        }

        //Update a Book
        [HttpPut("{id:int}")]
        public IActionResult EditBook(int id, [FromBody] Book book)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                return NotFound($"There is no book for this id : {id}");
            }


            exsitingBook.Title = book.Title;
            exsitingBook.Author = book.Author;
            exsitingBook.PublicationDate = book.PublicationDate;



            return Ok(exsitingBook);

        }

        //Delete a Book
        [HttpDelete("{id:int}")]

        public IActionResult DeleteBook(int id)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                return NotFound($"There is no book for this id : {id}");
            }

            books.Remove(exsitingBook);

            return Ok(exsitingBook);
        }


    }
}
