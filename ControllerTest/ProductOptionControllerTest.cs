using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Controllers;

namespace ControllerTest
{
    [TestClass]
    public class ProductOptionControllerTest : BaseTest
    {
        private Mock<IProductOptionService> _mockService;
        private ProductOptionsController _testController;

        protected override void ConfigTest()
        {
            var mock = new Mock<IProductOptionService>();
            this._mockService = mock;
            this._testController = new ProductOptionsController(this._mockService.Object);
        }

        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestCreateOption()
        {
            //Arrange

            //Act
            this._testController.CreateOption(new Guid(), new ProductOptionModel());
            //Assert
            this._mockService.Verify(s => s.AddOption(It.IsAny<Guid>(), It.IsAny<ProductOptionModel>()));


        }

        [TestMethod]
        public void TestDeleteOption()
        {
            //Arrange

            //Act
            this._testController.DeleteOption(new Guid());
            //Assert
            this._mockService.Verify(s => s.DeleteOption(It.IsAny<Guid>()));

        }
        [TestMethod]
        public void TestGetOption()
        {
            //Arrange

            //Act
            var result = this._testController.GetOption(new Guid(), new Guid());

            //Assert
            this._mockService.Verify(s => s.GetExactOption(It.IsAny<Guid>(), It.IsAny<Guid>()));
        }


        [TestMethod]
        public void TestGetOptions()
        {
            //Arrange

            //Act
            var results = this._testController.GetOptions(new Guid());
            //Assert

            this._mockService.Verify(s => s.GetOptionsByProductID(It.IsAny<Guid>()));

        }
        [TestMethod]
        public void TestUpdateOption()
        {
            //Arrange


            //Act
            this._testController.UpdateOption(new Guid(), new ProductOptionModel());
            //Assert
            this._mockService.Verify(s => s.UpdateOption(It.IsAny<Guid>(), It.IsAny<ProductOptionModel>()));
        }

    }
}
