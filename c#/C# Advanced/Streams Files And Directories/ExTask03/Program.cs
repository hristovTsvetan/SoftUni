using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExTask03
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = Path.Combine("Files", "text.txt");
            string wordFile = Path.Combine("Files", "words.txt");
            string[] textFileArr = File.ReadAllLines(textFile);
            string[] searchedWordsArr = File.ReadAllLines(wordFile);

            Dictionary<string, int> searchedWords = LoadSearchedWordsInDict(searchedWordsArr);
            List<string> words = RemovePunctuations (textFileArr);
            CountSearchedWords(searchedWords, words);
            Dictionary<string, int> ReFormatedWords = ReFormatKeysOnDictionary(searchedWordsArr, searchedWords);

            WriteResultInFile(ReFormatedWords, "actualResult.txt");
            ReFormatedWords = ReFormatedWords.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            if(CompareWithExpectedResults(ReFormatedWords))
            {
                Console.WriteLine("Files are same!");
            }
            else
            {
                Console.WriteLine("Files are different!");
            }
            
        }

        public static bool CompareWithExpectedResults(Dictionary<string, int> sortedWords)
        {
            var expectedWords = File.ReadAllLines(@"../../../Files/expectedResult.txt");
            if(sortedWords.Count != expectedWords.Length)
            {
                return false;
            }
            int index = 0;
            foreach (var row in sortedWords)
            {
                string curLine = $"{row.Key} - {row.Value}";
                if(curLine != expectedWords[index++])
                {
                    return false;
                }
            }

            return true;
        }

        public static void WriteResultInFile(Dictionary<string, int> words, string outputFile)
        {
            using (var sw = new StreamWriter(@"../../../Files/"+ outputFile))
            {
                foreach (var word in words)
                {
                    string line = $"{word.Key} - {word.Value}";
                    var test = Encoding.UTF8.GetBytes(line);
                    sw.WriteLine(line);
                }
            }
        }

        public static Dictionary<string, int> ReFormatKeysOnDictionary(string[] words, Dictionary<string, int> wordsDict)
        {
            Dictionary<string, int> ReFormatedWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if(wordsDict.ContainsKey(word.ToLower()))
                {
                    ReFormatedWords[word] = wordsDict[word.ToLower()];
                }
            }

            return ReFormatedWords;
        }

        private static void CountSearchedWords(Dictionary<string, int> searchedWords, List<string> words)
        {
            foreach (var word in words)
            {
                if (searchedWords.ContainsKey(word.ToLower()))
                {
                    searchedWords[word.ToLower()]++;
                }
            }
        }

        public static Dictionary<string, int> LoadSearchedWordsInDict(string[] searchedWordsArr)
        {
            Dictionary<string, int> searchedWords = new Dictionary<string, int>();
            foreach (var word in searchedWordsArr)
            {
                if(!searchedWords.ContainsKey(word.ToLower()))
                {
                    searchedWords[word.ToLower()] = 0;
                }
            }
            return searchedWords;
        }

        public static List<string> RemovePunctuations(string[] textFileArr)
        {
            List<String> allWords = new List<string>();
            for (int i = 0; i < textFileArr.Length; i++)
            {
                string curLine = textFileArr[i];
                string[] tempArr = curLine.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                for (int j = 0; j < tempArr.Length; j++)
                {
                    string curWord = tempArr[j];
                    while(char.IsPunctuation(curWord[0]))
                    {
                        curWord = curWord.Substring(1);
                    }
                    while(char.IsPunctuation(curWord[curWord.Length - 1]))
                    {
                        curWord = curWord.Substring(0, curWord.Length - 1);
                    }
                    tempArr[j] = curWord;
                }
                allWords.AddRange(tempArr);
            }

            return allWords;
        }
    }
}
