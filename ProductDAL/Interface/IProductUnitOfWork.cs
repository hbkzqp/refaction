using ProductDAL.Repository;
using ProductData;
using System;
using System.Threading.Tasks;

namespace ProductDAL.UnitOfWork
{
    public interface IProductUnitOfWork:IDisposable
    {
        IRepository<Product, Guid> Products { get; }
        IRepository<ProductOption, Guid> ProductOptions { get; }
        Task<int> Commit();

    }

}
