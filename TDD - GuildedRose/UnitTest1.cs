using GuildedRose;
using System.Threading.Channels;

namespace TDD___GuildedRose
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUpdateProductDecreaseQuality()
        {
            // Bread, SellIn: 10, QualityValue: 7
            Product myProduct = new Product("Bread", 10, 7);
            myProduct.UpdateProduct();
            Assert.AreEqual(6,myProduct.QualityValue);
        }

        [TestMethod]
        public void TestUpdateProductDecreaseSellIn()
        {
            Product myProduct = new Product("Vinegar", 20, 10);
            myProduct.UpdateProduct();
            Assert.AreEqual(19, myProduct.SellInValue);
        }

        [TestMethod]
        public void TestWhenSellInEqualsZeroQualityDecreasesTwice()
        {
            Product myProduct = new Product("Potion", 0, 2);
            myProduct.UpdateProduct();
            Assert.AreEqual(0, myProduct.QualityValue);
        }

        [TestMethod]
        public void TestQualityCantBeNegative()
        {
            Product myProduct = new Product("lizard skewer", 1, 0);
            myProduct.UpdateProduct();
            Assert.AreEqual(0, myProduct.QualityValue);

        }

        [TestMethod]
        public void TestAgedBrieIncreasesQualityAsTimePasts()
        {
            Product myProduct = new Product("Aged Brie", 10, 49);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.QualityValue);

        }

        [TestMethod]
        public void TestQualityCantIncreaseMoreThan50()
        {
            Product myProduct = new Product("Aged Brie", 10, 50);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.QualityValue);

        }

        [TestMethod]

        public void TestQualityCantBeMoreThan50()
        { 
            Product myProduct = new Product("Aged Brie", 10, 52);
            string message = "This should return an error";
            try
            {
                myProduct.UpdateProduct();
            }
            catch (ArgumentOutOfRangeException e)
            {
                message = "Error: Quality out of the limits";
                Console.WriteLine(message);
            }

            Assert.AreEqual("Error: Quality out of the limits", message);

        }

        [TestMethod]
        public void TestSulfurasDoesntReduceItsSellinOrQuality()
        {
            //Sulfuras, SellInValue:10, QualityValue: 80
            Product myProduct = new Product("Sulfuras", 10, 80); //Sulfuras Quality Is Always 80
            myProduct.UpdateProduct();
            int[] sellInValueAndQualityValue = new int[] {myProduct.SellInValue, myProduct.QualityValue};
            int[] compare = new int[] { 10, 80 };
            CollectionAssert.AreEqual(compare, sellInValueAndQualityValue);

        }
    }
}