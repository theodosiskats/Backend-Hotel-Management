using Backend_Hotel_Management.Models;
using MongoDB.Driver;

namespace Backend_Hotel_Management.Properties.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoDB");
        var connectionString = mongoSettings["ConnectionString"];
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(mongoSettings["DatabaseName"]);
    }

    public IMongoCollection<Product> Products =>
        _db.GetCollection<Product>("Products");
    
    public IMongoCollection<Availability> Availabilities =>
        _db.GetCollection<Availability>("Availabilities");
}