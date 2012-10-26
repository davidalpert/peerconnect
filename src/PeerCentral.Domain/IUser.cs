using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerCentral.Domain
{
    public interface IUser
    {
        String Name { get; set; }
        int Id { get; set; }
    }
}
