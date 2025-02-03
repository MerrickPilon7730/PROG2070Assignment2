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
	}
}
