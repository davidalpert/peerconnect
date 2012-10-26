using System.Web.Mvc;
using System.Web.Routing;
using RestfulRouting;
using PeerCentral.WebClient.Controllers;

namespace PeerCentral.WebClient.Configuration
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");

            map.Root<HomeController>(c => c.Index());

            map.Resource<SessionController>(login =>
                                                {
                                                    login.Only("create", "new", "destroy");
                                                    login.As("login");
                                                });

            // to support partial requests
            map.Route(new Route("partial/{action}",
                                new RouteValueDictionary(new {controller = "partial"}),
                                new MvcRouteHandler()));
        }

    }
}