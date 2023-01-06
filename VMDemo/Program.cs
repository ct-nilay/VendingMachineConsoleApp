// See https://aka.ms/new-console-template for more information
using System;
using VMDemo;
using static VMDemo.Constants;

UserInputProcess _userInputProcess = new UserInputProcess();

int userChoice = 0;

Console.WriteLine("Vending Machine Demo!\n");
Console.WriteLine("The machine will accept these coins: Nickels($0.05), Dimes($0.1), Quarters ($0.25) & Pennies($0.01)");
Console.WriteLine("There are three products to dispense: Cola($1), Candy($0.65) & Chips($0.50)");

do
{
    userChoice = _userInputProcess.ChoiceSelection();
    switch (userChoice)
    {
        case 1: // Accept Coin
            Console.WriteLine("To Add Coins PRESS: 1 - Nickels, 2 - Dimes, 3 - Quarters, 4 - Pennies");            
            bool isValidCoin = _userInputProcess.HandleCoinSelection();
            if (isValidCoin)
            {
                Console.WriteLine("How many number of coins you want to insert?");                
                isValidCoin = _userInputProcess.HandleNumberOfCoinsInput();
                if (isValidCoin)
                {
                    _userInputProcess.AcceptCoins();
                }                
            }           
            break;
        case 2: // Dispense Product
            Console.WriteLine("To Dispense Product PRESS: 1 - Cola, 2 - Candy, 3 - Chips");
            bool isValidProduct = _userInputProcess.HandleProductSelection();
            if(isValidProduct) _userInputProcess.DispenseProduct();
            break;
        case 3: // Display Balance
            _userInputProcess.DisplayBalance();
            break;
        case 4: // Exit
            break;
        default:
            Console.WriteLine(StringConstants.SelectValid);
            break;
    }
}
while (userChoice != 4);

