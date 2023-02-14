using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class ForumViewModel
    {
        [ScaffoldColumn(false)]
        public int ForumId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Number of Threads")]
        public int NumberOfThreads { get; set; }

        public IEnumerable<ThreadViewModel> Threads { get; set; }

        public static ForumViewModel FromForum(Forum forum)
        {
            return new ForumViewModel
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                NumberOfThreads = forum.Threads.Count,
                Threads = ThreadViewModel.FromThreads(forum.Threads)
            };
        }

        public static IEnumerable<ForumViewModel> FromForums(IEnumerable<Forum> forums)
        {
            return forums.Select(f => FromForum(f));
        }

    }
}
