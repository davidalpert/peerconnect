using System;
using System.Linq;
using System.Web.Mvc;
using PeerCentral.Domain;
using PeerCentral.WebClient.Models;

namespace PeerCentral.WebClient.Controllers
{
    public class SessionController : ApplicationController
    {
        private readonly IRuntimeSession _runtimeSession;
        private readonly IRepository<IUser> _repository;

        public SessionController(IRuntimeSession runtimeSession, IRepository<IUser> repository)
        {
            _runtimeSession = runtimeSession;
            _repository = repository;
        }

        /// <summary>
        /// POST: /Login/
        /// </summary>
        [HttpPost]
        public ActionResult Create(int? id)
        {
            var user = _repository.All().FirstOrDefault(u => u.Id.Equals(id ?? -1));
            _runtimeSession.Login(user);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET: /Login/
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            return View(this._repository.All());
        }

        public ActionResult Index()
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Destroy()
        {
            throw new InvalidOperationException("here");
        }
    }
}
