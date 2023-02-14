using Microsoft.AspNetCore.Mvc.Rendering;
using QAForum.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.ViewModels
{
    public static class SelectListItemHelpers
    {
        public static IEnumerable<SelectListItem> GetForumsSelectListItems
            (this ForumDbContext context, int? selectedForumId = null)
        {
            return context.Forums.Select(f => new SelectListItem(
                    f.Title,
                    f.ForumId.ToString(),
                    f.ForumId == selectedForumId
                ));
        }

        public static IEnumerable<SelectListItem> GetThreadsSelectListItems
            (this ForumDbContext context, int? selectedThreadId = null)
        {
            return context.Threads.Select(t => new SelectListItem(
                    t.Title,
                    t.ThreadId.ToString(),
                    t.ThreadId == selectedThreadId
                ));
        }
    }
}
