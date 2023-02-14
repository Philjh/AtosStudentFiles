using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public class Forum
    {
        public int ForumId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
    }
}
