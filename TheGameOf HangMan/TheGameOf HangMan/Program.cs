using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// This program wiill implement a game that reads a list of words from a file and in the order from 
// 0 to 10 the words will be picked randomly.
namespace TheGameOf_HangMan
{
    class Program
    {
        const int ARRAY_LENGTH = 10;

        static void Main(string[] args)
        {
            String sFileName;
            StreamReader ioInputFile;
            string[] wordList = new string[ARRAY_LENGTH];
            Console.WriteLine("Enter the file name");
            sFileName = Console.ReadLine();
            ioInputFile = new StreamReader(sFileName);

            //Console.WriteLine("file name is {0}", sFileName);
            int i = 0;

            // storing into the array list
            while (!ioInputFile.EndOfStream)
            {
                wordList[i] = ioInputFile.ReadLine();
                i = i + 1;
            }

            //display file info.
            //for (int j = 0; j < wordList.Length; j++) {
            //    Console.WriteLine("{0}", wordList[j]);

            //}
            string playagain = "Y";
            while (playagain == "Y" || playagain == "y")
            { 

                Random numb = new Random();
                int r;



                r = numb.Next(0, 10);  // returns random number between 0 and 10
                //Console.WriteLine("\n\nrandom number is {0}\ncourselist word is {1}", r, wordList[r]);

                string guessWord = wordList[r];
                Console.WriteLine("Number of characters to guess are {0}", guessWord.Length);

                for (int j = 0; j < guessWord.Length; j++)
                {
                    //Console.Write("_ " );  //writes the underscore to be displayed in place of the characters
                    guessWord = guessWord.Remove(j, 1).Insert(j, "_");   //writes the underscore to be displayed in place of the characters

                }
                int inCorrectGuess = 0;
                while (wordList[r].CompareTo(guessWord) != 0 && inCorrectGuess < 6)
                {
                    string guessLetter;
                    Console.WriteLine("Guess a letter: {0}", guessWord);
                    guessLetter = Console.ReadLine();

                    char matched = 'n';
                    int matchedLocation;
                    matchedLocation = wordList[r].IndexOf(guessLetter);
                    while (matchedLocation >= 0 && guessLetter.Length > 0)
                    {
                        matched = 'y';
                        // remove underscore and replace with guessletter from the user
                        guessWord = guessWord.Remove(matchedLocation, 1).Insert(matchedLocation, guessLetter.ToString());
                        // if the letter is reapeated get next location 
                        matchedLocation = wordList[r].IndexOf(guessLetter, matchedLocation + 1);
                    }
                    if (matched == 'n' && guessLetter.Length > 0)
                    {
                        inCorrectGuess++;
                        displayHangman(inCorrectGuess);
                        Console.WriteLine("Wrong guess, chances left to guess a letter: {0}", 6 - inCorrectGuess);
                    }

                }
                if (wordList[r].CompareTo(guessWord) == 0)
                {
                    Console.WriteLine("The word is : {0}", guessWord);
                    Console.WriteLine("Congratulations! You are a winner!");

                }
                else
                {
                    Console.WriteLine("Number of incorrect guesses: {0}.\a Sorry, you lost!", inCorrectGuess);

                }
                Console.WriteLine("Would like to play again? (Enter Y for yes, or N fo no)");
                playagain = Console.ReadLine();

        }
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();

        }// end of main

        // display hangman
        public static void displayHangman(int incorrectNum)
        {
            for (int num = 1; num <= 3; num++)
            {
                switch (num)
                {
                    case 1:
                        Console.Write("  _____\n");
                        Console.Write("  O    |");
                        break;
                    case 2:
                        if (incorrectNum == 1)
                        Console.Write("\n       |");

                        if (incorrectNum == 2)
                            Console.Write("\n  |    |");

                        if (incorrectNum == 3)
                            Console.Write("\n/ |    |");

                        if (incorrectNum > 3)
                            Console.Write("\n/ | \\  |");
                       break;

                    case 3:
                        if (incorrectNum < 5)
                            Console.Write("\n       |");

                        if (incorrectNum == 5)
                            Console.Write("\n /     |");

                        if (incorrectNum == 6)
                            Console.Write("\n / \\   |");
                        
                        Console.Write("\n_______|\n");
                        break;
                }// end of switch

            }// end for
        }// end of displayHangman method

    }// end class program
}// end project
