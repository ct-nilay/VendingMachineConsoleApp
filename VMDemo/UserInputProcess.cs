using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VMDemo.Constants;

namespace VMDemo
{
    public class UserInputProcess
    {
        static MemoryCacheService _memoryCacheService = new MemoryCacheService();
        static CoinCollection _coinCollection = new CoinCollection(_memoryCacheService);
        VendingMachine _vendingMachine = new VendingMachine(_coinCollection);
        public Coin SelectedCoin { get; set; }
        public Product SelectedProduct { get; set; }
        public int NumberOfCoins { get; set; }

        public int ChoiceSelection()
        {
            string choice;
            Console.WriteLine("\nPRESS: 1 - Add Coins, 2 - Dispense Products, 3 - Display Balance, 4 - To Exit");
            choice = Console.ReadLine();
            return Utility.ValidateInput(choice);
        }
        public bool HandleCoinSelection()
        {
            string? coin = Console.ReadLine();
            int coinReturnValue = coin.ValidateInput();
            SelectedCoin = coinReturnValue.GetCoinType();
            if (SelectedCoin == Coin.Penny || SelectedCoin == Coin.Other)
            {
                Console.WriteLine("INVALID COIN!\n");
                return false;
            }
            return true;
        }
        public bool HandleNumberOfCoinsInput()
        {
            string? numOfCoins = Console.ReadLine();
            NumberOfCoins = numOfCoins.ValidateInput();
            if (NumberOfCoins > 0)
                return true;
            else
            {
                Console.WriteLine(StringConstants.InvalidNumberOfCoins);
                return false;
            }
        }

        public void AcceptCoins()
        {
            string result = _vendingMachine.AcceptCoins(SelectedCoin, NumberOfCoins);
            Console.WriteLine(result);
        }

        public bool HandleProductSelection()
        {
            string? product = Console.ReadLine();
            int productReturnValue = product.ValidateInput();
            SelectedProduct = productReturnValue.GetProductType();
            if (SelectedProduct == Product.Other) {
                Console.WriteLine(StringConstants.InvalidProduct);
                return false;
            } 
            return true;
        }

        public void DispenseProduct()
        {
            string result = _vendingMachine.DispenseProduct(SelectedProduct);
            Console.WriteLine(result);
        }

        public void DisplayBalance()
        {
            string result = _vendingMachine.DisplayBalance();
            Console.WriteLine(result);
        }
    }
}
