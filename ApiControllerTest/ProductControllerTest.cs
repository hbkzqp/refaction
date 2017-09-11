using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductServices.Interface;
using Moq;
using ProductServices.Models;
using System.Collections.Generic;
using ApiControllerTest;
using refactor_me.Controllers;

namespace ApiControllerTest
{
    /// <summary>
    /// Test class for ProductController 
    /// </summary>
    [TestClass]
    public class ProductControllerTest : BaseTest
    {
        private Mock<IProductService> _mockService;
        private ProductModel _testProduct;
        private ProductModel _testProduct0;
        private ProductsController _testController;

        private void MockService()
        {
            var mock = new Mock<IProductService>();
            this._mockService = mock;
        }
        protected override void ConfigTest()
        {
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

            //Act
            this._testController.Create(this._testProduct);
            //Assert
            this._mockService.Verify(s => s.AddProduct(It.IsAny<ProductModel>()));
        }

        [TestMethod]
        public void TestDeleteProuct()
        {
            //Arrange
            //Act
            this._testController.Delete(this._testProduct.Id);
            //Assert
            this._mockService.Verify(s => s.DeleteProduct(It.IsAny<Guid>()));

        }
        [TestMethod]
        public void TestFindProductByID()
        {
            //Arrange
            //Act
            var result = this._testController.GetProduct(this._testProduct.Id);
            var result0 = this._testController.GetProduct(this._testProduct0.Id);
            //Assert
            this._mockService.Verify(s => s.FindProductByID(It.IsAny<Guid>()));
        }

        [TestMethod]
        public void TestFindProductByName()
        {
            //Arrange
            //Act
            var result = this._testController.SearchByName(this._testProduct.Name);
            var result0 = this._testController.SearchByName(this._testProduct0.Name);
            //Assert
            this._mockService.Verify(s => s.FindProductByName(It.IsAny<string>()), Times.Exactly(2));
        }
        [TestMethod]
        public void TestGetAllProduct()
        {
            //Arrange
            //Act
            var results = this._testController.GetAll().Items as List<ProductModel>;
            //Assert

            this._mockService.Verify(s => s.GetAllProduct());
        }
        [TestMethod]
        public void TestUpdateProduct()
        {
            //Arrange

            //Act
            this._testController.Update(this._testProduct.Id, this._testProduct0);
            //Assert
            this._mockService.Verify(s => s.UpdateProduct(It.IsAny<Guid>(), It.IsAny<ProductModel>()));
        }

    }
}
