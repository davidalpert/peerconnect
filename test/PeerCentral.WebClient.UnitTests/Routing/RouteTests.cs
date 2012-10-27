using System.Web;
using System.Web.Routing;
using MvcContrib.TestHelper;
using MvcContrib.TestHelper.Fakes;
using NUnit.Framework;
using PeerCentral.WebClient.App_Start;
using PeerCentral.WebClient.Configuration;
using PeerCentral.WebClient.Controllers;
using System.Web.Mvc;
using RestfulRouting;

namespace PeerCentral.WebClient.UnitTests.Routing
{
    public class RouteTests
    {
        [SetUp]
        public void Setup()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void ItShouldMapTheSiteRoot()
        {
            "~/".ShouldMapTo<HomeController>(c => c.Index());
        }

        [Test]
        public void ItShouldMapLogin()
        {
            "~/login".WithMethod(HttpVerbs.Get).ShouldMapTo<SessionController>(c => c.New());
        }

        [Test]
        public void ItShouldMapLogout()
        {
            "~/logout".WithMethod(HttpVerbs.Get).ShouldMapTo<HomeController>(c => c.Logout());
        }

        [Test]
        public void ItShouldMapToSessionNew()
        {
            "~/session/new".ShouldMapTo<SessionController>(c => c.New());
        }

        [Test]
        public void ItShouldMapSessionCreate()
        {
            "~/session".WithMethod(HttpVerbs.Post).ShouldMapTo<SessionController>(c => c.Create(null));
        }

        [Test]
        public void ItShouldMapToSessionDestroy()
        {
            "~/session".WithMethod(HttpVerbs.Delete).ShouldMapTo<SessionController>(c => c.Destroy());
        }
    }
}
