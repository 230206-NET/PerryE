// See https://aka.ms/new-console-template for more information
using System;
namespace CoinFlipper
{
	public class Flipper
	{
		public void flipCoin()
		{
			Console.WriteLine("Coin Flipper Starting ...");
			bool coin;
			var coinValue = new Random();
			coin = (coinValue.Next(0, 3) > 1) ? true : false;
			if (coin)
			{
				Console.WriteLine("The coin landed on heads");
			}
			else
			{
				Console.WriteLine("The coin landed on tails");
			}
		}
	}
}
