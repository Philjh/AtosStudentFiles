using Microsoft.EntityFrameworkCore.Metadata;
using QAForum.Models;
using System.Collections.Generic;

namespace QAForum.ViewModels
{
    public class RecentPostViewModel
    {
        public const int MAX_RECENT_ITEMS = 5;

        public int PostId{ get; set; }
        public string? Title { get; set; }

        public static RecentPostViewModel FromPost(Post post)
        {
            return new RecentPostViewModel
                {
                    PostId = post.PostId,
                    Title = post.Title
                };
        }
    }

        public static class RecentPostViewModelExtensions
        {
            public static void AddRecentPost(this List < RecentPostViewModel > list,   RecentPostViewModel post)
            {
                // If the item is already in the list, remove it so that it
                // gets re-inserted at the top
                int index = list.FindIndex(p => p.PostId == post.PostId);
                if (index != -1)
                {
                    list.RemoveAt(index);
                }

                // Add the item to the top of the list
                list.Insert(0, post);

                // Remove items from the bottom if the list is too big
                if (list.Count > RecentPostViewModel.MAX_RECENT_ITEMS)
                {
                    list.RemoveRange(RecentPostViewModel.MAX_RECENT_ITEMS,
                    list.Count - RecentPostViewModel.MAX_RECENT_ITEMS);
                }
            }
        }

}
