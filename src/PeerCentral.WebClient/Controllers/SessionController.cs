using System.Web.Mvc;
using PeerCentral.Domain;
using PeerCentral.WebClient.Models;

namespace PeerCentral.WebClient.Controllers
{
    public class SessionController : ApplicationController
    {
        private IRepository<User> _repository;

        public SessionController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// POST: /Login/
        /// </summary>
        [HttpPost]
        public ActionResult Create()
        {
            return View();
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
    }
}
