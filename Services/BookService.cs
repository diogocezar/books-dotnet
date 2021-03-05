using books_dotnet.Models;
using books_dotnet.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace books_dotnet.Services
{
  public class BookService
  {
    private readonly IMongoCollection<BookModel> BookMongoCollection;
    public BookService(DatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      BookMongoCollection = database.GetCollection<BookModel>(settings.BooksCollectionName);
    }
    public List<BookModel> Get() =>
        BookMongoCollection.Find(book => true).ToList();

    public BookModel Get(string id) =>
        BookMongoCollection.Find<BookModel>(book => book.Id == id).FirstOrDefault();

    public BookModel Create(BookModel book)
    {
      BookMongoCollection.InsertOne(book);
      return book;
    }
    public void Update(string id, BookModel bookIn) =>
        BookMongoCollection.ReplaceOne(book => book.Id == id, bookIn);

    public void Remove(BookModel bookIn) =>
        BookMongoCollection.DeleteOne(book => book.Id == bookIn.Id);

    public void Remove(string id) =>
        BookMongoCollection.DeleteOne(book => book.Id == id);
  }
}