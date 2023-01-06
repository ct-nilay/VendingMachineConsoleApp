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
        MemoryCacheService _memoryCacheService;
        public CoinCollectionTest()
        {
            _memoryCacheService = new MemoryCacheService();
            _coinCollection = new CoinCollection(_memoryCacheService);
        }

        [Fact]
        public void InsertCoinToMemory_ReturnsSuccess_When_ThereIsNoCacheItemAdded()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 4;

            //Act
            _coinCollection.InsertCoinToMemory(coin, num);
            bool isAdded = _memoryCacheService.IsExists(coin.ToString());

            //Assert
            Assert.True(isAdded);
        }

        [Fact]
        public void InsertCoinToMemory_ReturnsSuccess_When_CacheItemUpdated()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num1 = 4;
            int num2 = 2;

            //Act
            _coinCollection.InsertCoinToMemory(coin, num1);
            _coinCollection.InsertCoinToMemory(coin, num2);

            var cacheItemValue = _memoryCacheService.GetCacheItem(coin.ToString());
            int totalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.Equal(cacheItemValue, totalBalance);
        }

        [Fact]
        public void GetTotalBalance_ReturnsZero_When_NoCoinIsAdded()
        {
            //Arrange

            //Act
            int totalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.Equal(0, totalBalance);
        }

        [Fact]
        public void GetTotalBalance_ReturnsBalance_When_CoinIsAdded()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 4;

            //Act
            _coinCollection.InsertCoinToMemory(coin, num);
            int totalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.True(totalBalance > 0);
        }

        [Fact]
        public void GetCoinValueFromCache_ReturnsZero_When_NoCoinIsAddedInCache()
        {
            //Arrange
            var coin = Coin.Dime;

            //Act
            int coinValue = _coinCollection.GetCoinValueFromCache(coin);

            //Assert
            Assert.Equal(0, coinValue);
        }

        [Fact]
        public void GetCoinValueFromCache_ReturnsCacheValue_When_CoinIsAddedInCache()
        {
            //Arrange
            var coin = Coin.Dime;
            int num = 5;

            //Act
            _coinCollection.InsertCoinToMemory(coin, num);
            int returnCountValue = _coinCollection.GetCoinValueFromCache(coin);
            int compareCountValue = (int)_memoryCacheService.GetCacheItem(coin.ToString());
            //Assert
            Assert.Equal(compareCountValue, returnCountValue);
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

            int productPrice = Product.Cola.GetProductPrice();

            //Act
            _coinCollection.InsertCoinToMemory(coin, num);
            _coinCollection.InsertCoinToMemory(coin1, num1);
            _coinCollection.InsertCoinToMemory(coin2, num2);

            int totalBalance = _coinCollection.GetTotalBalance();

            _coinCollection.UpdateCoinBalance(productPrice);

            int remainingBalance = totalBalance - productPrice;
            int updatedTotalBalance = _coinCollection.GetTotalBalance();

            //Assert
            Assert.Equal(remainingBalance, updatedTotalBalance);
        }
    }
}