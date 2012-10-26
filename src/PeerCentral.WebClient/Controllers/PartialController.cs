using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeerCentral.Domain;

namespace PeerCentral.WebClient.Controllers
{
    public class PartialController : Controller
    {
        private readonly IRuntimeSession _runtimeSession;

        public PartialController(IRuntimeSession runtimeSession)
        {
            this._runtimeSession = runtimeSession;
        }

        public ActionResult Login()
        {
            return PartialView("Login", this._runtimeSession);
        }
    }
}
