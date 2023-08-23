using Backend_Hotel_Management.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_Hotel_Management.Models;

public class Availability: IAvailability
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("ProductCategory")]
    public string ProductCategory { get; set; }
    
    [BsonElement("StartDate")]
    public DateTime StartDate { get; set; }
    
    [BsonElement("EndDate")]
    public DateTime EndDate { get; set; }
    
    [BsonElement("ProductId")]
    public string ProductId { get; set; }
}