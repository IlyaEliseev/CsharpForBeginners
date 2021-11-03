using System.Collections.Generic;

namespace Shop.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetProductList();
        T GetProduct(int id);
        void AddProduct(T entity);
        void RemoveProduct(int id);
        int GetCount();
    }
}
