

using ProductDAL.Repository;
using ProductData;
using System;
using System.Data.Entity;

namespace ProductDAL.UnitOfWork
{
    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private IRepository<Product,Guid> _Products;

        private IRepository<ProductOption, Guid> _ProductOptions;
        private DbContext _Context;
        public ProductUnitOfWork(string NameOrConnection)
        {
            this._Context = new ProductEntity(NameOrConnection);
            this._Products = new Repository<Product, Guid>(this._Context);
            this._ProductOptions = new Repository<ProductOption, Guid>(this._Context);
        }

        public IRepository<Product, Guid> Products => this._Products;

        public Repository<ProductOption, Guid> ProductOptions => this.ProductOptions;

        public int Commit()
        {
            return this._Context.SaveChanges();
        }
    }
}
