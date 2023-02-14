using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class ThreadViewModel
    {
        [ScaffoldColumn(false)]
        public int ThreadId { get; set; }
        public string? Forum { get; set; }
        public string? Title { get; set; }
        public string? UserName { get; set; }

        public static ThreadViewModel FromThread(QAForum.Models.Thread thread)
        {
            return new ThreadViewModel
            {
                ThreadId = thread.ThreadId,
                Forum = thread.Forum.Title,
                Title = thread.Title,
                UserName = thread.UserName
            };
        }

        public static IEnumerable<ThreadViewModel> FromThreads(IEnumerable<QAForum.Models.Thread> threads)
        {
            return threads.Select(t => FromThread(t));
        }
    }
}
