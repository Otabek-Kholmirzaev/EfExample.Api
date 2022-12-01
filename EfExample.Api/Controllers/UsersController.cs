using EfExample.Api.Context;
using EfExample.Api.Entities;
using EfExample.Api.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfExample.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly AppDbContext _context;

	public UsersController(AppDbContext context)
	{
		_context = context;
    }

	[HttpGet]
	public IActionResult GetUsers()
	{
		return Ok(_context.Users.Include(u => u.Book).ToList());
	}

    [HttpPost]
    public IActionResult AddUser([FromBody] UserDto model)
    {
        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserDto model)
    {

        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null) 
        {
            return BadRequest();
        }

        user.Name= model.Name;
        user.Email= model.Email;

        _context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser([FromRoute] int id)
    {

        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            return BadRequest();
        }

        _context.Users.Remove(user);

        _context.SaveChanges();

        return Ok();
    }
}
