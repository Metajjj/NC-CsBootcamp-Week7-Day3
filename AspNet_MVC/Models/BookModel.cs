using System.Text.Json;

using AspNet_MVC.Tables;

using static System.Reflection.Metadata.BlobBuilder;

namespace AspNet_MVC.Models
{
    public class BookModel
    {
        public static List<Book> GetAllBooks()
        {
            return JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(@"Resources/Books.json"));
        }

        public static Book GetBookById(int id)
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

        public static Book DelBookById(int id)
        {
            var books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(@"Resources/Books.json"));

            var newBooks = books.Where(b => b.Id != id).ToList();

            File.WriteAllText(@"Resources/Books.json", JsonSerializer.Serialize(newBooks, new JsonSerializerOptions { WriteIndented = true }));

            return newBooks.Count() != books.Count() ? books.First(b => b.Id == id) : null;
        }
    }
}
