using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private int _numberoflives;
        private int wordlistInt;
        private string chosenword;
        private string dashWord;
        private char[] wordProgress;

        public string ReturnWord()
        {
            return dashWord;
        }
        public HangmanGame()
        {
            string[] wordlist = { "the", "quick", "brown", "camel", "jumps", "over", "the","lazy","beyhond","pack","manage",
                "five","dozen","liquor","jugs","temple","unfair","talent","ranked","waited"};

            Random random = new Random();
            wordlistInt = random.Next(0, wordlist.Length);
            chosenword = wordlist[wordlistInt];

            for (int i = 0; i < chosenword.Length; i++)
            {
                dashWord += "-";
            }

            _renderer = new GallowsRenderer();
        }

        public void OverWrite(char charguess)
        {
            wordProgress = dashWord.ToCharArray();

            //if (input.Length > 0)
            for (int i = 0; i < chosenword.Length; i++)
            {
                if (chosenword[i] == charguess)
                {
                    wordProgress[i] = charguess;
                }
                //charguess = input[0].ToString();
                //charguess = charguess.ToLower();
            }
            dashWord = new string(wordProgress);
        }

        public void Run()
        {
            _numberoflives = 6;

            while (true)
            {
                _renderer.Render(5, 5, _numberoflives);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(ReturnWord());

                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What is your next guess: ");
                string guess = Console.ReadLine();
                guess = guess.ToLower();

                OverWrite(guess[0]);

                Console.WriteLine(ReturnWord());

                Console.WriteLine("The word has {0} characters", chosenword.Length);

                if (chosenword.Contains(guess))
                {
                    Console.WriteLine("The letter {0} you guess is contained in the chosen word", guess);
                }
                else if (!chosenword.Contains(guess))
                {
                    Console.WriteLine("The letter {0} is not contained in the word ", guess);

                    _numberoflives--;

                    
                }


                guess = new string(wordProgress);
                if (dashWord == chosenword)
                {
                    Console.WriteLine(" You Have Won!");
                }

                if (_numberoflives == 0)
                {
                    Console.WriteLine(" You Have Lost! The word is {0}", chosenword);
                }


                // {
                //Console.WriteLine(" You Have Lost! The word is {0}", chosenword);





                /*
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = Console.ReadLine();
                */

            }

        }
    }
}
