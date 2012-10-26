using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
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
            RouteTable.Routes.Clear();

            RouteTable.Routes.MapRoutes<Routes>();
        }

        [Test]
        public void ItShouldMapToLoginControllerNew()
        {
            "~/login/new".ShouldMapTo<SessionController>(c => c.New());
        }

        [Test]
        public void ItShouldMapToLoginControllerCreate()
        {
            "~/login".WithMethod(HttpVerbs.Post).ShouldMapTo<SessionController>(c => c.Create(null));
        }
    }
}
