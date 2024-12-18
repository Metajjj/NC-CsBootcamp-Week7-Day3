using System.Text.Json;

using AspNet_MVC.Tables;

namespace AspNet_MVC.Models
{
    public class BookModel
    {
        public static List<Book> GetAllBooks()
        {
            return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(@"Resources/Books.json"));
        }
    }
}
