using System;
using System.Linq;
using System.Text;

namespace IvanKaspichanTrainStation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //The exercise:https://docs.google.com/document/d/1imhyr1cnuKQaaxKBZ4DT4E7U-ddBTrtb6a3bxIjeGus/edit?fbclid=IwAR0vIpDJi7SE1IVUT6g0uu-go8oPevJ1pTukNicXSS3TUtq4VIInFA5E12w


            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine("Въведете брой влакове: ");
            int numberOfTrains = int.Parse(Console.ReadLine());


            //Arrays


            string[] trainNum = new string[numberOfTrains];
            string[] timeGoing = new string[numberOfTrains];
            string[] timeComeing = new string[numberOfTrains];
            string[] startingPoint = new string[numberOfTrains];
            string[] endingPoint = new string[numberOfTrains];
            string[] type = new string[numberOfTrains];
            string[] numOfTickets = new string[numberOfTrains];


            //FillingTheArrays


            Console.WriteLine("Въведете номер на влаковете: ");
            trainNum = FillingArrays(numberOfTrains, trainNum);
            Console.WriteLine("Въведете час на тръгване: ");
            timeGoing = FillingArrays(numberOfTrains, timeGoing);
            Console.WriteLine("Въведете час на пристигане: ");
            timeComeing = FillingArrays(numberOfTrains, timeComeing);
            Console.WriteLine("Въведете начална точка на влаковете: ");
            startingPoint = FillingArrays(numberOfTrains, startingPoint);
            Console.WriteLine("Въведете крайна точка на влаковете: ");
            endingPoint = FillingArrays(numberOfTrains, endingPoint);
            Console.WriteLine("Въведете тип на влака: Б - за бърз и П - за пътнически");
            type = FillingArrays(numberOfTrains, type);
            Console.WriteLine("Въведете брой билети закупени за текущия влак:");
            numOfTickets = FillingArrays(numberOfTrains, numOfTickets);


            //FilteringByStartingAndEndingPoint


            Console.WriteLine("Филтриране по начална или крайна точка ще желаете?");

            
            while (true)
            {
                string filterStartEndAnswer = Console.ReadLine();
                if (filterStartEndAnswer == "начална")
                {
                    Console.Write("Началните точки са следните:");


                    Console.WriteLine(string.Join(", ", RemovingDuplicates(startingPoint)));
                    string inputStarting = Console.ReadLine();
                    for (int i = 0; i < startingPoint.Length; i++)
                    {
                        if (inputStarting == startingPoint[i])
                        {
                            Console.WriteLine($"Номер на влак {trainNum[i]}, час на тръгване {timeGoing[i]}, час на пристигане {timeComeing[i]}, начална точка {startingPoint[i]}, крайна точка {endingPoint[i]}, тип на влак {type[i]}, брой билети {numOfTickets[i]}.");
                        }

                    }
                    break;

                }
                else if (filterStartEndAnswer == "крайна")
                {
                    Console.Write("Крайните точки са следните:");

                    Console.WriteLine(string.Join(", ", RemovingDuplicates(endingPoint)));
                    string inputEnding = Console.ReadLine();

                    for (int i = 0; i < endingPoint.Length; i++)
                    {
                        if (inputEnding == endingPoint[i])
                        {
                            Console.WriteLine($"Номер на влак {trainNum[i]}, час на тръгване {timeGoing[i]}, час на пристигане {timeComeing[i]}, начална точка {startingPoint[i]}, крайна точка {endingPoint[i]}, тип на влак {type[i]}, брой билети {numOfTickets[i]}.");
                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Bъведете от горепосочените опции!");
                    continue;
                }
            }

            //FilteringByHour


            Console.WriteLine("Ще желаете ли да филтрираме по час и по интервал ?");
            string filterByHourAnswer = Console.ReadLine();
            while (true)
            {
                if (filterByHourAnswer == "да")
                {
                    Console.Write("Въведете час: ");
                    int[] hour = new int[2];
                    hour = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    Console.Write("Въведете интервал: ");
                    int interval = int.Parse(Console.ReadLine());
                    string timeGoingToInt = string.Join(" ", timeGoing);
                    int[] arrTimeGoingToInt = timeGoingToInt.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    for (int i = 0; i < arrTimeGoingToInt.Length; i += 2)
                    {

                        if (arrTimeGoingToInt[i] >= hour[0] && arrTimeGoingToInt[i] < hour[0] + interval)
                        {
                            if (i == 0)
                            {
                                Console.WriteLine($"Влак тръгващ от {startingPoint[i]} в {timeGoing[i]} часа за {endingPoint[i]}");

                            }
                            else if (i > timeGoing.Length)
                            {
                                Console.WriteLine($"Влак тръгващ от {startingPoint[i - timeGoing.Length + 1]} в {timeGoing[i - timeGoing.Length + 1]} часа за {endingPoint[i - timeGoing.Length + 1]}");
                            }
                            else
                            {
                                Console.WriteLine($"Влак тръгващ от {startingPoint[i - 1]} в {timeGoing[i - 1]} часа за {endingPoint[i - 1]}");
                            }
                        }

                    }
                    break;
                }
                else if (filterByHourAnswer == "не")
                {
                    Console.WriteLine("Добре.");
                    break;
                }


            }


            //income


            int sum = 0;
            for (int i = 0; i < type.Length; i++)
            {
                if (type[i].ToUpper() == "Б")
                {
                    sum += 10;
                }
                else if (type[i].ToUpper() == "П")
                {
                    sum += 5;
                }
            }

            Console.WriteLine($"Приходите за днес са: {sum} лева.");


            // AvgTotalTicketsForTheDay


            double avgTicketsForTheDay = 0;
            for (int i = 0; i < numberOfTrains; i++)
            {
                avgTicketsForTheDay += int.Parse(numOfTickets[i]);
            }
            Console.WriteLine($"Средно продадени билети за {numberOfTrains} влака са: {(int)(avgTicketsForTheDay / numberOfTrains)} броя.");


            //Min,Max tickets


            int maxTicketsTrain = numOfTickets.ToList().IndexOf(numOfTickets.Max());
            int minTicketsTrain = numOfTickets.ToList().IndexOf(numOfTickets.Min());


            Console.WriteLine($"Най-много билети закупени за {maxTicketsTrain + 1} влак.");
            Console.WriteLine($"Най-малко билети закупени за {minTicketsTrain + 1} влак.");
        }


        //FillingArrays
        static string[] FillingArrays(int number, string[] arr)
        {
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{i + 1} влак:");
                arr[i] = Console.ReadLine();
            }
            return arr;
        }



        //LoopForWritingArray
        static void LoopForWritingArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        //RemovingDuplicates
        static string[] RemovingDuplicates(string[] arr)
        {

            string[] arr2 = arr.Distinct().ToArray();

            return arr2;
        }

        
    }
}
