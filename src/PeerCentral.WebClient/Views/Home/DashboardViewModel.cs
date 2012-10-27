using PeerCentral.Domain;
using PeerCentral.WebClient.Views.Shared;

namespace PeerCentral.WebClient.Views.Home
{
    public class DashboardViewModel : PageViewModel
    {
        public IUser CurrentUser { get; set; }
    }
}