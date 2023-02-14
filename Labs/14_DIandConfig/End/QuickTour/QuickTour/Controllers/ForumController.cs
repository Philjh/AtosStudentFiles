using Microsoft.AspNetCore.Mvc;
using QuickTour.Models;
using QuickTour.ViewModels;
using System.Reflection;

namespace QuickTour.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumContext _context;

        private readonly ILogger<ForumController> _logger;

        private readonly ITransient _tran;
        private readonly IScoped _scoped;
        private readonly ISingleton _single;


        public ForumController(IForumContext context,ILogger<ForumController> logger, ITransient tran, IScoped scoped, ISingleton single)
        {
            _logger = logger;
            _context = context;
            _tran = tran;
            _scoped = scoped;
            _single = single;

        }
        public IActionResult Index()
        {
            _logger.LogInformation("In the Forums Index() method <=======");

            _tran.WriteGuidToConsole();
            _scoped.WriteGuidToConsole();
            _single.WriteGuidToConsole();

            _logger.LogDebug("About to get the data");

            IEnumerable<Forum> forums = _context.GetForums();

            _logger.LogDebug($"Number of forums: {forums.Count()}");

            return View(ForumViewModel.FromForums(forums));


        }
    }
}
