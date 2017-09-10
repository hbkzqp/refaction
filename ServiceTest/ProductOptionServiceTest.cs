using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductData;
using ProductServices.Implementation;
using ProductServices.Interface;
using ProductServices.Models;

namespace ServiceTest
{
    [TestClass]
    public class ProductOptionServiceTest : BaseTest
    {
        private ProductOptionModel _testProductOptionModel;
        private ProductOptionModel _testProductOptionModel0;
        private ProductOption _testProductOption;
        private ProductOption _testProductOption0;
        private Product _testProduct;
        private IProductOptionService _testService;

        public ProductOptionServiceTest()
        {
            this.ConfigTest();
        }
        protected void ConfigTest()
        {

            this._testProductOptionModel = new ProductOptionModel()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023DDDB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };
            this._testProductOptionModel0 = new ProductOptionModel()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),

            };

            this._testProductOption = new ProductOption()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023DDDB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };
            this._testProductOption0 = new ProductOption()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                ProductId = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
            };

            this._testProduct = new Product()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,
                ProductOptions = new List<ProductOption>(),
            };

            this._mockProductTable.Add(this._testProduct);
            this._testService = new ProductOptionService(this._mockUnitOfwork.Object);
        }
        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestAddProductOption()
        {
            //Arrange
            this._mockProductOptionsTable.Clear();
            //Act
            this._testService.AddOption(this._testProduct.Id, this._testProductOptionModel);
            //Assert
            Assert.IsTrue(this._mockProductOptionsTable.Exists(p => p.Id == this._testProductOption.Id));
            Assert.IsTrue(this._mockProductOptionsTable.Exists(p => p.Description == this._testProductOption.Description));
            Assert.IsTrue(this._mockProductOptionsTable.Exists(p => p.Name == this._testProductOption.Name));
            Assert.IsTrue(this._testProduct.ProductOptions.Any(p => p.Id == this._testProductOption.Id));
            Assert.IsTrue(this._testProduct.ProductOptions.Any(p => p.Description == this._testProductOption.Description));
            Assert.IsTrue(this._testProduct.ProductOptions.Any(p => p.Name == this._testProductOption.Name));
        }

        /// </summary>
        [TestMethod]
        public void TestDeleteProductOption()
        {
            //Arrange
            this._mockProductOptionsTable.Clear();
            this._mockProductOptionsTable.Add(this._testProductOption);
            this._mockProductOptionsTable.Add(this._testProductOption0);
            //Act
            this._testService.DeleteOption(this._testProductOptionModel.Id);
            //Assert
            Assert.AreEqual(1, this._mockProductOptionsTable.Count);
            Assert.IsFalse(this._mockProductOptionsTable.Contains(this._testProductOption));
        }

        [TestMethod]
        public void TestUpdateProductOption()
        {
            //Arrange
            this._mockProductOptionsTable.Clear();
            this._mockProductOptionsTable.Add(this._testProductOption);
            this._testProductOptionModel.Description = "manchester united!";
            this._testProductOptionModel.Name = "JOSE Mourinho!";
            //Act
            this._testService.UpdateOption(this._testProductOptionModel.Id, this._testProductOptionModel);
            //Assert
            Assert.AreEqual(this._mockProductOptionsTable.Find(p => p.Id == this._testProductOption.Id).Description, "manchester united!");
            Assert.AreEqual(this._mockProductOptionsTable.Find(p => p.Id == this._testProductOption.Id).Name, "JOSE Mourinho!");
        }
        [TestMethod]
        public void TestGetExactOption()
        {
            //Arrange
            this._mockProductOptionsTable.Clear();
            this._mockProductOptionsTable.Add(this._testProductOption);
            //Act
            var result = this._testService.GetExactOption(this._testProduct.Id, this._testProductOption.Id);
            //Assert
            Assert.AreEqual(result.Id, this._testProductOption.Id);
            Assert.AreEqual(result.Description, this._testProductOption.Description);
            Assert.AreEqual(result.Name, this._testProductOption.Name);
            Assert.AreEqual(result.ProductId, this._testProduct.Id);
        }


        [TestMethod]
        public void TestGetOptionsByProductID()
        {
            //Arrange
            this._mockProductOptionsTable.Clear();
            this._mockProductOptionsTable.Add(this._testProductOption);
            this._mockProductOptionsTable.Add(this._testProductOption0);
            //Act
            var result = this._testService.GetOptionsByProductID(this._testProduct.Id);
            //Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(p => p.Id == this._testProductOption.Id));
            Assert.IsTrue(result.Any(p => p.ProductId == this._testProduct.Id));
            Assert.IsTrue(result.Any(p => p.Description == this._testProductOption.Description));
            Assert.IsTrue(result.Any(p => p.Name == this._testProductOption.Name));
            Assert.IsTrue(result.Any(p => p.Id == this._testProductOption0.Id));
            Assert.IsTrue(result.Any(p => p.ProductId == this._testProduct.Id));
            Assert.IsTrue(result.Any(p => p.Description == this._testProductOption0.Description));
            Assert.IsTrue(result.Any(p => p.Name == this._testProductOption0.Name));
        }

    }
}
