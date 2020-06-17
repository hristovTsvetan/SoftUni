using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceExam24Feb2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityHold = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> allHallsWithReservations = new Dictionary<string, List<int>>();

            string[] inputArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> input = new Stack<string>(inputArr);
            Queue<string> halls = new Queue<string>();

            int tempCapacity = capacityHold;
            while (input.Any())
            {
                string curELement = input.Pop();
                int curNumber;
                if (!int.TryParse(curELement, out curNumber))
                {
                    halls.Enqueue(curELement);
                }
                else
                {
                    if (halls.Any())
                    {
                        string curHall = halls.Peek();
                        if (tempCapacity >= curNumber)
                        {
                            FillDictionary(allHallsWithReservations, curNumber, curHall);
                            tempCapacity -= curNumber;
                        }
                        else
                        {
                            halls.Dequeue();
                            Console.WriteLine($"{curHall} -> {string.Join(", ", allHallsWithReservations[curHall])}");
                            tempCapacity = capacityHold;
                            if (halls.Any())
                            {
                                curHall = halls.Peek();
                                FillDictionary(allHallsWithReservations, curNumber, curHall);
                                tempCapacity -= curNumber;
                            }
                        }
                    }
                }
            }
        }

        private static void FillDictionary(Dictionary<string, List<int>> allHallsWithReservations, int curNumber, string curHall)
        {
            if (!allHallsWithReservations.ContainsKey(curHall))
            {
                allHallsWithReservations[curHall] = new List<int>();
            }
            allHallsWithReservations[curHall].Add(curNumber);
        }
    }
}
