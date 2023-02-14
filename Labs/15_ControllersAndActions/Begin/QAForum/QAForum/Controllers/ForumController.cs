using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QAForum.EF;
using QAForum.ViewModels;

namespace QAForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumDbContext context;

        public ForumController(ForumDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(ForumViewModel.FromForums(context.Forums.Include(f => f.Threads)));
        }

    }
}
