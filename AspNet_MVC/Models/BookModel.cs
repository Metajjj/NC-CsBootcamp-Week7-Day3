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

        public static Book GetBook(int id)
        {
            return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(@"Resources/Books.json"))
                .Where(b=>b.Id == id)
                .Concat([null]) //Optional default NULL if book isn't found with given ID
                .First();
        }
    }
}
