using Experimental.TodoApiMongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Experimental.TodoApiMongoDB.Services
{
  public class TodoService
  {
    private readonly IMongoCollection<TodoListItem> _todos;

    public TodoService(ITodoDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _todos = database.GetCollection<TodoListItem>(settings.CollectionName);
    }

    public List<TodoListItem> Get() =>
        _todos.Find(todo => true).ToList();

    public TodoListItem Get(string id) =>
        _todos.Find(todo => todo.Id == id).FirstOrDefault();

    public TodoListItem Create(TodoListItem book)
    {
      _todos.InsertOne(book);
      return book;
    }

    public void Update(string id, TodoListItem bookIn) =>
        _todos.ReplaceOne(book => book.Id == id, bookIn);

    public void Remove(TodoListItem bookIn) =>
        _todos.DeleteOne(book => book.Id == bookIn.Id);

    public void Remove(string id) =>
        _todos.DeleteOne(book => book.Id == id);
  }
}
