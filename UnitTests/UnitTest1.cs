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

        #region StockAmountTests
        //A test for a valid stock increase. Ensures that increasing stock between 5-500000 works
        [Test]
        public void ValidStockIncrease_2000Stock_Valid()
        {

            product.IncreaseStock(2000);
            Assert.That(product.stockAmount, Is.EqualTo(3000));
        }

        //A test for an invalid stock increase. Ensures that the stock can't exceed the 500000 limit/upper bound.
        [Test]
        public void InvalidStockIncrease_ExceedsMaxLimit_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => product.IncreaseStock(499001));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot exceed the maximum limit of 500000."));
        }

        //A test for an invalid stock increase. Ensures that stock can't be increased by an invalid amount.
        [Test]
        public void InvalidStockIncrease_InvalidIncreaseAmount_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(0));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Increase amount must be greater than 0."));

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(-50));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Increase amount must be greater than 0."));
        }

        //A test for a valid stock decrese. Ensures that decreasing stock between 5-500000 works
        [Test]
        public void ValidStockDecrese_10Stock_Valid()
        {
            product.DecreaseStock(10);
            Assert.That(product.stockAmount, Is.EqualTo(990));
        }

        //A test for an inalid stock decrease. Ensures that the stock can't be decresed lower than the lower limit/bound of 5.
        [Test]
        public void InvalidStockDecrease_ExceedsMinimumLimit_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(996));
            Assert.That(ex.Message, Is.EqualTo("Stock cannot go below the minimum limit of 5."));
        }

        //A test for an inalid stock decrease. Ensures that the stock can't be decreased by an invalid amount
        [Test]
        public void InvalidStockDecrease_InvalidDecreaseAmount_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(0));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Decrease amount must be greater than 0."));

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(-5));
            Assert.That(ex.Message, Does.Contain("amount").And.Contains("Decrease amount must be greater than 0."));
        }
        #endregion

        #region StockIDTests
        //A test for an invalid product ID. Ensures that the product ID is not less than 5.
        [Test]
        public void InvalidProductID_LessThan5_ThrowsArgumentOutOfRangeException()
        {
            int invalidProductID = 4;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(invalidProductID, "Test Product", 20.20, 50));

            Assert.That(ex.Message, Does.Contain("Product ID must be between 5 and 50000."));
        }

        //A test for a valid product ID. Ensures that a product ID can be created at the lower limit/bound of 5.
        [Test]
        public void ValidProductID_EqualTo5_CreatesProductSuccessfully()
        {
            int validProductID = 5;
            var product = new Products(validProductID, "Test Product", 50.0, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.prodID, Is.EqualTo(validProductID));
        }

        //A test for an invalid product ID. Ensures that the correct parameter is throwing an exception.
        [Test]
        public void InvalidProductID_LessThan5_ThrowsArgumentOutOfRangeException_WithCorrectParameterName()
        {
            int invalidProductID = 4;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(invalidProductID, "Test Product", 20.20, 1000));

            Assert.That(ex.ParamName, Is.EqualTo("productID"));
        }

        //A test for a valid product ID. Ensures that an ID between 5 and 50000 can be created.
        [Test]
        public void ValidProductID_ProductID25000_CreatesProductSuccessfully()
        {
            int validProductID = 25000;
            var product = new Products(validProductID, "Test Product", 20.20, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.prodID, Is.EqualTo(validProductID));
        }

        //A test for a valid Product ID. Ensures that an ID can be created at the upper limit/bound of 50000.
        [Test]
        public void ValidProductID_ProductID50000_CreatesProductSuccessfully()
        {
            int validProductID = 50000;
            var product = new Products(validProductID, "Test Product", 20.20, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.prodID, Is.EqualTo(validProductID));
        }

        //A test for an invalid Product ID. Ensures that an ID greater than 50000 can not be created.
        [Test]
        public void InvalidProductID_GreaterThan50000_ThrowsArgumentOutOfRangeException()
        {
            int invalidProductID = 50001;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(invalidProductID, "Test Product", 20.20, 1000));

            Assert.That(ex.Message, Does.Contain("Product ID must be between 5 and 50000."));
        }
        #endregion

        #region ProdutPriceTests
        //A test for an invalid product price. Ensures that a price lower than 5.00 can not be created.
        [Test]
        public void InvalidProductPrice_LessThan5_ThrowsArgumentOutOfRangeException()
        {
            double invalidPrice = 4.99;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(10, "Test Product", invalidPrice, 1000));

            Assert.That(ex.Message, Does.Contain("Item Price must be between $5 and $5000."));
        }

        //A test for a valid product price. Ensures that a price at the lower limit/bound of 5.00 can be created.
        [Test]
        public void ValidProductPrice_PriceOf5_CreatesProductSuccessfully()
        {
            double validPrice = 5.00;
            var product = new Products(10, "Test Product", validPrice, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.itemPrice, Is.EqualTo(validPrice));
        }

        //A test for a valid product price. Ensures that a price between 5 and 50000 can be created.
        [Test]
        public void ValidProductPrice_PriceOf2500_CreatesProductSuccessfully()
        {
            double validPrice = 2500.00;
            var product = new Products(10, "Test Product", validPrice, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.itemPrice, Is.EqualTo(validPrice));
        }

        //A test for a valid product price. Ensures that a price at the upper limit/bound of 50000.00 can be created.
        [Test]
        public void ValidProductPrice_PriceOf5000_CreatesProductSuccessfully()
        {
            double validPrice = 5000.00;
            var product = new Products(10, "Test Product", validPrice, 1000);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.itemPrice, Is.EqualTo(validPrice));
        }

        //A test for an invalid product price. Ensures that a product price greater than 50000.00 can not be created.
        [Test]
        public void InvalidProductPrice_GreaterThan5000_ThrowsArgumentOutOfRangeException()
        {
            double invalidPrice = 5000.01;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(10, "Test Product", invalidPrice, 1000));

            Assert.That(ex.Message, Does.Contain("Item Price must be between $5 and $5000."));
        }

        //A test for an invalid product price. Ensures that the correct parameter is throwing the exception.
        [Test]
        public void InvalidProductPrice_LessThan5_ThrowsArgumentOutOfRangeException_WithCorrectParameterName()
        {
            double invalidPrice = 4.99;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Products(10, "Test Product", invalidPrice, 1000));

            Assert.That(ex.ParamName, Is.EqualTo("price"));
        }

        #endregion

    }
}
