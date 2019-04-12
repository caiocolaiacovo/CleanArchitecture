using System.Threading.Tasks;

namespace eShop.Application
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}