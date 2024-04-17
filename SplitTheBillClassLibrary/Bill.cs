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

        public Dictionary<string, decimal> CalculateTipPerPerson(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0 || tipPercentage < 0)
            {
                throw new ArgumentException("Invalid arguments: mealCosts dictionary cannot be null or empty, and tipPercentage must be non-negative.");
            }

            var totalCost = mealCosts.Values.Sum();
            var tp = (decimal) tipPercentage;
            var totalTip = totalCost * (tp / 100);

            var tipPerPerson = new Dictionary<string, decimal>();
            foreach (var person in mealCosts)
            {
                var weightedTip = totalTip * (person.Value / totalCost);
                tipPerPerson.Add(person.Key, Math.Round(weightedTip, 2)); 
            }

            return tipPerPerson;
        }


        public decimal CalculateTipPerPersonBasedOnPatrons(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (price <= 0 || numberOfPatrons <= 0 || tipPercentage < 0)
            {
                throw new ArgumentException("Invalid arguments: price must be positive, number of patrons must be positive, and tip percentage must be non-negative.");
            }
            var tp = (decimal)tipPercentage;
            var totalTip = price * (tp / 100);

            var tipPerPerson = totalTip / numberOfPatrons;

            return Math.Round(tp, 2);
        }

    }
}
