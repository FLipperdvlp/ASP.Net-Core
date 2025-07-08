using Library.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("/authors")]
public class AuthorController(LibraryDbContext dbContext) : ControllerBase
{
    public IActionResult GetAllAuthors()
    {
        return Ok(dbContext.Authors.ToList());
    }
}
