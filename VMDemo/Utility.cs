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
                Console.WriteLine("Enter Valid Input");
                inputString = Console.ReadLine();
            }
            return input;
        }

        public static int GetValue(this Coin coin)
        {
            int value = 0;

            switch (coin)
            {
                case Coin.Penny:
                    value = 1;
                    break;
                case Coin.Nickel:
                    value = 5;
                    break;
                case Coin.Dime:
                    value = 10;
                    break;
                case Coin.Quarter:
                    value = 25;
                    break;
                default:
                    break;
            }
            return value;
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
                case 4:
                    return Coin.Penny;
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

        public static int GetProductPrice(this Product prod)
        {
            int price = 0;
            switch (prod)
            {
                case Product.Cola:
                    price = 100;
                    break;
                case Product.Candy:
                    price = 65;
                    break;
                case Product.Chips:
                    price = 50;
                    break;
                default:
                    break;
            }
            return price;
        }

        public static string GetCurrencyString(this int amount)
        {
            double amountValue = amount / 100.0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //return string.Format("{0:c}", amountValue);
            return amountValue.ToString("c");

        }

        public static bool IsValidCoin(this string coin)
        {
            bool isValid = Enum.GetNames(typeof(Coin))
                .Any(x => x.ToString().Contains(coin, StringComparison.OrdinalIgnoreCase));
            return isValid;
        }

        public static bool IsValidProduct(this string prod)
        {
            bool isValid = Enum.GetNames(typeof(Product))
                .Any(x => x.ToString().Contains(prod, StringComparison.OrdinalIgnoreCase));
            return isValid;
        }

        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
