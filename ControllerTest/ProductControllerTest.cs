using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductServices.Interface;
using Moq;
using ProductServices.Models;
using System.Collections.Generic;
using refactor_me.Controllers;

namespace ControllerTest
{
    [TestClass]
    public class ProductControllerTest : BaseTest
    {
        private Mock<IProductService> _mockService;
        private List<ProductModel> _mockDatabase;
        private ProductModel _testProduct;
        private ProductModel _testProduct0;
        private ProductsController _testController;

        private void MockService()
        {
            var mock = new Mock<IProductService>();
            mock.Setup(s => s.AddProduct(It.IsAny<ProductModel>())).Callback<ProductModel>(p => this._mockDatabase.Add(p));
            mock.Setup(s => s.DeleteProduct(It.IsAny<Guid>())).Callback<Guid>(id => { var product = this._mockDatabase.Find(p => p.Id == id); this._mockDatabase.Remove(product); });
            mock.Setup(s => s.FindProductByID(It.IsAny<Guid>())).Returns<Guid>(id => this._mockDatabase.Find(p => p.Id == id));
            mock.Setup(s => s.FindProductByName(It.IsAny<string>())).Returns<string>(str => this._mockDatabase.Find(p => p.Name == str));
            mock.Setup(s => s.GetAllProduct()).Returns(this._mockDatabase);
            mock.Setup(s => s.UpdateProduct(It.IsAny<Guid>(), It.IsAny<ProductModel>())).Callback<Guid, ProductModel>((id, p) => { var product = this._mockDatabase.Find(pm => pm.Id == id); product.Name = p.Name; });
            this._mockService = mock;
        }
        protected override void ConfigTest()
        {
            this._mockDatabase = new List<ProductModel>();
            MockService();
            this._testProduct = new ProductModel()
            {
                Id = new Guid("8F2E0176-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName",
                Description = "TestDescription",
                Price = 1.01m,
                DeliveryPrice = 2.02m,

            };
            this._testProduct0 = new ProductModel()
            {
                Id = new Guid("8F2E0175-35EE-4F0A-AE55-83023D2DB1A3"),
                Name = "TestName0",
                Description = "TestDescription0",
                Price = 1.1m,
                DeliveryPrice = 2.2m,

            };
            this._testController = new ProductsController(this._mockService.Object);
        }

        [TestMethod]
        public void TestAddProduct()
        {
            //Arrange
            this._mockDatabase.Clear();
            //Act
            this._testController.Create(this._testProduct);
            //Assert
            this._mockService.Verify(s => s.AddProduct(It.IsAny<ProductModel>()));
            Assert.IsTrue(this._mockDatabase.Contains(this._testProduct));

        }

        [TestMethod]
        public void TestDeleteProuct()
        {
            //Arrange
            this._mockDatabase.Clear();
            this._mockDatabase.Add(this._testProduct);
            //Act
            this._testController.Delete(this._testProduct.Id);
            //Assert
            this._mockService.Verify(s => s.DeleteProduct(It.IsAny<Guid>()));
            Assert.IsFalse(this._mockDatabase.Contains(this._testProduct));

        }
        [TestMethod]
        public void TestFindProductByID()
        {
            //Arrange
            this._mockDatabase.Clear();
            this._mockDatabase.Add(this._testProduct);
            this._mockDatabase.Add(this._testProduct0);
            //Act
            var result = this._testController.GetProduct(this._testProduct.Id);
            var result0 = this._testController.GetProduct(this._testProduct0.Id);
            //Assert
            this._mockService.Verify(s => s.FindProductByID(It.IsAny<Guid>()));
            Assert.AreEqual(this._testProduct, result);
            Assert.AreEqual(this._testProduct0, result0);
        }

        [TestMethod]
        public void TestFindProductByName()
        {
            //Arrange
            this._mockDatabase.Clear();
            this._mockDatabase.Add(this._testProduct);
            this._mockDatabase.Add(this._testProduct0);
            //Act
            var result = this._testController.SearchByName(this._testProduct.Name);
            var result0 = this._testController.SearchByName(this._testProduct0.Name);
            //Assert
            this._mockService.Verify(s => s.FindProductByName(It.IsAny<string>()), Times.Exactly(2));
            Assert.AreEqual(this._testProduct, result);
            Assert.AreEqual(this._testProduct0, result0);
        }
        [TestMethod]
        public void TestGetAllProduct()
        {
            //Arrange
            this._mockDatabase.Clear();
            this._mockDatabase.Add(this._testProduct);
            this._mockDatabase.Add(this._testProduct0);
            //Act
            var results = this._testController.GetAll() as List<ProductModel>;
            //Assert

            this._mockService.Verify(s => s.GetAllProduct());
            Assert.IsTrue(results.Contains(this._testProduct));
            Assert.IsTrue(results.Contains(this._testProduct0));
            Assert.AreEqual(2, results.Count);
        }
        [TestMethod]
        public void TestUpdateProduct()
        {
            //Arrange
            this._mockDatabase.Clear();
            this._mockDatabase.Add(this._testProduct);

            //Act
            this._testController.Update(this._testProduct.Id, this._testProduct0);
            //Assert
            this._mockService.Verify(s => s.UpdateProduct(It.IsAny<Guid>(), It.IsAny<ProductModel>()));
            Assert.IsTrue(this._mockDatabase.Exists(p => p.Name == this._testProduct0.Name));
        }

    }
}
