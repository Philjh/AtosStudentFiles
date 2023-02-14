using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class PostDetailsViewModel
    {
        [ScaffoldColumn(false)]
        public int PostId { get; set; }
        public string Thread { get; set; }
        public string Title { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Post Body")]
        public string PostBody { get; set; }

        [Display(Name = "Date of Post")]
        public DateTime PostDateTime { get; set; }


        public static PostDetailsViewModel FromPost(Post post)
        {
            return new PostDetailsViewModel
            {
                PostId = post.PostId,
                Thread = post.Thread.Title,
                Title = post.Title,
                UserName = post.UserName,
                PostBody = post.PostBody,
                PostDateTime = post.PostDateTime
            };
        }
    }
}
