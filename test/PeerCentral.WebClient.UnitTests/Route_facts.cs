using System;
using System.Web.Routing;
using MvcContrib.TestHelper;
using PeerCentral.WebClient.Controllers;
using Xunit;

namespace PeerCentral.WebClient.UnitTests
{
    public class Route_facts
    {
        /// <summary>
        /// Classes containing xUnit.NET tests are instantiated once per test 
        /// to enforce isolation so the constructor is where you put per-test 
        /// set-up code.
        /// </summary>
        /// <remarks>
        /// Your test class can implement <see cref="IDisposable"/> to host
        /// per-test tear-down code in the Dispose() method.
        /// </remarks>
        public Route_facts()
        {
            RouteTable.Routes.Clear();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [Fact]
        public void Home_page()
        {
            "~/".ShouldMapTo<HomeController>(c => c.Index());
        }
    }
}
