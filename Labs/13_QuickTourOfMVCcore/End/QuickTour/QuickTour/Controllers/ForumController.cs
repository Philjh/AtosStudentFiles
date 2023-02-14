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
            //Forum forum = new Forum { ForumId = 1, Title = "First Forum" };

            //using ViewBag
            //ViewBag.Forum = forum;
            //return View();

            //passing a model
            //return View(forum);

            // Get a list of Forums
            //IEnumerable<Forum> forums = new List<Forum>() {
            //                            new Forum() { Title = "Topic1" },
            //                            new Forum() { Title = "Topic2" }
            //};
            //return View(forums);


            //use mock context
            //MockForumContext mockForum = new MockForumContext();
            //IEnumerable<Forum> forums = mockForum.GetForums();
            //return View(forums);

            //using ViewModel
            MockForumContext mockForum = new MockForumContext();
            IEnumerable<Forum> forums = mockForum.GetForums();
            return View(ForumViewModel.FromForums(forums));


        }
    }
}
