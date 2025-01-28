using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2070Assignment2
{
	public class Products
	{
		public int prodID {  get; set; }
		public string prodName { get; set; }
		public double itemPrice {  get; set; }
		public int stockAmount {  get; set; }

		public Products(int productID, string productName, double price, int amount) 
		{
			if (productID < 5 || productID > 50000)
			{
				throw new ArgumentOutOfRangeException(nameof(productID), "Product ID must be between 5 and 50000.");
			}	

			if (price < 5 || price > 5000)
			{
				throw new ArgumentOutOfRangeException(nameof(price), "Item Price must be between $5 and $5000.");
			}

			if (amount < 5 || amount > 500000)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Stock Amount must be between 5 and 500000.");
			}

			this.prodID = productID;
			this.prodName = productName;
			this.itemPrice = price;
			this.stockAmount = amount;
		}

		public void IncreaseStock(int amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Increase amount must be greater than 0.");
			}	

			if (stockAmount + amount > 500000)
			{
				throw new InvalidOperationException("Stock cannot exceed the maximum limit of 500000.");
			}
				
			stockAmount += amount;
		}

		public void DecreaseStock(int amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Decrease amount must be greater than 0.");
			}

			if (stockAmount - amount < 5)
			{
				throw new InvalidOperationException("Stock cannot go below the minimum limit of 5.");
			}

			stockAmount -= amount;
		}
	}
}
