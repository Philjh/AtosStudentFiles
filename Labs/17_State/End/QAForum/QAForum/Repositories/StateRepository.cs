using Microsoft.AspNetCore.Http;
using QAForum.ViewModels;
using System.Text.Json;

namespace QAForum.Repositories
{
    public class StateRepository: IStateRepository
    {
        private const string RECENT_POSTS_KEY = "RECENT_POSTS";
        private readonly IHttpContextAccessor httpContextAccessor;

        public StateRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public List<RecentPostViewModel> GetRecentPosts()
        {
            var json = httpContextAccessor.HttpContext.Session.GetString("RECENT_POSTS");
            if (json == null)
            {
                return new List<RecentPostViewModel>();
            }
            else
            {
                return JsonSerializer.Deserialize<List<RecentPostViewModel>>(json);
            }
        }

        public void SetRecentPosts(List<RecentPostViewModel> recentPosts)
        {
            httpContextAccessor.HttpContext.Session.SetString(RECENT_POSTS_KEY, JsonSerializer.Serialize(recentPosts));
        }

    }
}
