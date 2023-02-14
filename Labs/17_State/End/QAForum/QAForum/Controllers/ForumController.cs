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
   
    public class ForumController : Controller
    {
        private readonly ForumDbContext context;

        public ForumController(ForumDbContext context)
        {
            this.context = context;
        }

        // GET: Forum
        public ActionResult Index()
        {
            return View(ForumViewModel.FromForums(context.Forums));
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumViewModel.FromForum(forum));
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ForumWriteViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                Forum forum = new Forum
                {
                    Title = viewModel.Title
                };
                context.Forums.Add(forum);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(viewModel);
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumWriteViewModel.FromForum(forum));
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ForumWriteViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
                var forum = context.Forums.Single(f => f.ForumId == id);
                forum.Title = viewModel.Title;
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(viewModel);
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            return View(ForumViewModel.FromForum(forum));
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var forum = context.Forums.Single(f => f.ForumId == id);
            try
            {
                // TODO: Add delete logic here
                context.Forums.Remove(forum);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(ForumViewModel.FromForum(forum));
            }

        }
    }
}