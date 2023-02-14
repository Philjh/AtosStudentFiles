using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAForum.ViewModels;
using QAForum.EF;
using QAForum.Models;

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

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            var thread = context.Threads.Single(t => t.ThreadId == id);
            return View(ThreadViewModel.FromThread(thread));
        }

        // GET: Thread/Create
        public ActionResult Create()
        {
            return View(ThreadCreateViewModel.WithForumSelectListItems(context));
        }

        // POST: Thread/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThreadCreateViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                QAForum.Models.Thread thread = new QAForum.Models.Thread
                {
                    Title = viewModel.Title,
                    ForumId = viewModel.ForumId,
                    UserName = viewModel.UserName
                };
                if (viewModel.AddWelcomePost)
                {
                    thread.Posts = new List<Post>
                    {
                        new Post
                        {
                            UserName = viewModel.UserName,
                            Title = "Welcome",
                            PostDateTime = DateTime.Now,
                            PostBody = "Welcome to this thread. We hope it provides you with useful information",
                            Thread = thread
                        }
                    };
                }
                context.Threads.Add(thread);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                viewModel.ForumSelectListItems = context.GetForumsSelectListItems();
                return View(viewModel);
            }
        }

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            var thread = context.Threads.Single(t => t.ThreadId == id);
            return View(ThreadEditViewModel.FromThread(thread, context));
        }

        // POST: Thread/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ThreadEditViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
                QAForum.Models.Thread thread = context.Threads.Single(t => t.ThreadId == id);
                thread.Title = viewModel.Title;
                thread.ForumId = viewModel.ForumId;
                thread.UserName = viewModel.UserName;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                viewModel.ForumSelectListItems = context.GetForumsSelectListItems();
                return View(viewModel);
            }
        }

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            var thread = context.Threads.Single(t => t.ThreadId == id);
            return View(ThreadViewModel.FromThread(thread));
        }

        // POST: Thread/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var thread = context.Threads.Single(t => t.ThreadId == id);
            try
            {
                // TODO: Add delete logic here
                context.Threads.Remove(thread);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(ThreadViewModel.FromThread(thread));
            }
        }
    }
}