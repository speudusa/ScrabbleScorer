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


            //SELECT WHICH METHOD
            Console.WriteLine("Your Scrabble Scorer App!\n How would you like to score your points today?" +
                "\n 1: Scrabble - the traditional scoring method" +
                "\n 2: Simple Score - each letter is worth 1 point " +
                "\n 3: Bonus Vowels - vowels are worth 3 points; consonants are worth 1 point");
            string inputPoints = Console.ReadLine();

            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
            string inputWord = Console.ReadLine();

            if (inputWord != "STOP")
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

                    int totalScore = letterScore.Sum();                             //calc total using LINQ method *will need to provide*               

                    Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");  //print word and score

                }

                //SIMPLE SCORE
                else if (inputPoints == "2")
                {
                    int totalScore = 0;
                    foreach (char ch in lowerWord)
                    {
                        totalScore += 1;
                    }
                    Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");  //print word and score
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
                    Console.WriteLine($"Your word: {inputWord} is worth {totalScore}");

                }

                else
                {
                    Console.WriteLine("Thank you for playing.");
                }



            }//if


            //Thinking of a way to call method again
            //do i need to be able to do this or will one pass through each be enough??
            Console.WriteLine("Would you like to enter another word agian? Y/N");
            string again = Console.ReadLine();
            if(again.ToUpper() == "Y")
            {
                Console.WriteLine("Cool. Cool. Cool. We're working on that");
                //call method again?
                //prompt, to pick method?? or use same method??
                //new word passes to method
                    //constructor would take one method? for simple and bonus vowels
                        //what bout traditional scorer?  could make oldSK a const???  can i use a const between classes????
            }
            //else thanks for playing


        }//MAIN
    }//class
}//namespace
    

