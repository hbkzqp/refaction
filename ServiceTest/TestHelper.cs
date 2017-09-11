using Moq;
using ProductDAL.Repository;
using ProductDAL.UnitOfWork;
using ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    public class TestHelper
    {
        public Mock<IProductUnitOfWork> _mockUnitOfwork { get; set; }
        public List<Product> _mockProductTable { get; set; }
        public List<ProductOption> _mockProductOptionsTable { get; set; }

        public void MockUnitOfWork()
        {
            _mockUnitOfwork = new Mock<IProductUnitOfWork>();
        }

        public void MockProductRepository()
        {
            _mockProductTable = new List<Product>();
            var mock = new Mock<IRepository<Product, Guid>>();
            mock.Setup(s => s.Find(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns<Expression<Func<Product, bool>>>(ex => _mockProductTable.Where(ex.Compile()));
            mock.Setup(s => s.Add(It.IsAny<Product>())).Callback<Product>(p => _mockProductTable.Add(p));
            mock.Setup(s => s.AddRange(It.IsAny<IEnumerable<Product>>()))
                .Callback<IEnumerable<Product>>(ps => _mockProductTable.AddRange(ps));
            mock.Setup(s => s.Get(It.IsAny<Guid>())).Returns<Guid>(id => _mockProductTable.Find(p => p.Id == id));
            mock.Setup(s => s.GetAll()).Returns(_mockProductTable);
            mock.Setup(s => s.Remove(It.IsAny<Product>())).Callback<Product>(p => _mockProductTable.Remove(p));
            mock.Setup(s => s.RemoveByKey(It.IsAny<Guid>())).Callback<Guid>(id => { var product = _mockProductTable.Find(p => p.Id == id); _mockProductTable.Remove(product); });
            mock.Setup(s => s.RemoveRange(It.IsAny<IEnumerable<Product>>()))
                .Callback<IEnumerable<Product>>(ps => _mockProductTable.RemoveAll(ps.Contains));
            mock.Setup(s => s.SingleOrDefault(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns<Expression<Func<Product, bool>>>(ex => _mockProductTable.Where(ex.Compile()).SingleOrDefault());
            _mockUnitOfwork.Setup(u => u.Products).Returns(mock.Object);
        }
        public void MockProductOptionRepository()
        {
            _mockProductOptionsTable = new List<ProductOption>();
            var mock = new Mock<IRepository<ProductOption, Guid>>();
            mock.Setup(s => s.Find(It.IsAny<Expression<Func<ProductOption, bool>>>()))
                .Returns<Expression<Func<ProductOption, bool>>>(ex => _mockProductOptionsTable.Where(ex.Compile()));
            mock.Setup(s => s.Add(It.IsAny<ProductOption>())).Callback<ProductOption>(p => _mockProductOptionsTable.Add(p));
            mock.Setup(s => s.AddRange(It.IsAny<IEnumerable<ProductOption>>()))
                .Callback<IEnumerable<ProductOption>>(ps => _mockProductOptionsTable.AddRange(ps));
            mock.Setup(s => s.Get(It.IsAny<Guid>())).Returns<Guid>(id => _mockProductOptionsTable.Find(p => p.Id == id));
            mock.Setup(s => s.GetAll()).Returns(_mockProductOptionsTable);
            mock.Setup(s => s.Remove(It.IsAny<ProductOption>())).Callback<ProductOption>(p => _mockProductOptionsTable.Remove(p));
            mock.Setup(s => s.RemoveByKey(It.IsAny<Guid>())).Callback<Guid>(id => { var product = _mockProductOptionsTable.Find(p => p.Id == id); _mockProductOptionsTable.Remove(product); });
            mock.Setup(s => s.RemoveRange(It.IsAny<IEnumerable<ProductOption>>()))
                .Callback<IEnumerable<ProductOption>>(ps => _mockProductOptionsTable.RemoveAll(ps.Contains));
            mock.Setup(s => s.SingleOrDefault(It.IsAny<Expression<Func<ProductOption, bool>>>()))
                .Returns<Expression<Func<ProductOption, bool>>>(ex => _mockProductOptionsTable.Where(ex.Compile()).SingleOrDefault());
            _mockUnitOfwork.Setup(u => u.ProductOptions).Returns(mock.Object);
        }
    }
}
