using System;
using System.Linq;
using Ninject.Modules;
using PeerCentral.Domain;
using PeerCentral.WebClient.Models;

namespace PeerCentral.WebClient.Configuration
{
    public class NinjectWebClientModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRepository<User>>().To<FakeUserRepository>();
        }
    }

    public class FakeUserRepository : IRepository<User>
    {
        public IQueryable<User> All()
        {
            return new[]
                       {
                           new User {Id = 1, Name = "Joe"},
                           new User {Id = 2, Name = "Anne"},
                           new User {Id = 3, Name = "Admin"}
                       }.AsQueryable();
        }
    }
}
