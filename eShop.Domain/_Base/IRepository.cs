namespace eShop.Domain._Base
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
    }
}