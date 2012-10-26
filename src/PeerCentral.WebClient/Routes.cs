using System.Web.Routing;
using RestfulRouting;
using PeerCentral.WebClient.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(PeerCentral.WebClient.Routes), "Start")]

namespace PeerCentral.WebClient
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");

            map.Resource<LoginController>(login => login.Only("create"));
        }

        public static void Start()
        {
            var routes = RouteTable.Routes;
            routes.MapRoutes<Routes>();
        }
    }
}