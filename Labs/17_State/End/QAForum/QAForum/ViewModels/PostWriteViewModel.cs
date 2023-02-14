using Microsoft.AspNetCore.Mvc.Rendering;
using QAForum.EF;
using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class PostWriteViewModel
    {
        [Display(Name = "Thread")]
        public int ThreadId { get; set; }

        [Required(AllowEmptyStrings = false,
                          ErrorMessage = "Specify a title for your post")]
        [StringLength(100, ErrorMessage = "Please shorten your post's title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "Please specify the user name of the post's owner")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false,
                          ErrorMessage = "Specify the body of your post")]
        [MinLength(10,
            ErrorMessage = "You need to write a bit more to make a valid post")]
        [Display(Name = "Post Body")]
        public string PostBody { get; set; }

        [Display(Name = "Date of Post")]
        public DateTime PostDateTime { get; set; }

        public IEnumerable<SelectListItem>? ThreadSelectListItems { get; set; }

        public static PostWriteViewModel FromPost(Post post, ForumDbContext context)
        {
            return new PostWriteViewModel
            {
                ThreadId = post.ThreadId,
                Title = post.Title,
                UserName = post.UserName,
                PostBody = post.PostBody,
                PostDateTime = post.PostDateTime,
                ThreadSelectListItems = context.GetThreadsSelectListItems(post.ThreadId)
            };
        }

        public static PostWriteViewModel WithThreadSelectListItems(ForumDbContext context)
        {
            return new PostWriteViewModel { ThreadSelectListItems = context.GetThreadsSelectListItems() };
        }
    }
}
