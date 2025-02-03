using PROG2070Assignment2;


namespace UnitTests
{
	public class Tests
	{
		private Products product;

		[SetUp]
		public void Setup()
		{
			
			product = new Products(10, "Test Product", 50.0, 1000);
		}

		[Test]
		public void ValidStockIncrease_2000Stock_Valid()
		{
			
			product.IncreaseStock(2000);

			
			Assert.That(product.stockAmount, Is.EqualTo(3000));
		}

		[Test]
		public void InvalidStockIncrease_ExceedsMaxLimit_ThrowsException()
		{
			var ex = Assert.Throws<InvalidOperationException>(() => product.IncreaseStock(499001));

			Assert.That(ex.Message, Is.EqualTo("Stock cannot exceed the maximum limit of 500000."));
		}

		[Test]
		public void InvalidStockIncrease_InvalidIncreaseAmount_ThrowsException()
		{
			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(0));

			Assert.That(ex.Message, Does.Contain("amount").And.Contains("Increase amount must be greater than 0."));

		}

		[Test]
		public void ValidStockDecrese_10Stock_Valid()
		{
			product.DecreaseStock(10);

			Assert.That(product.stockAmount, Is.EqualTo(990));
		}

		[Test]
		public void InvalidStockDecrease_ExceedsMinimumLimit_ThrowsException()
		{
			var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(996));

			Assert.That(ex.Message, Is.EqualTo("Stock cannot go below the minimum limit of 5."));
		}

		[Test]
		public void InvalidStockDecrease_InvalidDecreaseAmount_ThrowsException()
		{
			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(0));

			Assert.That(ex.Message, Does.Contain("amount").And.Contains("Decrease amount must be greater than 0."));
		}

	}
}
