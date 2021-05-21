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
            //bool to trigger while loop
            bool done = false;


        //DICTIONARY UPDATE
            Dictionary<char, int> newScoreKeeper = new Dictionary<char, int>();     //step 1: take old score keeper and flip it (ie: key => value; value => key)

            foreach (KeyValuePair<int, string> entry in oldScoreKeeper)
            {
                string strValue = entry.Value;
                string[] strChar = strValue.Split(", ");

                foreach (string str in strChar)                                     //when updataing new dictionary, convert to char (makes everything SO MUCH easier)
                {
                    char ch = Convert.ToChar(str);
                    newScoreKeeper.Add(ch, entry.Key);
                }
            }


        //SELECT WHICH METHOD
            Console.WriteLine("Your Scrabble Scorer App!\n How would you like to score your points today?" +
                "\n 1: Scrabble - the traditional scoring method" +
                "\n 2: Simple Score - each letter is worth 1 point " +
                "\n 3: Bonus Vowels - vowels are worth 3 points; consonants are worth 1 point");
            string inputPoints = Console.ReadLine();
            
            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
            
            while (!done)
            {
                
                string inputWord = Console.ReadLine();

                if (inputWord == "STOP")                                            //start with this RIGHT AWAY
                {
                    Console.WriteLine("Thank you for playing.");
                    done = true;
                }
                else
                { 
                    string lowerWord = inputWord.ToLower();                          //reducing case issues

                    List<string> userWords = new List<string>();
                    userWords.Add(lowerWord);

                    if (inputPoints == "1")
                    {
                        //list to hold scores based on nSK values  -- KEEP AVAILABLE FOR ALL SCORE ALGORITHMS
                        List<int> letterScore = new List<int>();



                //SCRABBLE SCORE
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

                        //UPDATING OUR SCORE
                        int totalScore = 0;                                             //initial score, updated as we loop through letterScore list
                        foreach (int i in letterScore)                                  //loop through the list
                        {
                            totalScore += i;                                            //update total score by adding each list item
                        }

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");  //print word and score
                        Console.ResetColor();
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
                    }

                //SIMPLE SCORE
                    else if (inputPoints == "2")
                    {
                        int totalScore = 0;
                        foreach (char ch in lowerWord)
                        {
                            totalScore += 1;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");  //print word and score
                        Console.ResetColor();
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
                    }

                    //BONUS VOWELS
                    else if (inputPoints == "3")
                    {
                        int totalScore = 0;
                        foreach (char ch in lowerWord)
                        {
                            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                            {
                                totalScore += 3;
                            }
                            else
                            {
                                totalScore += 1;
                            }

                        }
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");  //print word and score
                        Console.ResetColor();
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
                    }


                }//if/else
            }//while

        }//MAIN
    }//class
}//namespace
    

