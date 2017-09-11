using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ProductData;
using ProductServices.Implementation;
using ProductServices.Interface;
using ProductServices.Models;

namespace ServiceTest
{
    [TestClass]
    public class ProductServiceTest 
    {
        private ProductModel _testProductModel;
        private ProductModel _testProductModel0;
        private Product _testProduct;
        private Product _testProduct0;
        private IProductService _testService;
        private TestHelper _helper;
        public ProductServiceTest()
        {
            InitMock();
            ConfigTest();
        }
        private void InitMock()
        {
            _helper = new TestHelper();
            _helper.MockUnitOfWork();
            _helper.MockProductRepository();
            _helper.MockProductOptionRepository();
        }
        protected void ConfigTest()
        {

            _testProductModel = new ProductModel()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,

            };
            _testProductModel0 = new ProductModel()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                Price = 1.1m,
                DeliveryPrice = 2.2m,

            };

            _testProduct = new Product()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,

            };
            _testProduct0 = new Product()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                Price = 1.1m,
                DeliveryPrice = 2.2m,

            };
            _testService = new ProductService(_helper._mockUnitOfwork.Object);
        }
        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestAddProductService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            //Act
            _testService.AddProduct(_testProductModel);
            //Assert
            Assert.IsTrue(_helper._mockProductTable.Exists(p => p.Id == _testProduct.Id));
            Assert.IsTrue(_helper._mockProductTable.Exists(p => p.DeliveryPrice == _testProduct.DeliveryPrice));
            Assert.IsTrue(_helper._mockProductTable.Exists(p => p.Description == _testProduct.Description));
            Assert.IsTrue(_helper._mockProductTable.Exists(p => p.Name == _testProduct.Name));
            Assert.IsTrue(_helper._mockProductTable.Exists(p => p.Price == _testProduct.Price));
        }

        /// </summary>
        [TestMethod]
        public void TestDeleteProductService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            _helper._mockProductTable.Add(_testProduct);
            _helper._mockProductTable.Add(_testProduct0);
            //Act
            _testService.DeleteProduct(_testProductModel.Id);
            //Assert
            Assert.AreEqual(1, _helper._mockProductTable.Count);
            Assert.IsFalse(_helper._mockProductTable.Contains(_testProduct));
        }

        [TestMethod]
        public void TestUpdateProductService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            _helper._mockProductTable.Add(_testProduct);
            _testProductModel.Description = "manchester united!";
            _testProductModel.Name = "JOSE Mourinho!";
            //Act
            _testService.UpdateProduct(_testProductModel.Id, _testProductModel);
            //Assert
            Assert.AreEqual(_helper._mockProductTable.Find(p => p.Id == _testProduct.Id).Description, "manchester united!");
            Assert.AreEqual(_helper._mockProductTable.Find(p => p.Id == _testProduct.Id).Name, "JOSE Mourinho!");
        }
        [TestMethod]
        public void TestFindProductByIDService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            _helper._mockProductTable.Add(_testProduct);
            //Act
            var result = _testService.FindProductByID(_testProduct.Id);
            //Assert
            Assert.AreEqual(result.Id, _testProduct.Id);
            Assert.AreEqual(result.Description, _testProduct.Description);
            Assert.AreEqual(result.Name, _testProduct.Name);
            Assert.AreEqual(result.Price, _testProduct.Price);
            Assert.AreEqual(result.DeliveryPrice, _testProduct.DeliveryPrice);
        }

        [TestMethod]
        public void TestFindProductByNameService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            _helper._mockProductTable.Add(_testProduct);
            //Act
            var result = _testService.FindProductByName(_testProduct.Name);
            //Assert
            Assert.AreEqual(result.Id, _testProduct.Id);
            Assert.AreEqual(result.Description, _testProduct.Description);
            Assert.AreEqual(result.Name, _testProduct.Name);
            Assert.AreEqual(result.Price, _testProduct.Price);
            Assert.AreEqual(result.DeliveryPrice, _testProduct.DeliveryPrice);
        }

        [TestMethod]
        public void TestGetAllProductService()
        {
            //Arrange
            _helper._mockProductTable.Clear();
            _helper._mockProductTable.Add(_testProduct);
            _helper._mockProductTable.Add(_testProduct0);
            //Act
            var result = _testService.GetAllProduct();
            //Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(p => p.Id == _testProduct.Id));
            Assert.IsTrue(result.Any(p => p.DeliveryPrice == _testProduct.DeliveryPrice));
            Assert.IsTrue(result.Any(p => p.Description == _testProduct.Description));
            Assert.IsTrue(result.Any(p => p.Name == _testProduct.Name));
            Assert.IsTrue(result.Any(p => p.Price == _testProduct.Price));
            Assert.IsTrue(result.Any(p => p.Id == _testProduct0.Id));
            Assert.IsTrue(result.Any(p => p.DeliveryPrice == _testProduct0.DeliveryPrice));
            Assert.IsTrue(result.Any(p => p.Description == _testProduct0.Description));
            Assert.IsTrue(result.Any(p => p.Name == _testProduct0.Name));
            Assert.IsTrue(result.Any(p => p.Price == _testProduct0.Price));
        }


    }
}
