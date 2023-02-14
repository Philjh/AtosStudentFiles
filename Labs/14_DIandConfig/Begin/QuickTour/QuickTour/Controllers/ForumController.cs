using Microsoft.AspNetCore.Mvc;
using QuickTour.Models;
using QuickTour.ViewModels;
using System.Reflection;

namespace QuickTour.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {

            MockForumContext mockForum = new MockForumContext();
            IEnumerable<Forum> forums = mockForum.GetForums();
            return View(ForumViewModel.FromForums(forums));


        }
    }
}
