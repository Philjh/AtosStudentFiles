using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QAForum.EF;
using QAForum.ViewModels;

namespace QAForum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ForumDbContext context;

        public ThreadController(ForumDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(ThreadViewModel.FromThreads(context.Threads));
        }
    }
}
