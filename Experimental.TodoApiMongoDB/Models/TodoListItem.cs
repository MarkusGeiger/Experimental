using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Experimental.TodoApiMongoDB.Models
{
  public class TodoListItem
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("Name")]
    public string TodoListItemName { get; set; }
    public bool IsComplete { get; set; }
  }
}
