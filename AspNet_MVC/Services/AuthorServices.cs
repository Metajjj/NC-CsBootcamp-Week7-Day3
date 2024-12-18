using System.Text.Json;
using AspNet_MVC.Tables;

namespace AspNet_MVC.Services
{
    public class AuthorServices
    {
        public List<Author> GetAllAuthors()
        {
            return JsonSerializer.Deserialize<List<Author>>(File.ReadAllText(@"Resources/Authors.json"));
        }
    }
}
