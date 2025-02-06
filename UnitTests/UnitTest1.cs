using PROG2070Assignment2;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private Products product;

        [SetUp]
        public void Setup()
        {
            product = new Products(10, "Test Product", 50.0, 1000);
        }

        // Product ID Tests
        [Test]
        public void ProductID_ValidID_ShouldSetCorrectly()
        {
            var newProduct = new Products(100, "Product A", 100.0, 500);
            Assert.That(newProduct.prodID, Is.EqualTo(100));
        }

        [Test]
        public void ProductID_MinBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(5, "Product B", 200.0, 1000);
            Assert.That(newProduct.prodID, Is.EqualTo(5));
        }

        [Test]
        public void ProductID_MaxBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(50000, "Product C", 300.0, 1500);
            Assert.That(newProduct.prodID, Is.EqualTo(50000));
        }

        // Product Name Tests
        [Test]
        public void ProductName_ShouldSetCorrectly()
        {
            var newProduct = new Products(101, "Product X", 120.0, 600);
            Assert.That(newProduct.prodName, Is.EqualTo("Product X"));
        }

        [Test]
        public void ProductName_EmptyString_ShouldAllow()
        {
            var newProduct = new Products(102, "", 150.0, 700);
            Assert.That(newProduct.prodName, Is.EqualTo(""));
        }

        [Test]
        public void ProductName_LongString_ShouldSetCorrectly()
        {
            string longName = new string('A', 255);
            var newProduct = new Products(103, longName, 180.0, 800);
            Assert.That(newProduct.prodName, Is.EqualTo(longName));
        }

        // Item Price Tests
        [Test]
        public void ItemPrice_ValidPrice_ShouldSetCorrectly()
        {
            var newProduct = new Products(104, "Product Y", 4999.99, 900);
            Assert.That(newProduct.itemPrice, Is.EqualTo(4999.99));
        }

        [Test]
        public void ItemPrice_MinBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(105, "Product Z", 5.0, 1000);
            Assert.That(newProduct.itemPrice, Is.EqualTo(5.0));
        }

        [Test]
        public void ItemPrice_MaxBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(106, "Product W", 5000.0, 1100);
            Assert.That(newProduct.itemPrice, Is.EqualTo(5000.0));
        }

        // Stock Amount Tests
        [Test]
        public void StockAmount_ValidStock_ShouldSetCorrectly()
        {
            var newProduct = new Products(107, "Product V", 220.0, 499999);
            Assert.That(newProduct.stockAmount, Is.EqualTo(499999));
        }

        [Test]
        public void StockAmount_MinBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(108, "Product U", 250.0, 5);
            Assert.That(newProduct.stockAmount, Is.EqualTo(5));
        }

        [Test]
        public void StockAmount_MaxBoundary_ShouldSetCorrectly()
        {
            var newProduct = new Products(109, "Product T", 275.0, 500000);
            Assert.That(newProduct.stockAmount, Is.EqualTo(500000));
        }

        // Increase Stock Tests
        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseCorrectly()
        {
            product.IncreaseStock(2000);
            Assert.That(product.stockAmount, Is.EqualTo(3000));
        }

        [Test]
        public void IncreaseStock_ExceedsMaxLimit_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => product.IncreaseStock(499001));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot exceed the maximum limit of 500000."));
        }

        [Test]
        public void IncreaseStock_ZeroAmount_ShouldThrowException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(0));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Increase amount must be greater than 0."));
        }

        // Decrease Stock Tests
        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseCorrectly()
        {
            product.DecreaseStock(10);
            Assert.That(product.stockAmount, Is.EqualTo(990));
        }

        [Test]
        public void DecreaseStock_ExceedsMinimumLimit_ShouldThrowException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(996));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot go below the minimum limit of 5."));
        }

        [Test]
        public void DecreaseStock_ZeroAmount_ShouldThrowException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(0));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Decrease amount must be greater than 0."));
        }
    }
}
