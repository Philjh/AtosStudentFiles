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
    public class ThreadEditViewModel
    {
        public string? Title { get; set; }

        [Display(Name = "Forum")]
        public int ForumId { get; set; }

        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        public IEnumerable<SelectListItem>? ForumSelectListItems { get; set; }

        public static ThreadEditViewModel FromThread(QAForum.Models.Thread thread, ForumDbContext context)
        {
            return new ThreadEditViewModel
            {
                Title = thread.Title,
                ForumId = thread.ForumId,
                UserName = thread.UserName,
                ForumSelectListItems = context.GetForumsSelectListItems(thread.ForumId)
            };
        }
    }
}
