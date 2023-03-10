namespace Hangman
{
    internal class Program
    {
        static List<string> secretWords = new List<string>()
        {
            "Snkke", "Lizard",
            "Anaconda", "Hippopotamus",
            "Monkey", "Penguin",
            "Kangaroo", "Chihuahua",
            "Jellyfish", "Gazelle",
            "Shark", "Hyena",
            "Lemur", "Limpet",
            "Llama", "Ladybug",
            "Megalodon","Lemming",
            "Mongoose", "Pelican",
            "Puma", "Salamander",
            "Torkie", "Toxodon",
            "Walrus", "Zonkey",
            "Xiaosaurus", "Urial"
        };
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            bool contineToPlay = true;
            List<string> correctLettersGuessedList = new List<string>();
            do
            {
                int random = rnd.Next(secretWords.Count);
                string selectedRandomWord = secretWords[random];
                int maxTriesAllowedAsPerLengthOfWord = selectedRandomWord.Length * 50 / 100;
                int noOfGuessesCount = 0;
                int matchedLetterCount = 0;
                int SelectedRandomWordLength = selectedRandomWord.Length;
                List<string> guessedLettersInGameSoFar = new List<string>();
                Console.Clear();
                Console.WriteLine("Guess Animals");
                Console.WriteLine("Guess letter");
                ColorOutputToConsole(ConsoleColor.DarkBlue, ConsoleColor.White, $"You have total {maxTriesAllowedAsPerLengthOfWord} tries to guess letter");
                

                for (int i = 0; i < SelectedRandomWordLength; i++)
                {
                    correctLettersGuessedList.Add(" _ ");
                }

                do
                {   
                    string guessedLetter = Console.ReadKey().KeyChar.ToString();
                    bool matchedChar = selectedRandomWord.Contains(guessedLetter, StringComparison.OrdinalIgnoreCase);


                    if (guessedLettersInGameSoFar.Contains(guessedLetter, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nYou have already guessed this letter");
                        
                    }
                    else if (!matchedChar )
                    {
                        noOfGuessesCount++;
                        ColorOutputToConsole(ConsoleColor.Red, ConsoleColor.White, $"\n Wrong guess. Try new letter. You have now {maxTriesAllowedAsPerLengthOfWord- noOfGuessesCount} attempt remaining");
                    }
                    
                    else
                    {
                        if (!correctLettersGuessedList.Contains(guessedLetter, StringComparer.OrdinalIgnoreCase))
                        {
                            for (int j = 0; j < SelectedRandomWordLength; j++)
                            {
                                string selectedLetterFromRandomWord = selectedRandomWord[j].ToString();
                                if (string.Equals(selectedLetterFromRandomWord, guessedLetter, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    correctLettersGuessedList[j] = correctLettersGuessedList[j].Replace(" _ ", guessedLetter);
                                    matchedLetterCount++;
                                }
                            }
                        }
                        
                        if (matchedLetterCount == SelectedRandomWordLength)
                        {
                            PrintOutputToConsole(correctLettersGuessedList);
                            Console.WriteLine("Congrats you won.");
                            guessedLettersInGameSoFar.Clear();
                            break;
                        }
                    }
                    guessedLettersInGameSoFar.Add(guessedLetter);
                    PrintOutputToConsole(correctLettersGuessedList);

                } while (noOfGuessesCount < maxTriesAllowedAsPerLengthOfWord);
                
                if (noOfGuessesCount >= maxTriesAllowedAsPerLengthOfWord)
                {
                    ColorOutputToConsole(ConsoleColor.DarkRed, ConsoleColor.White, $"You loose. The correct letter was {selectedRandomWord}");
                    guessedLettersInGameSoFar.Clear();
                }
                
                ColorOutputToConsole(ConsoleColor.DarkYellow, ConsoleColor.White, "Press Y if you want to try new word");
                ColorOutputToConsole(ConsoleColor.Black, ConsoleColor.White, "");
                string input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
                                
                correctLettersGuessedList.Clear();
            } 
            while (contineToPlay);
                        
        }

        static void PrintOutputToConsole(List<string> input)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n");

            for (int j = 0; j < input.Count; j++)
            {
                Console.Write(input[j]);
            }
            Console.WriteLine("\n");
        }

        static void ColorOutputToConsole(ConsoleColor background, ConsoleColor foreground, string input)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(input);
        }


    }
}