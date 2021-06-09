using System;
using System.Linq;
using System.Text;

namespace DescribePreviousRowOOP
{
    #region OutputExample
    //6 //n
    //1 //starting point
    //11
    //21
    //1211
    //111221
    //3112211
    #endregion

    class Program
    {
        static string DescribePreviousRow(string row)
        {
            StringBuilder result = new StringBuilder();

            while (row!=string.Empty)
            {
                char letter = row[0];
                int currentCount = row.TakeWhile(l => l == letter).Count();
                result.Append(currentCount);
                result.Append(letter);
                row=string.Join("",row.Skip(currentCount));
            }
            
            return result.ToString();
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string startingPoint = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                if (startingPoint.Any(x => !char.IsDigit(x)))
                {
                    Console.WriteLine("Row can't be described!");
                }

                Console.WriteLine(startingPoint);

                startingPoint = DescribePreviousRow(startingPoint);
            }
        }
    }
}
