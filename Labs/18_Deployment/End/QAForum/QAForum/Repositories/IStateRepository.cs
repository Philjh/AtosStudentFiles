using QAForum.ViewModels;

namespace QAForum.Repositories
{
    public interface IStateRepository
    {
        public void SetRecentPosts(List<RecentPostViewModel> recentPosts);
        public List<RecentPostViewModel> GetRecentPosts();

    }
}
