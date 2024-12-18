using System.Text.Json;
using AspNet_MVC.Models;
using AspNet_MVC.Tables;

namespace AspNet_MVC.Services
{
    public class AuthorServices
    {
        public List<Author> GetAllAuthors()
        {
            return AuthorModel.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return AuthorModel.GetAuthorByID(id);
        }

        public bool AddAuthor(Author authorjson)
        {
            return AuthorModel.AddAuthor(authorjson);
        }
    }
}
