using BookStoreWebAPI.DataAcces.Models;

namespace BookStore.Business.Services.BookService
{
    public class BookService
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

        public async Task<IEnumerable<Book>> GetALLBooksAsync()
        {
            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                // return NotFound($"There is no book for this id : {id}");
            }

            return exsitingBook;
        }

        public async Task<String> AddBookAsync(Book book)
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

            return "Book added Succesfully";
        }

        public async Task<String> EditBookAsync(int id, Book book)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                //return NotFound($"There is no book for this id : {id}");
            }


            exsitingBook.Title = book.Title;
            exsitingBook.Author = book.Author;
            exsitingBook.PublicationDate = book.PublicationDate;



            return "Book Updated Successfully";
        }

        public async Task<String> DeleteBook(int id)
        {
            var exsitingBook = books.FirstOrDefault(b => b.Id == id);

            if (exsitingBook == null)
            {
                // return NotFound($"There is no book for this id : {id}");
            }

            books.Remove(exsitingBook);

            return "Book Deleted Successfully";
        }
    }
}
