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
 
    public class PostController : Controller
    {
        private readonly ForumDbContext? context;

        public PostController(ForumDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            return View(PostViewModel.FromPosts(context.Posts));
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var post = context.Posts.Single(p => p.PostId == id);
            return View(PostDetailsViewModel.FromPost(post));
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View(PostWriteViewModel.WithThreadSelectListItems(context));
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostWriteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Post post = new Post
                    {
                        ThreadId = viewModel.ThreadId,
                        Title = viewModel.Title,
                        UserName = viewModel.UserName,
                        PostBody = viewModel.PostBody,
                        PostDateTime = viewModel.PostDateTime
                    };
                    context.Posts.Add(post);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    viewModel.ThreadSelectListItems = context.GetThreadsSelectListItems();
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                viewModel.ThreadSelectListItems = context.GetThreadsSelectListItems();
                return View(viewModel);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post post = context.Posts.Single(p => p.PostId == id);
            return View(PostWriteViewModel.FromPost(post, context));
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostWriteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    var post = context.Posts.Single(p => p.PostId == id);
                    post.ThreadId = viewModel.ThreadId;
                    post.Title = viewModel.Title;
                    post.UserName = viewModel.UserName;
                    post.PostBody = viewModel.PostBody;
                    post.PostDateTime = viewModel.PostDateTime;
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    viewModel.ThreadSelectListItems = context.GetThreadsSelectListItems();
                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                viewModel.ThreadSelectListItems = context.GetThreadsSelectListItems();
                return View(viewModel);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            var post = context.Posts.Single(p => p.PostId == id);
            return View(PostDetailsViewModel.FromPost(post));
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var post = context.Posts.Single(p => p.PostId == id);
            try
            {
                // TODO: Add delete logic here
                context.Posts.Remove(post);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorText = e.GetBaseException().Message;
                return View(PostDetailsViewModel.FromPost(post));
            }
        }



    }
}