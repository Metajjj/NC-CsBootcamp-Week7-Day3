using AspNet_MVC.Tables;
using System.Text.Json;

namespace AspNet_MVC.Models
{
    public class AuthorModel
    {
        public static List<Author> GetAllAuthors()
        {
            return JsonSerializer.Deserialize<List<Author>>(File.ReadAllText(@"Resources/Authors.json"));
        }

        public static Author GetAuthorByID(int id)
        {
            return JsonSerializer.Deserialize<List<Author>>(File.ReadAllText(@"Resources/Authors.json")).Where(a => a.Id == id).First();
        }

        public static bool AddAuthor(Author newAuthor)
        {
            try
            {
                List<Author> authors = GetAllAuthors();
                //var newAuthor = JsonSerializer.Deserialize<Author>(author);
                newAuthor.Id = authors.Last().Id + 1;       //changed to always increment >> every insertion has a unique id
                authors.Add(newAuthor);
                File.WriteAllText(@"Resources/Authors.json", JsonSerializer.Serialize(authors,new JsonSerializerOptions { WriteIndented = true}));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteAuthorByID(int id)
        {
            List<Author> authors = GetAllAuthors();
            var newAuthors = authors.Where(a => a.Id != id).ToList();
            File.WriteAllText(@"Resources/Authors.json", JsonSerializer.Serialize(newAuthors, new JsonSerializerOptions { WriteIndented = true }));
            return true;
        }

    }
}
