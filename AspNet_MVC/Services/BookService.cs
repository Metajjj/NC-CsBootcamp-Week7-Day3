using AspNet_MVC.Models;
using AspNet_MVC.Tables;

namespace AspNet_MVC.Services
{
    public class BookService
    {
        public List<Book> GetAllBooks()
        {
            return BookModel.GetAllBooks();
        }

        public Book GetById(string id)
        {
            return BookModel.GetBookById(int.Parse(id));
        }

        public Book AddBook(Book book)
        {
            return BookModel.AddBook(book);
        }

        public Book DelById(string id)
        {
            return BookModel.DelBookById(int.Parse(id));
        }
    }
}
