using System.Text.Json;
using AspNet_MVC.Models;
using AspNet_MVC.Services;
using AspNet_MVC.Tables;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
    [Route("/[controller]")] //Where the controller starts from
    [ApiController]
    public class AuthorController : Controller
    {
        private AuthorServices _AuthorServices = new();
        //public AuthorController(AuthorServices As) //Retreive from constructor to get service
        //{ _AuthorServices = As; }

            //Mapping => Map.Get("")
        //[HttpGet][Route("")]

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _AuthorServices.GetAllAuthors();

            return Ok(
                JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true })
            );
            //return StatusCode(200, authors)
        }

        [HttpGet("{id}")]    //route id requests
        public ActionResult<Author> GetAuthorById(int id)
        {
            var author = _AuthorServices.GetAuthorById(id);

            return Ok(
                JsonSerializer.Serialize(author, new JsonSerializerOptions { WriteIndented = true })
            );
        }


        [HttpPost]
        public IActionResult PostAuthor(string author)
        {
            bool success = AuthorModel.AddAuthor(author);
            if (success) return Created();
            return BadRequest();

        }
    }
}
