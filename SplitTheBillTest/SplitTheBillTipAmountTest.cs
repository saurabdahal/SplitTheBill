using SplitTheBillClassLibrary;

namespace SplitTheBillTest
{
    [TestClass]
    public class SplitTheBillTipAmountTest
    {
        [TestMethod]
        public void CalculateTipPerPerson_WithValidData_ReturnsCorrectValue()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 25.0m },
                { "Bob", 35.0m },
                { "Charlie", 20.0m }
            };
            float tipPercentage = 15; // 15% tip

            Bill bill= new Bill();

            // Act
            var tipPerPerson = bill.CalculateTipPerPerson(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(3.75m, tipPerPerson["Alice"], "Alice's tip amount is incorrect.");
            Assert.AreEqual(5.25m, tipPerPerson["Bob"], "Bob's tip amount is incorrect.");
            Assert.AreEqual(3.00m, tipPerPerson["Charlie"], "Charlie's tip amount is incorrect.");
        }

        [TestMethod]
        public void CalculateTipPerPerson_WithZeroCosts_throwsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal>
            {
                { "Alice", 0.0m },
                { "Bob", 0.0m }
            };
            float tipPercentage = 20; // 20% tip

            Bill bill = new Bill();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => bill.CalculateTipPerPerson(mealCosts, tipPercentage));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPerson_WithEmptyMealCosts_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var emptyMealCosts = new Dictionary<string, decimal>();
            float tipPercentage = 0f;

            Bill bill = new Bill();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bill.CalculateTipPerPerson(emptyMealCosts, tipPercentage));
        }
    }
}
