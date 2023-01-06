using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using VMDemo;
using static VMDemo.Constants;

namespace VMTests
{
    public class UserInputProcessTest
    {
        UserInputProcess _userInputProcess = new UserInputProcess();

        [Fact]
        public void HandleCoinSelection_ReturnsFalse_When_InvalidCoinInput()
        {
            //Arrange
            var coin = "5";
            var stringReader = new StringReader(coin);
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleCoinSelection();

            //Assert
            Assert.False(isValid);
        }
        
        [Fact]
        public void HandleCoinSelection_ReturnsTrue_When_ValidInputCoin()
        {
            //Arrange
            var coin = "2";
            var stringReader = new StringReader(coin);
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleCoinSelection();

            //Assert
            Assert.True(isValid);
        }
        [Fact]
        public void HandleNumberOfCoinsInput_ReturnsFalse_When_NumberOfCoinsIsZero()
        {
            //Arrange
            var numOfCoin = "0";
            var stringReader = new StringReader(numOfCoin);
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleNumberOfCoinsInput();

            //Assert
            Assert.False(isValid);
        }
        [Fact]
        public void HandleNumberOfCoinsInput_ReturnsTrue_When_ValidNumberOfCoins()
        {
            //Arrange
            var coin = "7";
            var stringReader = new StringReader(coin);
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleNumberOfCoinsInput();

            //Assert
            Assert.True(isValid);
        }
        [Fact]
        public void HandleProductSelection_ReturnsFalse_When_InvalidProduct()
        {
            //Arrange
            var product = "4";
            var stringReader = new StringReader(product.ToString());
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleProductSelection();

            //Assert
            Assert.False(isValid);
        }
        [Fact]
        public void HandleProductSelection_ReturnsTrue_When_ValidProduct()
        {
            //Arrange
            var product = "3";
            var stringReader = new StringReader(product.ToString());
            Console.SetIn(stringReader);
            //Act
            bool isValid = _userInputProcess.HandleProductSelection();

            //Assert
            Assert.True(isValid);
        }
    }
}