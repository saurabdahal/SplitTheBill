using SplitTheBillClassLibrary;

namespace SplitTheBillTest
{
    [TestClass]
    public class SplitTheBillTipAmountWithPatronTest
    {
        [TestMethod]
        public void CalculateTipPerPersonBasedOnPatrons_ValidInput_CalculatesCorrectTipPerPerson()
        {
            // Arrange
            decimal price = 100m;
            int numberOfPatrons = 5;
            float tipPercentage = 15f;
            Bill bill = new Bill();
            // Act
            decimal tipPerPerson = bill.CalculateTipPerPersonBasedOnPatrons(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(3m, tipPerPerson, "Incorrect tip amount per person calculated.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTipPerPersonBasedOnPatrons_NegativePrice_ThrowsArgumentException()
        {
            // Arrange
            decimal price = -50m;
            int numberOfPatrons = 4;
            float tipPercentage = 20f;
            Bill bill = new Bill();
            // Act & Assert
            decimal tipPerPerson = bill.CalculateTipPerPersonBasedOnPatrons(price, numberOfPatrons, tipPercentage);
        }

        [TestMethod]
        public void CalculateTipPerPersonBasedOnPatrons_ZeroTipPercentage_ReturnsZeroTipPerPerson()
        {
            // Arrange
            decimal price = 80m;
            int numberOfPatrons = 4;
            float tipPercentage = 0f;

            Bill bill = new Bill();

            // Act
            decimal tipPerPerson = bill.CalculateTipPerPersonBasedOnPatrons(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(0m, tipPerPerson, "Tip amount per person should be zero when tip percentage is zero.");
        }
    }
}