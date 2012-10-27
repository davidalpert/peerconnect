using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using PeerCentral.WebClient.App_Start;
using PeerCentral.WebClient.Controllers;
using PeerCentral.WebClient.Models;

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

        [Test]
        public void ItShouldMapBragsAsResources()
        {
            "~/brags".WithMethod(HttpVerbs.Get).ShouldMapTo<BragController>(c => c.Index());
            "~/brags/2".WithMethod(HttpVerbs.Get).ShouldMapTo<BragController>(c => c.Show(2));
            "~/brags/new".WithMethod(HttpVerbs.Get).ShouldMapTo<BragController>(c => c.New());
            "~/brags".WithMethod(HttpVerbs.Post).ShouldMapTo<BragController>(c => c.Create());
            "~/brags/2/edit".WithMethod(HttpVerbs.Get).ShouldMapTo<BragController>(c => c.Edit(2));
            "~/brags/2".WithMethod(HttpVerbs.Put).ShouldMapTo<BragController>(c => c.Update(2));
            "~/brags/2".WithMethod(HttpVerbs.Delete).ShouldMapTo<BragController>(c => c.Destroy(2));
        }
    }
}