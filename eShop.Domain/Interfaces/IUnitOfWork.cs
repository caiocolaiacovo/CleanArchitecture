using System.Threading.Tasks;

namespace eShop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}