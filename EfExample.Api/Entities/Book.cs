namespace EfExample.Api.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int UserId { get; set; }
    //public virtual User User { get; set; } = null!;
}
