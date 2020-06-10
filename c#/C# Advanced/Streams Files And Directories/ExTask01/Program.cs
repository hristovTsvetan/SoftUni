using System;
using System.IO;
using System.Linq;

namespace FileAndStreamsEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("files", "input.txt");
            var fr = new StreamReader(path);
            string[] charForReplace = new string[] { "-", ",", ".", "!", "?" };

            int rowCounter = 0;
            while(!fr.EndOfStream)
            {
                string line = fr.ReadLine();
                if(rowCounter%2 == 0)
                {
                    foreach (var character in charForReplace)
                    {
                        if(line.Contains(character))
                        {
                            line = line.Replace(character, "@");
                        }
                    }
                    string[] tempArr = line.Split(" ").Reverse().ToArray();
                    line = string.Join(" ", tempArr);
                    Console.WriteLine(line);
                }
                rowCounter++;
            }
        }
    }
}
