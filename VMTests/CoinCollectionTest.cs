using System;
using System.Diagnostics;
using System.Security.Cryptography;
using VMDemo;
using static VMDemo.Constants;

namespace VMTests
{
    public class CoinCollectionTest
    {
        CoinCollection _coinCollection;
        public CoinCollectionTest()
        {
            _coinCollection = new CoinCollection();
        }

        [Fact]
        public void InsertCoinToDictionary_ReturnsSuccess_When_CoinIsAddedToDictionary()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 4;

            //Act
            _coinCollection.InsertCoinToDictionary(coin, num);            
            int coinValue = _coinCollection.GetCoinValueFromDictionary(coin);

            //Assert
            Assert.True(coinValue > 0);
        }

        [Fact]
        public void InsertCoinToDictionary_ReturnsSuccess_When_CoinValueUpdatedInDictionary()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num1 = 4;
            int num2 = 2;

            //Act
            _coinCollection.InsertCoinToDictionary(coin, num1);
            _coinCollection.InsertCoinToDictionary(coin, num2);

            int coinValue = _coinCollection.GetCoinValueFromDictionary(coin);
            int totalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.Equal(coinValue, totalBalance);
        }                     

        [Fact]
        public void UpdateCoinBalance_VerifyBalance_When_ProductDespensedSuccessfully()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 5;

            var coin1 = Coin.Dime;
            int num1 = 5;

            var coin2 = Coin.Nickel;
            int num2 = 5;

            int productPrice = Product.Cola.GetProductValue();

            //Act
            _coinCollection.InsertCoinToDictionary(coin, num);
            _coinCollection.InsertCoinToDictionary(coin1, num1);
            _coinCollection.InsertCoinToDictionary(coin2, num2);

            int totalBalance = _coinCollection.GetTotalBalance();

            _coinCollection.UpdateCoinBalance(productPrice);

            int remainingBalance = totalBalance - productPrice;
            int updatedTotalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.Equal(remainingBalance, updatedTotalBalance);
        }
    }
}