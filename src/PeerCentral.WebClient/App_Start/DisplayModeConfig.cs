using System;
using System.Collections.Generic;
using System.Web.WebPages;

namespace PeerCentral.WebClient.App_Start
{
    public class DisplayModeConfig
    {
        public static void RegisterDisplayModes(IList<IDisplayMode> modes)
        {
            modes.Insert(0, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context =>
                                    context.GetOverriddenUserAgent()
                                        .IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }
    }
}