using AspNet_MVC.Services;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

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
    }
}
