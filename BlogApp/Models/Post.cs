using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


public class Post
{
    [BsonId]  // MongoDB'deki benzersiz kimlik (ObjectId)
    [BsonRepresentation(BsonType.ObjectId)]  // ObjectId olarak temsil edilir
    public string? Id { get; set; } // id bilgisini mongodb oluşturacak

    [BsonElement("title")]
    [Required(ErrorMessage = "Title is required")] 
    public required string Title { get; set; }

    [BsonElement("content")]
    [Required(ErrorMessage = "Content is required")]  
    public required string Content { get; set; }

    [BsonElement("createdAt")] 
    public DateTime CreatedAt { get; set; }
}
