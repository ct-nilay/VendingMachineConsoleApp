using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMDemo
{
    public class Constants
    {
        public enum Coin
        {
            Nickel = 5,
            Dime = 10,
            Quarter = 25,
            Other = 0
        }

        public enum Product
        {
            Cola = 100,
            Candy = 65,
            Chips = 50,
            Other = 0
        };

        public class StringConstants
        {
            public const string SelectValid = "Select valid option!";
            public const string InsertCoin = "Please insert coin!";
            public const string CoinSuccess = "Coin inserted successfully!";
            public const string InvalidCoin = "Invalid coin. Please insert valid coin!";
            public const string InvalidNumberOfCoins = "Invalid number of coins!";
            public const string ThankYou = "Thank you!";
            public const string Balance = "Your balance is:";
            public const string InsufficientBalance = "Insufficient Balance:";
            public const string CoinIsNullOrEmpty = "Coin value should not be null or empty!";
            public const string CheckInput = "Please check your inputs!";
            public const string ProductNullOrEmpty = "Product value should not be null or empty!";
            public const string ProductPrice = "Product price is:";
            public const string InvalidProduct = "Invalid product!";
        }
    }
}
