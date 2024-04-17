using System.Linq.Expressions;

namespace SplitTheBillClassLibrary
{
    /// <summary> This class represents the bill and defines methods for splitting the bill. </summary>
    /// <author>Saurav Dahal</author>
    public class Bill
    {
        public decimal SplitAmount(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople <= 0) throw new ArgumentException("number of people must be greater than zero");
            

            return amount / numberOfPeople;
        }

        /// <summary>
        /// Calculates the tip amount each person should pay based on their meal cost and a specified tip percentage.
        /// </summary>
        /// <param name="totalDinner">A dictionary where keys are names and values are the cost of their meals.</param>
        /// <param name="tip">The tip percentage as a float</param>
        /// <returns>A dictionary where keys are names and values are the tip amount each person should pay.</returns>
        public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> totalDinner, float tip)
        {
            // Validate input parameters

            if (tip <= 0) throw new ArgumentOutOfRangeException("tipPercentage");

            // to calculate the weighted tip amount we follow following procedure
            // First we calculate total cost of all meals
            decimal totalCost = totalDinner.Values.Sum();
            if (totalCost <= 0) throw new ArgumentException("at least one person has to order");

            // Then we convert tipPercentage from percentage to a decimal for calculation
            decimal tipDecimal = (decimal)tip / 100;

            // Then we calculate total tip amount based on total meal cost and tip percentage. Here meal cost acts as the weight
            // So, higher the meal, bigger the tip
            decimal totalTip = totalCost * tipDecimal;

            // Finally we calculate tip amount per person based on their meal cost and the total tip
            Dictionary<string, decimal> tipPerPerson = new Dictionary<string, decimal>();

                foreach (var person in totalDinner)
                {
                    string name = person.Key;
                    decimal mealCost = person.Value;

                    decimal weightedTip = (mealCost / totalCost) * totalTip;

                    decimal roundedTip = Math.Round(weightedTip, 2);

                    tipPerPerson.Add(name, roundedTip);
                }
            
            return tipPerPerson;
        }


        /// <summary>
        /// Calculates the tip amount per person based on the total price, number of patrons, and tip percentage.
        /// </summary>
        /// <param name="mealPrice">The total price of the bill.</param>
        /// <param name="numberOfPatrons">The number of patrons sharing the bill.</param>
        /// <param name="tip">The tip percentage.</param>
        /// <returns>The amount of tip each person should pay.</returns>
        public decimal CalculateTipPerPersonBasedOnPatrons(decimal mealPrice, int numberOfPatrons, float tip)
        {
            if (mealPrice <= 0 || numberOfPatrons <= 0 || tip < 0)
            {
                throw new ArgumentException("Invalid arguments: all parameters should be greater than zero");
            }

            decimal convertedTip = (decimal)tip / 100;

            decimal totalTip = mealPrice * convertedTip;

            decimal tipPerPatron = totalTip / numberOfPatrons;

            return Math.Round(tipPerPatron, 2);
        }

    }
}
