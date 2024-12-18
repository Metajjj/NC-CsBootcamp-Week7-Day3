using System.Text.Json;

using AspNet_MVC.Services;

using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC.Controllers
{
    [Route("/")] //Where the controller starts from
    [ApiController]
    public class AuthorController : Controller
    {
        private AuthorServices _AuthorServices;
        public AuthorController(AuthorServices As) //Retreive from constructor to get service
        { _AuthorServices = As; }

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
    }
}
