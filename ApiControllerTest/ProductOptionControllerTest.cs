using System;
using ApiControllerTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductServices.Interface;
using ProductServices.Models;
using refactor_me.Controllers;

namespace ApiControllerTest
{
    /// <summary>
    /// Test class for ProductOptionController 
    /// </summary>
    [TestClass]
    public class ProductOptionControllerTest : BaseTest
    {
        private Mock<IProductOptionService> _mockService;
        private ProductOptionsController _testController;

        protected override void ConfigTest()
        {
            var mock = new Mock<IProductOptionService>();
            _mockService = mock;
            _testController = new ProductOptionsController(_mockService.Object);
        }

        /// <summary>
        ///Test For 
        /// </summary>
        [TestMethod]
        public void TestCreateOption()
        {
            //Arrange

            //Act
            _testController.CreateOption(new Guid(), new ProductOptionModel());
            //Assert
            _mockService.Verify(s => s.AddOption(It.IsAny<Guid>(), It.IsAny<ProductOptionModel>()));


        }

        [TestMethod]
        public void TestDeleteOption()
        {
            //Arrange

            //Act
            _testController.DeleteOption(new Guid());
            //Assert
            _mockService.Verify(s => s.DeleteOption(It.IsAny<Guid>()));

        }
        [TestMethod]
        public void TestGetOption()
        {
            //Arrange

            //Act
            var result = _testController.GetOption(new Guid(), new Guid());

            //Assert
            _mockService.Verify(s => s.GetExactOption(It.IsAny<Guid>(), It.IsAny<Guid>()));
        }


        [TestMethod]
        public void TestGetOptions()
        {
            //Arrange

            //Act
            var results = _testController.GetOptions(new Guid());
            //Assert

            _mockService.Verify(s => s.GetOptionsByProductID(It.IsAny<Guid>()));

        }
        [TestMethod]
        public void TestUpdateOption()
        {
            //Arrange


            //Act
            _testController.UpdateOption(new Guid(), new ProductOptionModel());
            //Assert
            _mockService.Verify(s => s.UpdateOption(It.IsAny<Guid>(), It.IsAny<ProductOptionModel>()));
        }

    }
}
