using System.Diagnostics;
using System.Security.Cryptography;
using VMDemo;
using static VMDemo.Constants;

namespace VMTests
{
    public class VendingMachineTest
    {
        VendingMachine _vendingMachine;
        CoinCollection _coinCollection;
        public VendingMachineTest()
        {
            _coinCollection = new CoinCollection();
            _vendingMachine = new VendingMachine(_coinCollection);
        }

        [Fact]
        public void AcceptCoins_ReturnsValidationMessage_When_CoinNotAccepted()
        {
            //Arrange
            var coin = Coin.Other;
            int num = 4;

            //Act
            string result = _vendingMachine.AcceptCoins(coin, num);

            //Assert
            Assert.Equal(StringConstants.CheckInput, result);
        }

        [Fact]
        public void AcceptCoins_ReturnsValidationMessage_When_EnterZeroNumberOfCoins()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 0;

            //Act
            string result = _vendingMachine.AcceptCoins(coin, num);

            //Assert
            Assert.Equal(StringConstants.CheckInput, result);
        }

        [Fact]
        public void AcceptCoins_ReturnsSuccessMessage_When_CoinIsAccepted()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 4;

            //Act
            string result = _vendingMachine.AcceptCoins(coin, num);
            int coinValue = _coinCollection.GetTotalBalance();
            string returnMessage = $"{StringConstants.CoinSuccess} {StringConstants.Balance} {coinValue.ToCurrency()}";
            //Assert
            Assert.Equal(result, returnMessage);
        }       

        [Fact]
        public void DispenseProduct_ReturnsValidationMessage_When_ProductNotAccepted()
        {
            //Arrange            
            var prod = Product.Other;

            //Act
            var result = _vendingMachine.DispenseProduct(prod);

            //Assert
            Assert.Equal(StringConstants.InvalidProduct, result);
        }

        [Fact]
        public void DispenseProduct_ReturnsSuccessMessage_When_ProductAccepted()
        {
            //Arrange            
            var coin = Coin.Quarter;
            int num = 4;
            var prod = Product.Cola;

            //Act
            _vendingMachine.AcceptCoins(coin, num);
            var result = _vendingMachine.DispenseProduct(prod);
            int coinValue = _coinCollection.GetTotalBalance();
            var returnMessage = $"{StringConstants.ThankYou} {StringConstants.Balance} {coinValue.ToCurrency()}";

            //Assert
            Assert.Equal(returnMessage, result);
        }

        [Fact]
        public void DispenseProduct_ReturnsValidationMessage_When_BalanceIsLessThanProductPrice()
        {
            //Arrange
            var coin = Coin.Quarter;
            int num = 1;
            var prod = Product.Cola;

            //Act
            _vendingMachine.AcceptCoins(coin, num);
            var result = _vendingMachine.DispenseProduct(prod);
            int coinValue = _coinCollection.GetTotalBalance();
            var returnMessage = $"{StringConstants.InsufficientBalance} {coinValue.ToCurrency()} & {StringConstants.ProductPrice} {prod.GetProductValue().ToCurrency()}"; ;

            //Assert
            Assert.Equal(returnMessage, result);
        }        

        [Fact]
        public void DisplayBalance_ReturnsValidationMessage_When_NoCoinsInserted()
        {
            //Arrange            

            //Act
            var result = _vendingMachine.DisplayBalance();
            int coinValue = _coinCollection.GetTotalBalance();
            var returnMessage = $"{StringConstants.InsertCoin} {StringConstants.Balance} {coinValue.ToCurrency()}";

            //Assert
            Assert.Equal(returnMessage, result);
        }

        [Fact]
        public void DisplayBalance_ReturnSuccessMessage_When_BalanceIsAvailable()
        {
            //Arrange            
            var coin = Coin.Quarter;
            int num = 4;

            //Act
            _vendingMachine.AcceptCoins(coin, num);
            int coinValue = _coinCollection.GetTotalBalance();
            var result = _vendingMachine.DisplayBalance();
            var returnMessage = $"{StringConstants.Balance} {coinValue.ToCurrency()}";

            //Assert
            Assert.Equal(returnMessage, result);
        }
    }
}