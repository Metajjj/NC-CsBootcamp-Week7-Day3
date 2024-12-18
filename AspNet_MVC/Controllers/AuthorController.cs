using System.Text.Json;
using AspNet_MVC.Models;
using AspNet_MVC.Services;
using AspNet_MVC.Tables;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
    [Route("/[controller]")] //Where the controller starts from
        //Case-insensitive
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

            var htpc = HttpContext;
            htpc.Response.StatusCode = StatusCodes.Status200OK;
            htpc.Response.Body.WriteAsync(
                JsonSerializer.Serialize(author, new JsonSerializerOptions { WriteIndented = true })
                .Select(c => Convert.ToByte(c))
                .ToArray()
            );
        }


        [HttpPost] //Auto Deserialised JSON string into the class type
        public IActionResult PostAuthor(Author author)
        {

            var htpc = HttpContext;

            //htpc.Request.Body //TODO figure out? then can handle any body input!

            bool success = _AuthorServices.AddAuthor(author);
            if (success)
            {
                htpc.Response.StatusCode = StatusCodes.Status201Created;
                htpc.Response.Body.WriteAsync(
                    JsonSerializer.Serialize(author, new JsonSerializerOptions { WriteIndented = true })
                    .Select(c=>Convert.ToByte(c))
                    .ToArray()                    
                );
                return Created(); //Return only affects GET requests? sends to client to view
            }
            return BadRequest();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            //TODO del

            return null;
        }
    }
}
