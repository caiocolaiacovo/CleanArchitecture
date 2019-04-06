using System.Threading.Tasks;

namespace eShop.Domain._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}