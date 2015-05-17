using System.Web.Mvc;
using Logging;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _log;

        public HomeController(ILogger log)
        {
            _log = log;
        }

        public ActionResult Index()
        {
            _log.LogInfoMessage("User hit index method!");

            return View();
        }
    }
}