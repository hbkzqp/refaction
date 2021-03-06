﻿

using ProductDAL.Repository;
using ProductData;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProductDAL.UnitOfWork
{
    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private IRepository<Product, Guid> _products;

        private IRepository<ProductOption, Guid> _productOptions;
        private DbContext _context;
        public ProductUnitOfWork(string NameOrConnection)
        {
            _context = new ProductContext(NameOrConnection);
            _products = new Repository<Product, Guid>(_context);
            _productOptions = new Repository<ProductOption, Guid>(_context);
        }

        public IRepository<Product, Guid> Products => _products;

        public IRepository<ProductOption, Guid> ProductOptions => _productOptions;

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
