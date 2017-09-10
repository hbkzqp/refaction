using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProductData;
using ProductServices.Implementation;
using ProductServices.Interface;
using ProductServices.Models;
using ProductDAL.UnitOfWork;

namespace ServiceTest
{
    [TestClass]
    public class ProductServiceTest : BaseTest
    {
        private ProductModel _testProductModel;
        private ProductModel _testProductModel0;
        private Product _testProduct;
        private Product _testProduct0;
        private IProductService _testService;

        public ProductServiceTest()
        {
            this.ConfigTest();
        }
        protected void ConfigTest()
        {

            this._testProductModel = new ProductModel()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,

            };
            this._testProductModel0 = new ProductModel()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                Price = 1.1m,
                DeliveryPrice = 2.2m,

            };

            this._testProduct = new Product()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,

            };
            this._testProduct0 = new Product()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                Price = 1.1m,
                DeliveryPrice = 2.2m,

            };
            this._testService = new ProductService(this._mockUnitOfwork.Object);
        }
        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestAddProduct()
        {
            //Arrange
            this._mockProductTable.Clear();
            //Act
            this._testService.AddProduct(this._testProductModel);
            //Assert
            Assert.IsTrue(this._mockProductTable.Exists(p => p.Id == this._testProduct.Id));
            Assert.IsTrue(this._mockProductTable.Exists(p => p.DeliveryPrice == this._testProduct.DeliveryPrice));
            Assert.IsTrue(this._mockProductTable.Exists(p => p.Description == this._testProduct.Description));
            Assert.IsTrue(this._mockProductTable.Exists(p => p.Name == this._testProduct.Name));
            Assert.IsTrue(this._mockProductTable.Exists(p => p.Price == this._testProduct.Price));
        }

        /// </summary>
        [TestMethod]
        public void TestDeleteProduct()
        {
            //Arrange
            this._mockProductTable.Clear();
            this._mockProductTable.Add(this._testProduct);
            this._mockProductTable.Add(this._testProduct0);
            //Act
            this._testService.DeleteProduct(this._testProductModel.Id);
            //Assert
            Assert.AreEqual(1, this._mockProductTable.Count);
            Assert.IsFalse(this._mockProductTable.Contains(this._testProduct));
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            //Arrange
            this._mockProductTable.Clear();
            this._mockProductTable.Add(this._testProduct);
            this._testProductModel.Description = "manchester united!";
            this._testProductModel.Name = "JOSE Mourinho!";
            //Act
            this._testService.UpdateProduct(this._testProductModel.Id, this._testProductModel);
            //Assert
            Assert.AreEqual(this._mockProductTable.Find(p => p.Id == this._testProduct.Id).Description, "manchester united!");
            Assert.AreEqual(this._mockProductTable.Find(p => p.Id == this._testProduct.Id).Name, "JOSE Mourinho!");
        }
        [TestMethod]
        public void TestFindProductByID()
        {
            //Arrange
            this._mockProductTable.Clear();
            this._mockProductTable.Add(this._testProduct);
            //Act
            var result = this._testService.FindProductByID(this._testProduct.Id);
            //Assert
            Assert.AreEqual(result.Id, this._testProduct.Id);
            Assert.AreEqual(result.Description, this._testProduct.Description);
            Assert.AreEqual(result.Name, this._testProduct.Name);
            Assert.AreEqual(result.Price, this._testProduct.Price);
            Assert.AreEqual(result.DeliveryPrice, this._testProduct.DeliveryPrice);
        }

        [TestMethod]
        public void TestFindProductByName()
        {
            //Arrange
            this._mockProductTable.Clear();
            this._mockProductTable.Add(this._testProduct);
            //Act
            var result = this._testService.FindProductByName(this._testProduct.Name);
            //Assert
            Assert.AreEqual(result.Id, this._testProduct.Id);
            Assert.AreEqual(result.Description, this._testProduct.Description);
            Assert.AreEqual(result.Name, this._testProduct.Name);
            Assert.AreEqual(result.Price, this._testProduct.Price);
            Assert.AreEqual(result.DeliveryPrice, this._testProduct.DeliveryPrice);
        }

        [TestMethod]
        public void TestGetAllProduct()
        {
            //Arrange
            this._mockProductTable.Clear();
            this._mockProductTable.Add(this._testProduct);
            this._mockProductTable.Add(this._testProduct0);
            //Act
            var result = this._testService.GetAllProduct();
            //Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(p => p.Id == this._testProduct.Id));
            Assert.IsTrue(result.Any(p => p.DeliveryPrice == this._testProduct.DeliveryPrice));
            Assert.IsTrue(result.Any(p => p.Description == this._testProduct.Description));
            Assert.IsTrue(result.Any(p => p.Name == this._testProduct.Name));
            Assert.IsTrue(result.Any(p => p.Price == this._testProduct.Price));
            Assert.IsTrue(result.Any(p => p.Id == this._testProduct0.Id));
            Assert.IsTrue(result.Any(p => p.DeliveryPrice == this._testProduct0.DeliveryPrice));
            Assert.IsTrue(result.Any(p => p.Description == this._testProduct0.Description));
            Assert.IsTrue(result.Any(p => p.Name == this._testProduct0.Name));
            Assert.IsTrue(result.Any(p => p.Price == this._testProduct0.Price));
        }


    }
}
