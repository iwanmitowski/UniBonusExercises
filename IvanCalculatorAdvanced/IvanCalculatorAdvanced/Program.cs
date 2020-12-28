using System;

namespace IvanCalculatorAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double number1 = 0;
            double number2 = 0;

            while (true)
            {
                Console.Write("Type a number:");
                string input1 = Console.ReadLine();
                if (!double.TryParse(input1, out number1))
                {
                    Console.WriteLine("Not a number, write another one:");
                }
                else
                {
                    break;
                }
                
            }
            while (true)
            {
                Console.Write("Type a number:");
                string input2 = Console.ReadLine();
                if (!double.TryParse(input2, out number2))
                {
                    Console.WriteLine("Not a number, write another one:");
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine("Choose an option from these bellow:");
            Console.WriteLine("     a - Add");
            Console.WriteLine("     s - Substract");
            Console.WriteLine("     m - Multiply");
            Console.WriteLine("     d - Divide");
            string choice = Console.ReadLine();
            double result = 0;
            while (choice == "a" || choice == "s" || choice == "m" || choice == "d")
            {
                switch (choice)
                {
                    case "a":
                        result = number1 + number2;
                        break;
                    case "s":
                        result = number1 - number2;
                        break;
                    case "m":
                        result = number1 * number2;
                        break;
                    case "d":
                        result = number1 / number2;
                        break;


                    default:
                        Console.WriteLine("Choose an option from these above:");
                        break;
                }
                Console.WriteLine($"Your choice:{choice}");
                break;
            }
            Console.WriteLine($"Your result:{result}");


            








        }
    }
}
