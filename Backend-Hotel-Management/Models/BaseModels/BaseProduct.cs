using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_Hotel_Management.Models.BaseModels;

//Adds base properties that all products share
public abstract class BaseProduct
{
    //Auto set by MondoDB
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    //Auto set on model creation
    [BsonElement("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}