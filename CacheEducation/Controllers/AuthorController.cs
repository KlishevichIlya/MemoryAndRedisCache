using CacheEducation.Data;
using CacheEducation.Services.Author;
using Microsoft.AspNetCore.Mvc;

namespace CacheEducation.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ApplicationContext _context;

        public AuthorController(IAuthorService authorService, ApplicationContext context)
        {
            _authorService = authorService;
            _context = context;
            _authorService.Initialize();
        }


        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            
            //var test = _context.Author.FirstOrDefault();
            return Ok("OK");
        }
       
    }
}
