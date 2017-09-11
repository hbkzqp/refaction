using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductData;
using ProductServices.Implementation;
using ProductServices.Interface;
using ProductServices.Models;

namespace ServiceTest
{
    [TestClass]
    public class ProductOptionServiceTest 
    {
        private TestHelper _helper;
        private ProductOptionModel _testProductOptionModel;
        private ProductOptionModel _testProductOptionModel0;
        private ProductOption _testProductOption;
        private ProductOption _testProductOption0;
        private Product _testProduct;
        private IProductOptionService _testService;

        public ProductOptionServiceTest()
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

            _testProductOptionModel = new ProductOptionModel()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023DDDB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };
            _testProductOptionModel0 = new ProductOptionModel()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),

            };

            _testProductOption = new ProductOption()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023DDDB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };
            _testProductOption0 = new ProductOption()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };

            _testProduct = new Product()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,
                ProductOptions = new List<ProductOption>(),
            };

            _helper._mockProductTable.Add(_testProduct);
            _testService = new ProductOptionService(_helper._mockUnitOfwork.Object);
        }
        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestAddProductOptionService()
        {
            //Arrange
            _helper._mockProductOptionsTable.Clear();
            //Act
            _testService.AddOption(_testProduct.Id, _testProductOptionModel);
            //Assert
            Assert.IsTrue(_helper._mockProductOptionsTable.Exists(p => p.Id == _testProductOption.Id));
            Assert.IsTrue(_helper._mockProductOptionsTable.Exists(p => p.Description == _testProductOption.Description));
            Assert.IsTrue(_helper._mockProductOptionsTable.Exists(p => p.Name == _testProductOption.Name));
            Assert.IsTrue(_testProduct.ProductOptions.Any(p => p.Id == _testProductOption.Id));
            Assert.IsTrue(_testProduct.ProductOptions.Any(p => p.Description == _testProductOption.Description));
            Assert.IsTrue(_testProduct.ProductOptions.Any(p => p.Name == _testProductOption.Name));
        }

        /// </summary>
        [TestMethod]
        public void TestDeleteProductOptionService()
        {
            //Arrange
            _helper._mockProductOptionsTable.Clear();
            _helper._mockProductOptionsTable.Add(_testProductOption);
            _helper._mockProductOptionsTable.Add(_testProductOption0);
            //Act
            _testService.DeleteOption(_testProductOptionModel.Id);
            //Assert
            Assert.AreEqual(1, _helper._mockProductOptionsTable.Count);
            Assert.IsFalse(_helper._mockProductOptionsTable.Contains(_testProductOption));
        }

        [TestMethod]
        public void TestUpdateProductOptionService()
        {
            //Arrange
            _helper._mockProductOptionsTable.Clear();
            _helper._mockProductOptionsTable.Add(_testProductOption);
            _testProductOptionModel.Description = "manchester united!";
            _testProductOptionModel.Name = "JOSE Mourinho!";
            //Act
            _testService.UpdateOption(_testProductOptionModel.Id, _testProductOptionModel);
            //Assert
            Assert.AreEqual(_helper._mockProductOptionsTable.Find(p => p.Id == _testProductOption.Id).Description, "manchester united!");
            Assert.AreEqual(_helper._mockProductOptionsTable.Find(p => p.Id == _testProductOption.Id).Name, "JOSE Mourinho!");
        }
        [TestMethod]
        public void TestGetExactOptionService()
        {
            //Arrange
            _helper._mockProductOptionsTable.Clear();
            _helper._mockProductOptionsTable.Add(_testProductOption);
            //Act
            var result = _testService.GetExactOption(_testProduct.Id, _testProductOption.Id);
            //Assert
            Assert.AreEqual(result.Id, _testProductOption.Id);
            Assert.AreEqual(result.Description, _testProductOption.Description);
            Assert.AreEqual(result.Name, _testProductOption.Name);
            Assert.AreEqual(result.ProductId, _testProduct.Id);
        }


        [TestMethod]
        public void TestGetOptionsByProductIDService()
        {
            //Arrange
            _helper._mockProductOptionsTable.Clear();
            _helper._mockProductOptionsTable.Add(_testProductOption);
            _helper._mockProductOptionsTable.Add(_testProductOption0);
            //Act
            var result = _testService.GetOptionsByProductID(_testProduct.Id);
            //Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(p => p.Id == _testProductOption.Id));
            Assert.IsTrue(result.Any(p => p.ProductId == _testProduct.Id));
            Assert.IsTrue(result.Any(p => p.Description == _testProductOption.Description));
            Assert.IsTrue(result.Any(p => p.Name == _testProductOption.Name));
            Assert.IsTrue(result.Any(p => p.Id == _testProductOption0.Id));
            Assert.IsTrue(result.Any(p => p.ProductId == _testProduct.Id));
            Assert.IsTrue(result.Any(p => p.Description == _testProductOption0.Description));
            Assert.IsTrue(result.Any(p => p.Name == _testProductOption0.Name));
        }

    }
}
