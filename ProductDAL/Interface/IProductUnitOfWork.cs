using ProductDAL.Repository;
using ProductData;
using System;

namespace ProductDAL.UnitOfWork
{
    public interface IProductUnitOfWork:IDisposable
    {
        IRepository<Product, Guid> Products { get; }
        IRepository<ProductOption, Guid> ProductOptions { get; }
        int Commit();

    }

}
