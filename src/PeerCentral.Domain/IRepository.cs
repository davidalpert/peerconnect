using System.Linq;

namespace PeerCentral.Domain
{
    public interface IRepository<out T>
    {
        IQueryable<T> All();
    }
}
