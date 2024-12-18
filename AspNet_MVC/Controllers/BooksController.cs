using AspNet_MVC.Services;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using AspNet_MVC.Tables;

namespace AspNet_MVC.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BooksController : Controller
    {
        public BookService _BookServices = new();

        //public BooksController() { }


        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var authors = _BookServices.GetAllBooks();

            return Ok(
                JsonSerializer.Serialize(authors, new JsonSerializerOptions { WriteIndented = true })
            );
            //return StatusCode(200, authors)
        }

        [HttpGet("{id}")]
        public ActionResult<Book?> GetBookByID(string id)
        {
            //If ID isn't parsable into ID type, then err in query
            //If book is not found, id doesnt exist else return book found!

            try
            {
                var b = _BookServices.GetById(id);

                return (b == null) ? NotFound("Book of given ID is not found!") : Ok(JsonSerializer.Serialize(b, new JsonSerializerOptions { WriteIndented = true }));

            }
            catch (Exception ex)
            {
                return BadRequest("param is NaN! (not a number)");
            }
        }
    }
}
