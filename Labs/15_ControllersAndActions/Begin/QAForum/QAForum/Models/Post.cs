using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }
        public string? Title { get; set; }
        public string? UserName { get; set; }

        public string? PostBody { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PostDateTime { get; set; }

        // Navigation Properties
        public virtual Thread? Thread { get; set; }
    }
}
