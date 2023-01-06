using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using static VMDemo.Constants;

namespace VMDemo
{
    public class CoinCollection
    {
        MemoryCacheService _memoryCacheService; 

        public CoinCollection(MemoryCacheService memoryCacheService)
        {
            _memoryCacheService= memoryCacheService;
        }
        public void InsertCoinToMemory(Coin coin, int num)
        {
            string strCoin = coin.ToString();
            int coinValue = num * coin.GetValue();

            if (_memoryCacheService.IsExists(strCoin))
            {
                var cacheCoinValue = _memoryCacheService.GetCacheItem(strCoin);
                coinValue += (int)cacheCoinValue;
                var cacheItem = new CacheItem(strCoin, coinValue);
                _memoryCacheService.SetCacheItem(cacheItem);
            }
            else
            {
                var cacheItem = new CacheItem(strCoin, coinValue);
                _memoryCacheService.Insert(cacheItem);
            }
        }

        public int GetTotalBalance()
        {
            int quarterValue = GetCoinValueFromCache(Coin.Quarter);
            int dimeValue = GetCoinValueFromCache(Coin.Dime);
            int nickelValue = GetCoinValueFromCache(Coin.Nickel);
            int totalBalance = quarterValue + dimeValue + nickelValue;
            return totalBalance;
        }

        public int GetCoinValueFromCache(Coin coin)
        {
            int coinValue = 0;
            if (_memoryCacheService.IsExists(coin.ToString()))
            {
                coinValue = (int)_memoryCacheService.GetCacheItem(coin.ToString());
            }
            return coinValue;
        }

        public void UpdateCoinBalance(int productPrice)
        {
            int totalBalance = GetTotalBalance();

            if (totalBalance >= productPrice)
            {
                int quarterBalance = DispenseCoinCalculation(Coin.Quarter, productPrice);
                productPrice = quarterBalance;
            }
            if (productPrice > 0)
            {
                int dimeBalance = DispenseCoinCalculation(Coin.Dime, productPrice);
                productPrice = dimeBalance;
            }
            if (productPrice > 0)
            {
                DispenseCoinCalculation(Coin.Nickel, productPrice);
            }
        }

        private int DispenseCoinCalculation(Coin coin, int productPrice)
        {
            if (productPrice == 0) return 0;
            int coinValue = GetCoinValueFromCache(coin);
            if (coinValue == 0) return productPrice;

            if(coinValue >= productPrice)
            {
                coinValue -= productPrice;
                if (coinValue == 0)
                {
                    _memoryCacheService.Remove(coin.ToString());
                }
                else
                {
                    var cacheItem = new CacheItem(coin.ToString(), coinValue);
                    _memoryCacheService.SetCacheItem(cacheItem);
                    coinValue = 0;
                }
            }
            else 
            {
                _memoryCacheService.Remove(coin.ToString());
                coinValue = productPrice - coinValue;
            }
            return coinValue;
        }
    }
}
