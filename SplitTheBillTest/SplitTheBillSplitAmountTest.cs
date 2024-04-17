
using SplitTheBillClassLibrary;

namespace SplitTheBillTest
{
    [TestClass]
    public class SplitTheBillSplitAmountTest
    {
        [TestMethod]
        public void TestSplitAmount_ValidSplit_ReturnsCorrectValue()
        {
            // Arrange
            var amount = 10.0m;
            var numberOfPeople = 2;
            Bill bill = new Bill();

            // Act
            var splitAmount = bill.SplitAmount(amount, numberOfPeople);

            // Assert
            Assert.AreEqual(5.0m, splitAmount);
        }

        [TestMethod]
        public void TestSplitAmount_ZeroPeople_ThrowsArgumentException()
        {
            // Arrange
            var amount = 10.0m;
            var numberOfPeople = 0;

            Bill bill = new Bill();

            // Assert
            Assert.ThrowsException<ArgumentException>(() => bill.SplitAmount(amount, numberOfPeople));
        }

        [TestMethod]
        public void TestSplitAmount_NegativePeople_ThrowsArgumentException()
        {
            // Arrange
            var amount = 10.0m;
            var numberOfPeople = -2;

            Bill bill = new Bill();

            // Assert
            Assert.ThrowsException<ArgumentException>(() => bill.SplitAmount(amount, numberOfPeople));
        }
    }
}