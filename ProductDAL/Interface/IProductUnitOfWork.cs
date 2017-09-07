using ProductDAL.Repository;
using ProductData;
using System;

namespace ProductDAL.UnitOfWork
{
    public interface IProductUnitOfWork
    {
        IRepository<Product,Guid> Products{ get; }
        Repository<ProductOption, Guid> ProductOptions { get; }
        int Commit();
    }

}
