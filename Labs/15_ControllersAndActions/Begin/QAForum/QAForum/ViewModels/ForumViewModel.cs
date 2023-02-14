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
        public string? Title { get; set; }
        public int NumberOfThreads { get; set; }

        public static ForumViewModel FromForum(Forum forum)
        {
            return new ForumViewModel
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                NumberOfThreads = forum.Threads.Count
            };
        }

        public static IEnumerable<ForumViewModel> FromForums(IEnumerable<Forum> forums)
        {
            return forums.Select(f => FromForum(f));
        }

    }
}
