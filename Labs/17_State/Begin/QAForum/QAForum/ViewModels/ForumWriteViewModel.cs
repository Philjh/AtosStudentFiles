using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public class ForumWriteViewModel
    {
        public string Title { get; set; }

        public static ForumWriteViewModel FromForum(Forum forum)
        {
            return new ForumWriteViewModel
            {
                Title = forum.Title,
            };
        }
    }

}
