using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EfExample.Api.Entities;

namespace EfExample.Api.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{ 
	}
	
	/*
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=WIN-7NSESGFDVVC\\SQLEXPRESS;Database=User;Trusted_Connection=True;TrustServerCertificate=True");	
	}
	*/

	public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}
