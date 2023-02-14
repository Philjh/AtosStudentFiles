using QAForum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QAForum.DTOs
{
    public class ForumDTO
    {
        public int ForumId { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        public IEnumerable<ThreadDTO> Threads { get; set; }

        public static ForumDTO FromForum(Forum forum)
        {
            return new ForumDTO
            {
                ForumId = forum.ForumId,
                Title = forum.Title,
                Threads = ThreadDTO.FromThreads(forum.Threads)
            };
        }

        public static IEnumerable<ForumDTO> FromFourms(IEnumerable<Forum> forums)
        {
            return forums.Select(f => FromForum(f));
        }
    }
}
