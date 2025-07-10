using Library.DataBase;
using Microsoft.AspNetCore.Mvc;
namespace Library.Controllers;

[ApiController]
[Route("/books")]
public class BookController(LibraryDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        return Ok(dbContext.Books.ToList());
    }
}