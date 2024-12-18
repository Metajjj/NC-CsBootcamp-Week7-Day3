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
                newAuthor.Id = authors.Count() + 1;
                authors.Add(newAuthor);
                File.WriteAllText(@"Resources/Authors.json", JsonSerializer.Serialize(authors,new JsonSerializerOptions { WriteIndented = true}));
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
