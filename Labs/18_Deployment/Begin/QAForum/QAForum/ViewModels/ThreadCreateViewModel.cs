using Microsoft.AspNetCore.Mvc.Rendering;
using QAForum.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class ThreadCreateViewModel
    {
        public string Title { get; set; }

        [Display(Name = "Forum")]
        public int ForumId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Add Welcome Post?")]
        public bool AddWelcomePost { get; set; }

        public IEnumerable<SelectListItem> ForumSelectListItems { get; set; }

        public static ThreadCreateViewModel WithForumSelectListItems(ForumDbContext context)
        {
            return new ThreadCreateViewModel { ForumSelectListItems = context.GetForumsSelectListItems() };
        }

    }

}
