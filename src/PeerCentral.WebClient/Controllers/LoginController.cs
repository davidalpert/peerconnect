using System.Web.Mvc;

namespace PeerCentral.WebClient.Controllers
{
    public class LoginController : ApplicationController
    {
        /// <summary>
        /// POST: /Login/
        /// </summary>
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }
    }
}
