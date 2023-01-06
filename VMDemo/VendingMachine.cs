using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static VMDemo.Constants;

namespace VMDemo
{
    public class VendingMachine
    {
        CoinCollection _coinCollection;
        public VendingMachine(CoinCollection coinCollection)
        {
            _coinCollection = coinCollection;
        }
        public string AcceptCoins(Coin coin, int num)
        {
            string returnMessage = StringConstants.CheckInput;
            if (coin != Coin.Other && coin != Coin.Penny && num > 0)
            {
                _coinCollection.InsertCoinToMemory(coin, num);
                int coinValue = _coinCollection.GetTotalBalance();
                returnMessage = $"{StringConstants.CoinSuccess} {StringConstants.Balance} {coinValue.GetCurrencyString()}";
            }
            return returnMessage;
        }

        public string DispenseProduct(Product prod)
        {
            string returnMessage = StringConstants.InvalidProduct;

            if (prod != Product.Other)
            {
                int productPrice = prod.GetProductPrice();
                int totalBalance = _coinCollection.GetTotalBalance();

                if (totalBalance >= productPrice)
                {
                    _coinCollection.UpdateCoinBalance(productPrice);
                    totalBalance = _coinCollection.GetTotalBalance();
                    returnMessage = $"{StringConstants.ThankYou} {StringConstants.Balance} {totalBalance.GetCurrencyString()}";
                }
                else
                {
                    returnMessage = $"{StringConstants.Balance} {totalBalance.GetCurrencyString()} & {StringConstants.ProductPrice} {productPrice.GetCurrencyString()}";
                }
            }           
            return returnMessage;
        }

        public string DisplayBalance()
        {
            var returnMesage = string.Empty;

            int coinValue = _coinCollection.GetTotalBalance();
            returnMesage = (coinValue > 0) ? $"{StringConstants.Balance} {coinValue.GetCurrencyString()}" 
                : $"{StringConstants.InsertCoin} {StringConstants.Balance} {coinValue.GetCurrencyString()}";

            return returnMesage;
        }
    }
}
