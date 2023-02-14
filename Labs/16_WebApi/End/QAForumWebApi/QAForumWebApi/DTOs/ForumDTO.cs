using QAForum.Models;
using System.ComponentModel.DataAnnotations;

namespace QAForumWebApi.DTOs
{
    public class ForumDTO
    {
        public int ForumId { get; set; }

        [Required]
        [MinLength(4)]
        public string? Title { get; set; }

        public IEnumerable<ThreadDTO>? Threads { get; set; }

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
