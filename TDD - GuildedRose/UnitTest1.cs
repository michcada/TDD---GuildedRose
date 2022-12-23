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
            Assert.AreEqual(6, myProduct.QualityValue);
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
            int[] sellInValueAndQualityValue = new int[] { myProduct.SellInValue, myProduct.QualityValue };
            int[] compareWith = new int[] { 10, 80 };
            CollectionAssert.AreEqual(compareWith, sellInValueAndQualityValue);

        }

        [TestMethod]
        public void TestIfSulfurasHasAQualityValueDiferentFrom80ItReturnsError()
        {
            //Sulfuras, SellInValue:10, QualityValue: 51
            Product myProduct = new Product("Sulfuras", 10, 51);
            string message = "This should return an error";
            try
            {
                myProduct.UpdateProduct();
            }
            catch (ArgumentOutOfRangeException e)
            {
                message = "Error: Quality is Not 80";
                Console.WriteLine(message);
            }

            Assert.AreEqual("Error: Quality is Not 80", message);
        }

        [TestMethod]
        public void TestBackstangePassesIncreaseQualityValueBy1IfSellInIsMoreThan10()
        {
            //Backstage passes, SellInValue:11, QualityValue: 40
            Product myProduct = new Product("Backstage passes", 11, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(41, myProduct.QualityValue);
        }

        [TestMethod]
        public void TestBackstangePassesIncreaseQualityValueBy2IfSellInValueIsLessThanOrEqualTo10()
        {
            Product bP1 = new Product("Backstage passes", 10, 40);
            Product bP2 = new Product("Backstage passes", 9, 28);
            bP1.UpdateProduct();
            bP2.UpdateProduct();
            //Array That Stores Backstage passes Quality values
            int[] bPQualities = new int[] { bP1.QualityValue, bP2.QualityValue };
            //Array That Stores the numbers to compare with
            int[] compareWith = new int[] { 42, 30 };
            //Assert if both arrays are equal
            CollectionAssert.AreEqual(compareWith, bPQualities);
        }

        //Quality Can't be more than 50
        [TestMethod]
        public void TestWhenBackstangePassesSellInValueIs10AndQualityValueIs49ItShouldIncreaseTo50()
        {
            //Backstage passes, SellInValue:10, QualityValue: 49
            Product myProduct = new Product("Backstage passes", 10, 49);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.QualityValue);
        }

        [TestMethod]
        public void TestBackstangePassesShouldIncreaseQualityValueBy3IfSellInValueIsLessThanOrEqualTo5()
        {
            Product bP1 = new Product("Backstage passes", 5, 20);
            Product bP2 = new Product("Backstage passes", 3, 7);
            bP1.UpdateProduct();
            bP2.UpdateProduct();
            //Array That Stores Backstage passes Quality values
            int[] bPQualities = new int[] { bP1.QualityValue, bP2.QualityValue };
            //Array That Stores the numbers to compare with
            int[] compareWith = new int[] { 23, 10 };
            //Assert if both arrays are equal
            CollectionAssert.AreEqual(compareWith, bPQualities);
        }

        //Quality Can't be more than 50
        [TestMethod]
        public void TestWhenBackstangePassesSellInValueIs5AndQualityValueIs48ItShouldIncreaseTo50()
        {
            //Backstage passes, SellInValue:10, QualityValue: 48
            Product myProduct = new Product("Backstage passes", 10, 48);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.QualityValue);
        }

        //Quality Can't be more than 50
        [TestMethod]
        public void TestWhenBackstangePassesSellInValueIs5AndQualityValueIs49ItShouldIncreaseTo50()
        {
            //Backstage passes, SellInValue:10, QualityValue: 49
            Product myProduct = new Product("Backstage passes", 10, 49);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.QualityValue);
        }

        [TestMethod]
        public void TestWhenBackstangePassesSellInValueIs0QualityValueShoulUpdateTo0()
        {
            //Backstage passes, SellInValue:0, QualityValue: 20
            Product bP1 = new Product("Backstage passes", 0, 20);
            bP1.UpdateProduct();
            Assert.AreEqual(0, bP1.QualityValue);
        }

        //Conjured product reduces its quality Twice as fast
        [TestMethod]
        public void TestConjuredProductReducesItsQualityValueBy2WhenSellInValueIsNot0()
        {
            //Conjured bread, SellIn: 10, QualityValue: 7
            Product myProduct = new Product("Conjured bread", 10, 7);
            myProduct.UpdateProduct();
            Assert.AreEqual(5, myProduct.QualityValue);
        }

        [TestMethod]
        public void TestConjuredProductReducesItsQualityValueBy4WhenSellInValueIs0()
        {
            // Conjured bread, SellIn: 0, QualityValue: 7
            Product myProduct = new Product("Conjured bread", 0, 7);
            myProduct.UpdateProduct();
            Assert.AreEqual(3, myProduct.QualityValue);
        }

    }
}