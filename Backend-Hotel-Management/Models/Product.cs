using Backend_Hotel_Management.Models.BaseModels;
using Backend_Hotel_Management.Models.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend_Hotel_Management.Models;

public class Product: BaseProduct, IProduct
{
    [BsonElement("CategoryName")]
    public string CategoryName { get; set; }
    
    [BsonElement("Capacity")]
    public int Capacity { get; set; }

    [BsonElement("PricePerNight")]
    public decimal PricePerNight { get; set; }
}