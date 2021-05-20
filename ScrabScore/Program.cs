using System;
using System.Collections.Generic;
using System.Linq;  //need to give this to the students

namespace ScrabScore
{
    class Program
    {

        public static Dictionary<int, string> oldScoreKeeper = new Dictionary<int, string>()
    {
        {1, "a, e, i, o, u, l, n, r, s, t"},
        {2, "d, g"},
        {3, "b, c, m, p" },
        {4, "f, h, v, w, y" },
        {5, "k" },
        {8, "j, x" },
        {10, "q, z" }
    };

        public static void Main(string[] args)
        {
            //step 1: take old score keeper and flip it (ie: key => value; value => key)

            Dictionary<char, int> newScoreKeeper = new Dictionary<char, int>();


            //Loop that will let us use the new dictionary
            foreach (KeyValuePair<int, string> entry in oldScoreKeeper)
            {
                string strValue = entry.Value;
                string[] strChar = strValue.Split(", ");

                //when updataing new dictionary, convert to char (makes everything SO MUCH easier)
                foreach (string str in strChar)
                {
                    char ch = Convert.ToChar(str);
                    newScoreKeeper.Add(ch, entry.Key);
                }
            }

            Console.WriteLine("Your Scrabble Scorer App!\n Enter your word and I will calculate your score!");
            string input = Console.ReadLine();

            //string testWord = "Zoology";
            string lowerWord = input.ToLower();                          //reducing case issues
            

           //list to hold scores based on nSK values
            List<int> letterScore = new List<int>();

            foreach (KeyValuePair<char, int> score in newScoreKeeper)       //loop through dict
            {
                foreach (char ch in lowerWord)                              //loop through word
                {
                    if (score.Key == ch)                                    //look for match key
                    {
                        letterScore.Add(score.Value);                       //update list with match value
                    }
                }
            }

            int totalScore = letterScore.Sum();                             //calc total using LINQ method *will need to provide*

            Console.WriteLine($"Your word: {input} is worth {totalScore}");  //print word and score










        }
    }
}
    

