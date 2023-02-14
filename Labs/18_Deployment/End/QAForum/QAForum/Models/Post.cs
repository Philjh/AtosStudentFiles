using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PostBody { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PostDateTime { get; set; }

        // Navigation Properties

        public virtual Thread Thread { get; set; }
    }
}
