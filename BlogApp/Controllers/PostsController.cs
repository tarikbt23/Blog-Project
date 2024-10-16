using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class PostsController : Controller
{
    private readonly PostRepository _postRepository;

    public PostsController(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    // Tüm blog gönderilerini listeleyen aksiyon
    public async Task<IActionResult> Index()
    {
        var posts = await _postRepository.GetAllPostsAsync();
        return View(posts);  // View'a blog gönderilerini gönderiyoruz
    }

    // Yeni bir blog gönderisi oluşturma sayfası
    public IActionResult Create()
    {
        return View();
    }

    // Yeni bir blog gönderisi ekleme işlemi
    [HttpPost]
    public async Task<IActionResult> Create(Post post)
    {
        if (ModelState.IsValid)
        {
            post.CreatedAt = DateTime.Now;
            await _postRepository.AddPostAsync(post);
            return RedirectToAction("Index");
        }
        return View(post);
    }

    // Belirli bir blog gönderisini ID ile güncelleme sayfası
    public async Task<IActionResult> Edit(string id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // Güncellenmiş blog gönderisini veritabanına kaydetme işlemi
    [HttpPost]
    public async Task<IActionResult> Edit(string id, Post post)
    {
        if (ModelState.IsValid)
        {
            await _postRepository.UpdatePostAsync(id, post);
            return RedirectToAction("Index");
        }
        return View(post);
    }

    // Belirli bir blog gönderisini silme işlemi
    public async Task<IActionResult> Delete(string id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // Silme işlemini onaylama
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _postRepository.DeletePostAsync(id);
        return RedirectToAction("Index");
    }
}
