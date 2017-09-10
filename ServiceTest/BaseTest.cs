using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductDAL.UnitOfWork;
using ProductData;
using ProductDAL.Repository;

namespace ServiceTest
{
    [TestClass]
    public class BaseTest
    {

        protected Mock<IProductUnitOfWork> _mockUnitOfwork;
        //protected Mock<IRepository<Product, Guid>> _mockProductRepository;
        //protected Mock<IRepository<ProductOption, Guid>> _mockProducOptiontRepository;
        protected List<Product> _mockProductTable;
        protected List<ProductOption> _mockProductOptionsTable;

        public BaseTest()
        {
            this.MockUnitOfWork();
        }
        private void MockUnitOfWork()
        {
            this._mockUnitOfwork = new Mock<IProductUnitOfWork>();
            this.MockProductOptionRepository();
            this.MockProductRepository();
        }

        private void MockProductRepository()
        {
            this._mockProductTable = new List<Product>();
            var mock = new Mock<IRepository<Product, Guid>>();
            mock.Setup(s => s.Find(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns<Expression<Func<Product, bool>>>(ex => _mockProductTable.Where(ex.Compile()));
            mock.Setup(s => s.Add(It.IsAny<Product>())).Callback<Product>(p => this._mockProductTable.Add(p));
            mock.Setup(s => s.AddRange(It.IsAny<IEnumerable<Product>>()))
                .Callback<IEnumerable<Product>>(ps => this._mockProductTable.AddRange(ps));
            mock.Setup(s => s.Get(It.IsAny<Guid>())).Returns<Guid>(id => this._mockProductTable.Find(p => p.Id == id));
            mock.Setup(s => s.GetAll()).Returns(this._mockProductTable);
            mock.Setup(s => s.Remove(It.IsAny<Product>())).Callback<Product>(p => this._mockProductTable.Remove(p));
            mock.Setup(s => s.RemoveByKey(It.IsAny<Guid>())).Callback<Guid>(id => { var product = this._mockProductTable.Find(p => p.Id == id); this._mockProductTable.Remove(product); });
            mock.Setup(s => s.RemoveRange(It.IsAny<IEnumerable<Product>>()))
                .Callback<IEnumerable<Product>>(ps => this._mockProductTable.RemoveAll(ps.Contains));
            mock.Setup(s => s.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns<Expression<Func<Product, bool>>>(ex => _mockProductTable.Where(ex.Compile()).SingleOrDefault());
            this._mockUnitOfwork.Setup(u => u.Products).Returns(mock.Object);
        }
        private void MockProductOptionRepository()
        {
            this._mockProductOptionsTable = new List<ProductOption>();
            var mock = new Mock<IRepository<ProductOption, Guid>>();
            mock.Setup(s => s.Find(It.IsAny<Expression<Func<ProductOption, bool>>>()))
                .Returns<Expression<Func<ProductOption, bool>>>(ex => _mockProductOptionsTable.Where(ex.Compile()));
            mock.Setup(s => s.Add(It.IsAny<ProductOption>())).Callback<ProductOption>(p => this._mockProductOptionsTable.Add(p));
            mock.Setup(s => s.AddRange(It.IsAny<IEnumerable<ProductOption>>()))
                .Callback<IEnumerable<ProductOption>>(ps => this._mockProductOptionsTable.AddRange(ps));
            mock.Setup(s => s.Get(It.IsAny<Guid>())).Returns<Guid>(id => this._mockProductOptionsTable.Find(p => p.Id == id));
            mock.Setup(s => s.GetAll()).Returns(this._mockProductOptionsTable);
            mock.Setup(s => s.Remove(It.IsAny<ProductOption>())).Callback<ProductOption>(p => this._mockProductOptionsTable.Remove(p));
            mock.Setup(s => s.RemoveByKey(It.IsAny<Guid>())).Callback<Guid>(id => { var product = this._mockProductOptionsTable.Find(p => p.Id == id); this._mockProductOptionsTable.Remove(product); });
            mock.Setup(s => s.RemoveRange(It.IsAny<IEnumerable<ProductOption>>()))
                .Callback<IEnumerable<ProductOption>>(ps => this._mockProductOptionsTable.RemoveAll(ps.Contains));
            mock.Setup(s => s.SingleOrDefault(It.IsAny<Expression<Func<ProductOption, bool>>>()))
                .Returns<Expression<Func<ProductOption, bool>>>(ex => _mockProductOptionsTable.Where(ex.Compile()).SingleOrDefault());
            this._mockUnitOfwork.Setup(u => u.ProductOptions).Returns(mock.Object);
        }
        protected virtual void InitTest()
        {
            this.MockUnitOfWork();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
