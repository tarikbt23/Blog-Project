using MongoDB.Driver;
using Microsoft.Extensions.Options;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IOptions<MongoDBSettings> settings, IMongoClient client)
    {
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
}
