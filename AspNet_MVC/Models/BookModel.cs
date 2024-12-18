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

        public static Book AddBook(Book book)
        {
            var Auths = AuthorModel.GetAllAuthors();
            //var newAuthor = JsonSerializer.Deserialize<Author>(author);

                    //If book has valid auth name or ID
            if ( Auths.Any(a => a.Name.ToLower() == book.Author.ToLower() ) )
            {
                var Books = BookModel.GetAllBooks();
                    //Add to books list
                book.Id = Books.Count() + 1;

                Books.Add(book);

                File.WriteAllText(@"Resources/Books.json", JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true }));

                return book;
            }

            return null;            
        }
    }
}
