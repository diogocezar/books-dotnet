namespace books_dotnet.Settings
{
  public class DatabaseSettings : IDatabaseSettings
  {
    public string BooksCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }
  public interface IDatabaseSettings
  {
    string BooksCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}