using System;

namespace cv4
{
    class Program
    {
        static void Main(string[] args)
        {
            string testText = "Toto je retezec predstavovany nekolika radky,\n"
                                 + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                                 + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                                 + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                                 + "posledni veta! Ahoj, máš covid?";
            StringStatistics stringStatistics = new StringStatistics(testText);
            string[] splittedText = stringStatistics.SplitStringToArray();


            Console.WriteLine("Number of worlds: {0}", stringStatistics.NumOfWords());
            Console.WriteLine("Number of sentences is:{0} ", stringStatistics.NumOfSentences());
            Console.WriteLine("Number of rows is:{0}", stringStatistics.NumOfRows());
            Console.Write("Longest words: ");
            foreach (string s in stringStatistics.LongestWords())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Shortest words: ");
            foreach (string s in stringStatistics.ShortestWords())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Most common words: ");
            foreach (string s in stringStatistics.MostCommonWords())
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("Alphabeticaly ordered words: ");
            foreach(string s in stringStatistics.SortText())
            {
                Console.Write(s+", ");
            }


            
        }
    }
}
