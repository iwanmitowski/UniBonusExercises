using System;
using System.Linq;

namespace IvanCafeteriaLiusi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise: https://docs.google.com/document/d/1qYRcSfb1l7rXVv3JCZxnRr-KN1cCkeg8w0HxJAGg32M/edit?fbclid=IwAR2owtR1gyKcKeYUZ7CuYlifcRlHj0K7BipIhiSgsxV49KpzxNchVX8lxH4

            double totalSum = 0;
            
            //The cafeteria works with 10 tables!
            Console.WriteLine("Въведете 'Начало на смяната', за да започнете работния ден.");
            string shiftType = Console.ReadLine();
            while (shiftType.ToLower()!="начало на смяната")
            {
                shiftType = Console.ReadLine();
            }
            
            string[] clientName = new string[10];
            string[] product = new string[10];
            string[] productCount = new string[10];
            string[] productPrice = new string[10];
            double[] bill = new double[10];

            while (true)
            {
                int minBillIndex = 0;
                int maxBillIndex = 0;

                double minBill = double.MaxValue;
                double maxBill = 0;

                //Arrays
                Console.WriteLine("Въведете име на клиент");
                clientName = FillingClientNameArray();
                Console.WriteLine("Въведете aртикул");
                product = FillingArray();
                Console.WriteLine("Въведете брой aртикули");
                productCount = FillingArray();
                Console.WriteLine("Въведете цената на aртикулите");
                productPrice = FillingArray();
                bill = Bill(productCount, productPrice);

                for (int i = 0; i < clientName.Length; i++)
                {
                    Console.WriteLine(clientName[i]);
                }

                totalSum += Total(productCount, productPrice);

                if (bill.Min() < minBill || bill.Min() == 0)
                {
                    minBill = bill.Min();
                    minBillIndex = bill.ToList().IndexOf(bill.Min());
                }
                if (bill.Max() > maxBill)
                {
                    maxBill = bill.Max();
                    maxBillIndex = bill.ToList().IndexOf(bill.Max());
                }

                Console.WriteLine($"Клиент с най-ниска сметка Име: {clientName[minBillIndex]} със сметка:{bill[minBillIndex]}");
                Console.WriteLine($"Клиент с най-висока сметка Име: {clientName[maxBillIndex]} със сметка:{bill[maxBillIndex]}");

                Console.WriteLine("Ако това е краят на смяната въведете 'край на смяната' ");
                shiftType = Console.ReadLine();
                if (shiftType == "край на смяната")
                {

                    Console.WriteLine();
                    Console.WriteLine("Смяната приключи.");
                    break;
                }

                Console.WriteLine("Минаха 15 минути.");
                Console.WriteLine("Клиентите стават. Подгответе се за нови такива.");
                Console.WriteLine();
            }


            Console.WriteLine($"Дневен оборот: {totalSum}");
            Console.WriteLine($"Надник {totalSum * 0.1:f2} лв. ");


        }

        //Filling array in general
        static string[] FillingArray()
        {
            string[] arr = new string[10];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Маса номер {i + 1}:");
                arr[i] = Console.ReadLine();

            }
            return arr;
        }

        //Filling client name
        static string[] FillingClientNameArray()
        {
            string[] arr = new string[10];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Маса номер {i + 1}:");

                arr[i] = Console.ReadLine();
                string currentName = arr[i];
                int similarCounter = 0;

                foreach (string item in arr)
                {
                    if (currentName == item)
                    {
                        similarCounter++;
                    }
                    if (similarCounter > 1)
                    {
                        Console.WriteLine("Моля въведете и фамилия");
                        arr[i] = Console.ReadLine();
                        break;
                    }
                }


            }
            return arr;
        }

        //TotalSum
        static double[] Bill(string[] productCount, string[] productPrice)
        {
            double[] arr = new double[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = int.Parse(productCount[i]) * double.Parse(productPrice[i]);
            }

            return arr;
        }

        //Bill
        static double Total(string[] productCount, string[] productPrice)
        {
            double sum = 0;
            double[] arr = Bill(productCount, productPrice);
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}
