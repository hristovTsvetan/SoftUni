using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam17December2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> createdDolls = new Dictionary<string, int>();
            FillToysInDictionary(createdDolls);

            int[] materialsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] magicLvlArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> materials = new Stack<int>(materialsArr);
            Queue<int> magicLvls = new Queue<int>(magicLvlArr);

            while (materials.Any() && magicLvls.Any())
            {
                int curMaterial = materials.Peek();
                int curMagic = magicLvls.Peek();

                if (IsZero(materials, magicLvls))
                {
                    continue;
                }

                int result = curMaterial * curMagic;
                if (result < 0)
                {
                    IsNegativeResult(materials, magicLvls, curMaterial, curMagic);
                    continue;
                }

                IsPositiveResult(createdDolls, materials, magicLvls, curMaterial, result);

            }

            PrintResult(createdDolls, materials, magicLvls);
        }

        private static int IsPositiveResult(Dictionary<string, int> createdDolls, Stack<int> materials, Queue<int> magicLvls, int curMaterial, int result)
        {
            switch (result)
            {
                case 400:
                    createdDolls["Bicycle"]++;
                    RemoveBothElements(materials, magicLvls);
                    break;
                case 300:
                    createdDolls["Teddy bear"]++;
                    RemoveBothElements(materials, magicLvls);
                    break;
                case 250:
                    createdDolls["Wooden train"]++;
                    RemoveBothElements(materials, magicLvls);
                    break;
                case 150:
                    createdDolls["Doll"]++;
                    RemoveBothElements(materials, magicLvls);
                    break;
                default:
                    magicLvls.Dequeue();
                    curMaterial = materials.Pop();
                    curMaterial += 15;
                    materials.Push(curMaterial);
                    break;
            }

            return curMaterial;
        }

        private static void IsNegativeResult(Stack<int> materials, Queue<int> magicLvls, int curMaterial, int curMagic)
        {
            int result = curMaterial + curMagic;
            materials.Pop();
            magicLvls.Dequeue();
            materials.Push(result);
        }

        private static void PrintResult(Dictionary<string, int> createdDolls, Stack<int> materials, Queue<int> magicLvls)
        {
            bool presentIsCrafted = false;

            if (createdDolls["Doll"] > 0 && createdDolls["Wooden train"] > 0 ||
                createdDolls["Teddy bear"] > 0 && createdDolls["Bicycle"] > 0)
            {
                presentIsCrafted = true;
            }

            if (presentIsCrafted)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magicLvls.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLvls)}");
            }

            foreach (var toy in createdDolls.OrderBy(x => x.Key))
            {
                if (toy.Value > 0)
                {
                    Console.WriteLine($"{toy.Key}: {toy.Value}");
                }
            }
        }

        public static void RemoveBothElements(Stack<int> materials, Queue<int> magicLvls)
        {
            materials.Pop();
            magicLvls.Dequeue();
        }

        public static void FillToysInDictionary(Dictionary<string, int> createdDolls)
        {
            createdDolls["Doll"] = 0;
            createdDolls["Wooden train"] = 0;
            createdDolls["Teddy bear"] = 0;
            createdDolls["Bicycle"] = 0;
        }

        public void IsPositive(Stack<int> materials, Queue<int> magicLvls)
        {

        }

        public static bool IsZero(Stack<int> materials, Queue<int> magicLvls)
        {
            int curMaterial = materials.Peek();
            int curMagic = magicLvls.Peek();

            bool isZero = false;

            if(curMaterial == 0 || curMagic == 0)
            {
                isZero = true;
            }

            if (curMaterial == 0)
            {
                materials.Pop();
            }
            if (curMagic == 0)
            {
                magicLvls.Dequeue();
            }

            return isZero;
        }

       
    }
}
