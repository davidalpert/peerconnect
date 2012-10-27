using System;
using PeerCentral.Domain;

namespace PeerCentral.WebClient.Models
{
    public class User : IUser
    {
        public String Name { get; set; }

        public int? Id { get; set; }
    }
}