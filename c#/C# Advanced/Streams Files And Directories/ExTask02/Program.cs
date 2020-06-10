using System;
using System.IO;

namespace ExTask02
{
    class Program
    {
        static void Main(string[] args)
        {

            var pathInput = Path.Combine("Files", "Input.txt");
            var dataFile = File.ReadAllLines(pathInput);

            string[] allRowsConverted = new string[dataFile.Length];
            int index = 0;

            foreach (var line in dataFile)
            {
                int punctuationCounter = 0;
                int letterCounter = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if(char.IsPunctuation(line[i]))
                    {
                        punctuationCounter++;
                    }
                    else if(char.IsLetter(line[i]))
                    {
                        letterCounter++;
                    }
                }
                allRowsConverted[index++] = $"Line {index}: {line} ({letterCounter})({punctuationCounter})";
            }

            File.WriteAllLines(@"..\..\..\Files\Output.txt", allRowsConverted);

        
        }
    }
}
