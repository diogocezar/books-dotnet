using books_dotnet.Models;
using books_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace books_dotnet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly BookService BookService;
    public BooksController(BookService bookService)
    {
      BookService = bookService;
    }
    [HttpGet]
    public ActionResult<List<BookModel>> Get() => BookService.Get();
    [HttpGet("{id:length(24)}", Name = "GetBook")]
    public ActionResult<BookModel> Get(string id)
    {
      var book = BookService.Get(id);
      if (book == null)
      {
        return NotFound();
      }
      return book;
    }
    [HttpPost]
    public ActionResult<BookModel> Create(BookModel book)
    {
      BookService.Create(book);
      return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, BookModel bookIn)
    {
      var book = BookService.Get(id);
      if (book == null)
      {
        return NotFound();
      }
      BookService.Update(id, bookIn);
      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var book = BookService.Get(id);

      if (book == null)
      {
        return NotFound();
      }

      BookService.Remove(book.Id);

      return NoContent();
    }
  }
}