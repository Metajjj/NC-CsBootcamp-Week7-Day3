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


        [HttpPost()]
        public IActionResult AddBook(Book book)
        {
            var result = _BookServices.AddBook(book);

            var htpc = HttpContext;

            if (result != null)
            {
                htpc.Response.StatusCode = StatusCodes.Status201Created;
                htpc.Response.Body.WriteAsync(
                    JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true })
                    .Select(c => Convert.ToByte(c))
                    .ToArray()
                );
            }
            else
            {
                htpc.Response.StatusCode = StatusCodes.Status400BadRequest;
                htpc.Response.Body.WriteAsync(
                    "Provided author name doesn't exist"
                    .Select(c => Convert.ToByte(c))
                    .ToArray()
                );
            }


            return htpc.Response.StatusCode == StatusCodes.Status201Created ? Created() : BadRequest();
            //return result != null ? Created() : BadRequest("Provided author name / id doesn't exist");

        }


        [HttpDelete]
        public IActionResult DelBook(string id)
        {
            try
            {
                var b = _BookServices.DelById(id);

                return (b == null) ? NotFound("Book of given ID is not found!\n Cannot be deleted") : NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest("param is NaN! (not a number)");
            }
        }
    }
}
