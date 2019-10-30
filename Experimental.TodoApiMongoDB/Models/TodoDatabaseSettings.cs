namespace Experimental.TodoApiMongoDB.Models
{
  public class TodoDatabaseSettings : ITodoDatabaseSettings
  {
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface ITodoDatabaseSettings
  {
    string CollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}
