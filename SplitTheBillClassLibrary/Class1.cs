using System.Linq.Expressions;

namespace SplitTheBillClassLibrary
{
    /// <summary> This class represents the bill and defines methods for splitting the bill. </summary>
    /// <author>Saurav Dahal</author>
    public class Bill
    {
        public static decimal SplitAmount(decimal amount, int numberOfPeople)
        {
            try
            {
                if (numberOfPeople <= 0)
                {
                    Console.WriteLine("Number of people must be greater than zero.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return amount / numberOfPeople;
        }
    }
}
