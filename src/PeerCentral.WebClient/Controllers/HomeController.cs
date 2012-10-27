using System.Web.Mvc;
using PeerCentral.Domain;
using PeerCentral.WebClient.Views.Home;

namespace PeerCentral.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRuntimeSession _runtimeSession;

        public HomeController(IRuntimeSession runtimeSession)
        {
            _runtimeSession = runtimeSession;
        }

        public ActionResult Index()
        {
            if (_runtimeSession.IsAuthenticated == false)
                return View("Home");

            return View("Dashboard", new DashboardViewModel
            {
                CurrentUser = this._runtimeSession.GetCurrentUser()
            });
        }

        public ActionResult Logout()
        {
            _runtimeSession.Logout();

            return Redirect("~/");
        }
    }
}
