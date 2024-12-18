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
    }
}
