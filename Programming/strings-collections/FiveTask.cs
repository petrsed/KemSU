using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FiveTask
{
    internal class FiveTask
    {
        static void Main(string[] args)
        {
            var DictionaryList = GetDictionaryList();
            string TrueNumber = "+380 12 345 67 89";

            ReplaceKeywords(DictionaryList, TrueNumber);
            Console.WriteLine("Success!");
        }

        static void ReplaceKeywords(List<List<string>> DictionaryList, string TrueNumber)
        {
            StreamReader OldFile = new StreamReader("OldText.txt");
            StreamWriter NewFile = new StreamWriter("NewText.txt");

            while (!OldFile.EndOfStream)
            {
                string Line = OldFile.ReadLine();

                foreach (List<string> Word in DictionaryList)
                {
                    string OldWord = Word[0];
                    string NewWord = Word[1];

                    Line = Line.Replace(OldWord, NewWord);
                }

                var RegexExperssion = new Regex(@"([(]\d{3}[)]\s{1}\d{3})-(\d{2})-(\d{2})");
                var Matches = RegexExperssion.Matches(Line);

                foreach (Match Match in Matches)
                {
                    Line = Line.Replace(Match.Value, TrueNumber);
                }

                NewFile.WriteLine(Line);
            }

            OldFile.Close();
            NewFile.Close();
        }


        static List<List<string>> GetDictionaryList()
        {
            var DictionaryList = new List<List<string>>();

            StreamReader DictionaryFile = new StreamReader("Dictionary.txt");
            while (!DictionaryFile.EndOfStream)
            {
                string Line = DictionaryFile.ReadLine();
                List<string> WordList = Line.Split('-').ToList();
                DictionaryList.Add(WordList);
            }

            DictionaryFile.Close();
            return DictionaryList;
        }
    }
}
