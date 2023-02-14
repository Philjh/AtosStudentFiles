using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QAForum.EF;
using QAForum.ViewModels;

namespace QAForum.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumDbContext context;

        public PostController(ForumDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(PostViewModel.FromPosts(context.Posts));
        }
    }
}
