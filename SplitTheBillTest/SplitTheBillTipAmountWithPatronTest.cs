using SplitTheBillClassLibrary;

namespace SplitTheBillTest
{
    [TestClass]
    public class SplitTheBillTipAmountWithPatronTest
    {
        [TestMethod]
        public void CalculateTipPerPersonBasedOnPatrons_ValidValue_ReturnsCorrectValue()
        {
            // Arrange
            decimal price = 1000;
            int numberOfPatrons = 10;
            float tipPercentage = 20f;
            Bill bill = new Bill();
            // Act
            decimal tipPerPerson = bill.CalculateTipPerPersonBasedOnPatrons(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(20m, tipPerPerson, "Incorrect tip amount per person calculated.");
        }

        /// <summary>
        /// Tests if the method throws Argument Exception. Instead of using Assert.Throws<ArgumentException>, we can
        /// also use the test this way
        /// </summary>
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
        public void CalculateTipPerPersonBasedOnPatrons_ZeroTip_ReturnsZeroTipPerPerson()
        {
            // Arrange
            decimal price = 80m;
            int numberOfPatrons = 4;
            float tipPercentage = 0f;

            Bill bill = new Bill();

            // Act
            decimal tipPerPerson = bill.CalculateTipPerPersonBasedOnPatrons(price, numberOfPatrons, tipPercentage);

            // Assert
            Assert.AreEqual(0m, tipPerPerson, "Tip amount per person is zero when no tip is given.");
        }
    }
}