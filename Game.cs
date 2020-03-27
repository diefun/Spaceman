using System;

namespace Spaceman
{
    class Game
    {
        // FIELDS //
        public string codeWord;
        public string currentWord;
        public int maxNumGuesses;
        public int currentNumGuesses;
        public string[] listCodeWords = {"parallel", "house", "regular", "beautiful", "adjustment"};

        // CONSTRUCTORS //
        public Game()
        {
            Random rand = new Random();
            int lIndex = rand.Next(listCodeWords.Length);
            codeWord = listCodeWords[lIndex];
            maxNumGuesses = 5;
            currentNumGuesses = 0;
            foreach (int i in codeWord)
            {
                currentWord += "_";
            }
        }

        // PROPERTIES //
        public string CodeWord
        { get; set; }

        public string CurrentWord
        { get; set; }

        public int MaxNumGuesses
        { get; set; }

        public int CurrentNumGuesses
        { get; set; }

        public string[] ListCodeWords
        {
            get { return listCodeWords; }
            set { listCodeWords = value; }
        }


        // METHODS //
        Ufo u = new Ufo();

        public void Greet()
        {
            Console.WriteLine("=============\nUFO: The Game\n=============\nInstructions: save your friend from alien abduction by guessing the letters in the codeword");
        }

        public bool DidWin()
        {
            if (codeWord.Equals(currentWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLoose()
        {
            if (currentNumGuesses >= maxNumGuesses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Display()
        {
            Console.WriteLine(u.Stringify());
            Console.WriteLine(currentWord);
            Console.Write($"You have {maxNumGuesses} guesses. You used: ");
            Console.WriteLine(currentNumGuesses);
        }

        public void Ask()
        {
            Console.Write("Guess a letter: ");
            string guessLetter = Console.ReadLine();
            var guessChar = guessLetter.ToCharArray();
            if (guessChar.Length != 1)
            {
                Console.WriteLine("Guess one letter at a time.");
                return;
            }

            if (codeWord.Contains(guessChar[0]))
            {
                Console.WriteLine($"The letter {guessChar[0]} appears in the word.");
                for (int i = 0; i < codeWord.Length; i++)
                {
                    
                    if (codeWord[i] == guessChar[0])
                    {
                        currentWord = currentWord.Remove(i, 1).Insert(i, guessChar[0].ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Sorry! The letter {guessChar[0]} is not in the word...");
                currentNumGuesses++;
                u.AddPart();
            }
        }
    }
}