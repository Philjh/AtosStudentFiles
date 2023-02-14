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
        public string? Thread { get; set; }
        public string? Title { get; set; }
        public string? UserName { get; set; }
        public string? PostBody { get; set; }
        public DateTime PostDateTime { get; set; }

        public static PostViewModel FromPost(Post post)
        {
            return new PostViewModel
            {
                PostId = post.PostId,
                Thread = post.Thread.Title,
                Title = post.Title,
                UserName = post.UserName,
                PostBody = post.PostBody,
                PostDateTime = post.PostDateTime
            };
        }

        public static IEnumerable<PostViewModel> FromPosts(IEnumerable<Post> posts)
        {
            return posts.Select(p => FromPost(p));
        }
    }
}
