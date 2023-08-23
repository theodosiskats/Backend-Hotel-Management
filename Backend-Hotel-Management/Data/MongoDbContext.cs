using Backend_Hotel_Management.Models;
using MongoDB.Driver;

namespace Backend_Hotel_Management.Properties.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    //Setup Mongo Database Connection
    public MongoDbContext(IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoDB");
        var connectionString = mongoSettings["ConnectionString"];
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(mongoSettings["DatabaseName"]);
    }

    //Gets Product Collection from Database
    public IMongoCollection<Product> Products =>
        _db.GetCollection<Product>("Products");
    
    //Gets Availabilities Collection from Database
    public IMongoCollection<Availability> Availabilities =>
        _db.GetCollection<Availability>("Availabilities");
}