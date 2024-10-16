using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PostRepository
{
    private readonly IMongoCollection<Post> _posts;

    public PostRepository(MongoDBContext context)
    {
        _posts = context.Posts;
    }

    // Tüm blog gönderilerini almak için
    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _posts.Find(post => true).ToListAsync();
    }

    // Belirli bir blog gönderisini ID ile almak için
    public async Task<Post> GetPostByIdAsync(string id)
    {
        return await _posts.Find<Post>(post => post.Id == id).FirstOrDefaultAsync();
    }

    // Yeni bir blog gönderisi eklemek için
public async Task AddPostAsync(Post post)
{
    try
    {
        Console.WriteLine("Inserting Post...");
        await _posts.InsertOneAsync(post);
        Console.WriteLine("Post inserted successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inserting post: {ex.Message}");
        throw;
    }
}


    // Belirli bir blog gönderisini güncellemek için
    public async Task UpdatePostAsync(string id, Post post)
    {
        await _posts.ReplaceOneAsync(p => p.Id == id, post);
    }

    // Belirli bir blog gönderisini silmek için
    public async Task DeletePostAsync(string id)
    {
        await _posts.DeleteOneAsync(post => post.Id == id);
    }
}
