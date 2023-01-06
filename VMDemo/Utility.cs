using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VMDemo.Constants;

namespace VMDemo
{
    public static class Utility
    {
        public static int ValidateInput(this string? inputString)
        {
            int input = 0;
            while (!int.TryParse(inputString, out input))
            {
                Console.WriteLine("Enter Valid Input!");
                inputString = Console.ReadLine();
            }
            return input;
        }

        public static int GetCoinValue(this Coin coin)
        {
            return (int)coin;
        }

        public static Coin GetCoinType(this int option)
        {
            switch (option)
            {
                case 1:
                    return Coin.Nickel;
                case 2:
                    return Coin.Dime;
                case 3:
                    return Coin.Quarter;   
                default:
                    return Coin.Other;
            }
        }

        public static Product GetProductType(this int option)
        {
            switch (option)
            {
                case 1:
                    return Product.Cola;
                case 2:
                    return Product.Candy;
                case 3:
                    return Product.Chips;
                default:
                    return Product.Other;
            }
        }

        public static int GetProductValue(this Product prod)
        {
            return (int)prod;
        }

        public static string ToCurrency(this int amount)
        {
            double amountValue = amount / 100.0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return amountValue.ToString("c");
        }
    }
}
