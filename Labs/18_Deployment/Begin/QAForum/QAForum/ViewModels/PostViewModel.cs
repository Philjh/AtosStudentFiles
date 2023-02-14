using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class PostViewModel
    {
        [ScaffoldColumn(false)]
        public int PostId { get; set; }

        [UIHint("ShortenedString")]
        public string Thread { get; set; }

        public string Title { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Date of Post")]
        public DateTime PostDateTime { get; set; }

        public static PostViewModel FromPost(Post post)
        {
            return new PostViewModel
            {
                PostId = post.PostId,
                Thread = post.Thread.Title,
                Title = post.Title,
                UserName = post.UserName,
                PostDateTime = post.PostDateTime
            };
        }

        public static IEnumerable<PostViewModel> FromPosts(IEnumerable<Post> posts)
        {
            return posts.Select(p => FromPost(p));
        }
    }
}
