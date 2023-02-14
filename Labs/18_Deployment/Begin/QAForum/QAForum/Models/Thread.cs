using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

        // Navigation Properties
        public virtual Forum Forum { get; set; }
    }
}
