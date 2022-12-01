using EfExample.Api.Context;
using EfExample.Api.Entities;
using EfExample.Api.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            

            return Ok(_context.Books);
        }

        [HttpPost] 
        public IActionResult AddBook(BookDto model)
        {
            var book = new Book
            {
                Title = model.Title,
                UserId = model.UserId,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }
    }
}
