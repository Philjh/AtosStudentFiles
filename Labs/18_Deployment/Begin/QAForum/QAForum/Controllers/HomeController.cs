using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QAForum.EF;
using QAForum.Models;
using QAForum.ViewModels;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace QAForum.Controllers
{
    public class HomeController : Controller
    {
        public const string DARK_COOKIE = "Dark";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dark = Request.Cookies[DARK_COOKIE] == "1" ? true : false;
            Response.Cookies.Append(DARK_COOKIE, dark ? "1" : "0",  new CookieOptions{ Expires = DateTimeOffset.Now.AddYears(10) });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error([FromServices] ForumDbContext context)
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            var unhandledException = new UnhandledException
            {
                ExceptionDateTime = DateTime.Now,
                Path = exceptionHandlerPathFeature.Path,
                ExceptionMessage = exception?.Message,
                BaseExceptionMessage = exception?.GetBaseException()?.Message,
                StackTrace = exception?.StackTrace
            };

            try
            {
                context.UnhandledExceptions.Add(unhandledException);
                context.SaveChanges();
            }
            catch
            {
                ViewBag.Message = "This error was NOT logged, due to a further error occurring while saving the error";
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Status(int code)
        {
            string? message = Enum.GetName(typeof(HttpStatusCode), code);
            if (message == null)
            {
                ViewBag.Message = $"Error {code}";
            }
            else
            {
                // Turn the message from PascalCase to normal spacing
                message = Regex.Replace(message, ".[A-Z]", m => $"{m.Value[0]} {m.Value[1]}");
                ViewBag.Message = $"Error {code} - {message}";
            }

            return View();
        }

        public IActionResult Settings()
        {
            var viewModel = new UserSettingsViewModel
            {
                DarkMode = Request.Cookies[DARK_COOKIE] == "1" ? true : false
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Settings(UserSettingsViewModel viewModel)
        {
            // Save the settings - TO DO

            Response.Cookies.Append(DARK_COOKIE, viewModel.DarkMode ? "1" : "0", new CookieOptions{ Expires = DateTimeOffset.Now.AddYears(10) });

            return RedirectToAction("Index");
        }

    }
}