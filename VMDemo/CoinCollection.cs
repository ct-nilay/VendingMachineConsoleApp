using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VMDemo.Constants;

namespace VMDemo
{
    public class CoinCollection
    {
        public Dictionary<Coin, int> dictionaryCoin = new Dictionary<Coin, int>();

        public void InsertCoinToDictionary(Coin coin, int numberOfCoins)
        {
            int coinValue = numberOfCoins * coin.GetCoinValue();

            if (dictionaryCoin.ContainsKey(coin))
            {
                
                coinValue += GetCoinValueFromDictionary(coin);
                dictionaryCoin[coin] = coinValue;
            }
            else
            {
                dictionaryCoin.Add(coin, coinValue);               
            }
        }

        public int GetTotalBalance()
        {
            int quarterValue = GetCoinValueFromDictionary(Coin.Quarter);
            int dimeValue = GetCoinValueFromDictionary(Coin.Dime);
            int nickelValue = GetCoinValueFromDictionary(Coin.Nickel);
            int totalBalance = quarterValue + dimeValue + nickelValue;
            return totalBalance;
        }

        public int GetCoinValueFromDictionary(Coin coin)
        {
            int coinValue = 0;
            dictionaryCoin.TryGetValue(coin, out coinValue);
            return coinValue;
        }

        public void UpdateCoinBalance(int productPrice)
        {
            int totalBalance = GetTotalBalance();

            if (totalBalance >= productPrice)
            {
                productPrice = DispenseCoinCalculation(Coin.Quarter, productPrice);
            }
            if (productPrice > 0)
            {
                productPrice = DispenseCoinCalculation(Coin.Dime, productPrice);
            }
            if (productPrice > 0)
            {
                DispenseCoinCalculation(Coin.Nickel, productPrice);
            }
        }

        private int DispenseCoinCalculation(Coin coin, int productPrice)
        {
            if (productPrice == 0) return 0;
            int coinValue = GetCoinValueFromDictionary(coin);
            if (coinValue == 0) return productPrice;

            if(coinValue >= productPrice)
            {
                coinValue -= productPrice;
                if (coinValue == 0)
                {
                    dictionaryCoin.Remove(coin);
                }
                else
                {
                    dictionaryCoin[coin] = coinValue;
                    coinValue = 0;
                }
            }
            else 
            {
                dictionaryCoin.Remove(coin);
                coinValue = productPrice - coinValue;
            }
            return coinValue;
        }
    }
}
