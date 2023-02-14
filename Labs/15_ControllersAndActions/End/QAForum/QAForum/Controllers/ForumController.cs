using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAForum.EF;
using QAForum.Models;
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

        // GET: ForumController
        public ActionResult Index()
        {
            return View(ForumViewModel.FromForums(context.Forums));
        }

        // GET: ForumController/Details/5
        public ActionResult Details(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumViewModel.FromForum(forum));

        }

        // GET: ForumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ForumWriteViewModel viewModel)
        {
            try
            {
                Forum forum = new Forum
                {
                    Title = viewModel.Title
                };
                context.Forums.Add(forum);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForumController/Edit/5
        public ActionResult Edit(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumWriteViewModel.FromForum(forum));

        }

        // POST: ForumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ForumWriteViewModel viewModel)
        {
            try
            {
                var forum = context.Forums.Single(f => f.ForumId == id);
                forum.Title = viewModel.Title;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: ForumController/Delete/5
        public ActionResult Delete(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumViewModel.FromForum(forum));

        }

        // POST: ForumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);

            try
            {
                context.Forums.Remove(forum);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(ForumViewModel.FromForum(forum));
            }
        }
    }
}
