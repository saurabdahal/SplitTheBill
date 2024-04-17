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
        /// <param name="mealCosts">A dictionary where keys are names and values are the cost of their meals.</param>
        /// <param name="tipPercentage">The tip percentage as a float (e.g., 15% is represented as 15).</param>
        /// <returns>A dictionary where keys are names and values are the tip amount each person should pay.</returns>
        public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            // Validate input parameters

            if (tipPercentage <= 0) throw new ArgumentOutOfRangeException("tipPercentage");

            // to calculate the weighted tip amount we follow following procedure
            // First we calculate total cost of all meals
            decimal totalCost = mealCosts.Values.Sum();
            if (totalCost <= 0) throw new ArgumentException("at least one person has to order");

            // Then we convert tipPercentage from percentage to a decimal for calculation
            decimal tipDecimal = (decimal)tipPercentage / 100;

            // Then we calculate total tip amount based on total meal cost and tip percentage. Here meal cost acts as the weight
            // So, higher the meal, bigger the tip
            decimal totalTip = totalCost * tipDecimal;

            // Finally we calculate tip amount per person based on their meal cost and the total tip
            Dictionary<string, decimal> tipPerPerson = new Dictionary<string, decimal>();

                foreach (var person in mealCosts)
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
        /// <param name="price">The total price of the bill.</param>
        /// <param name="numberOfPatrons">The number of patrons sharing the bill.</param>
        /// <param name="tipPercentage">The tip percentage (e.g., 15 for 15%).</param>
        /// <returns>The amount of tip each person should pay.</returns>
        public decimal CalculateTipPerPersonBasedOnPatrons(decimal price, int numberOfPatrons, float tipPercentage)
        {
            // Validate input parameters
            if (price <= 0 || numberOfPatrons <= 0 || tipPercentage < 0)
            {
                throw new ArgumentException("Invalid arguments: price must be positive, number of patrons must be positive, and tip percentage must be non-negative.");
            }

            // Convert tipPercentage from percentage to a decimal
            decimal tipDecimal = (decimal)tipPercentage / 100;

            // Calculate total tip amount
            decimal totalTip = price * tipDecimal;

            // Calculate tip amount per person
            decimal tipPerPerson = totalTip / numberOfPatrons;

            // Round the tip amount per person to two decimal places
            return Math.Round(tipPerPerson, 2);
        }

    }
}
