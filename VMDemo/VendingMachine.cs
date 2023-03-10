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
            if (coin != Coin.Other && num > 0)
            {
                _coinCollection.InsertCoinToDictionary(coin, num);
                int coinValue = _coinCollection.GetTotalBalance();
                returnMessage = $"{StringConstants.CoinSuccess} {StringConstants.Balance} {coinValue.ToCurrency()}";
            }
            return returnMessage;
        }

        public string DispenseProduct(Product prod)
        {
            string returnMessage = StringConstants.InvalidProduct;

            if (prod != Product.Other)
            {
                int productPrice = prod.GetProductValue();
                int totalBalance = _coinCollection.GetTotalBalance();

                if (totalBalance >= productPrice)
                {
                    _coinCollection.UpdateCoinBalance(productPrice);
                    totalBalance = _coinCollection.GetTotalBalance();
                    returnMessage = $"{StringConstants.ThankYou} {StringConstants.Balance} {totalBalance.ToCurrency()}";
                }
                else
                {
                    returnMessage = $"{StringConstants.InsufficientBalance} {totalBalance.ToCurrency()} & {StringConstants.ProductPrice} {productPrice.ToCurrency()}";
                }
            }           
            return returnMessage;
        }

        public string DisplayBalance()
        {
            var returnMesage = string.Empty;

            int totalBalance = _coinCollection.GetTotalBalance();
            returnMesage = (totalBalance > 0) ? $"{StringConstants.Balance} {totalBalance.ToCurrency()}" 
                : $"{StringConstants.InsertCoin} {StringConstants.Balance} {totalBalance.ToCurrency()}";

            return returnMesage;
        }
    }
}
