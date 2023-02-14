using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.DTOs
{
    public class ThreadDTO
    {
        public int ThreadId { get; set; }
        public string? Title { get; set; }
        public string? UserName { get; set; }

        public static ThreadDTO FromThread(QAForum.Models.Thread thread)
        {
            return new ThreadDTO
            {
                ThreadId = thread.ThreadId,
                Title = thread.Title,
                UserName = thread.UserName
            };
        }

        public static IEnumerable<ThreadDTO> FromThreads(IEnumerable<QAForum.Models.Thread> threads)
        {
            return threads.Select(t => FromThread(t));
        }
    }
}
