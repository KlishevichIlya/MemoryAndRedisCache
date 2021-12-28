using CacheEducation.Data;
using CacheEducation.Models;
using CacheEducation.Services.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetRecordByIdAsync(id);
            if (author == null)
                return BadRequest(new { message = "Wrong user's id" });
            var test = author.Country;
            return Ok(author);            
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAsync();
            if (!authors.Any())
                return BadRequest(new { message = "DB is empty" });
            return Ok(authors);
        }

        [HttpPost("add")]
        public async Task AddAuthor([FromBody]Author entity)
        {
            await _authorService.AddAsync(entity);
        }

        [HttpGet("youngest")]
        public async Task<IActionResult> GetTheYoungestAuthor()
        {
            var youngestAuthor = await _authorService.GetTheYoungestAsync();
            return Ok(youngestAuthor);
        }
       
    }
}
