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
            int random = rnd.Next(0,secretWords.Count);
            string selectedRandomWord = secretWords[random].ToLower();
            Console.WriteLine("Guess Animals");
            
            
            
            bool ifPlayerWantsPlayMore = true;
            List<string> outputTextToConsole = new List<string>();
            do
            {
                int maxTriesAllowedAsPerLengthOfWord = selectedRandomWord.Length * 50 / 100;
                int nonMatchingLetterCount = 0;
                int matchedLetterCount = 0;
                int SelectedRandomWordLength = selectedRandomWord.Length;
                Console.WriteLine("Guess letter");
                ColorOutputToConsole(ConsoleColor.DarkBlue, ConsoleColor.White, $"You have total {maxTriesAllowedAsPerLengthOfWord} tries to guess letter");
                string guessedLetter = Console.ReadLine();

                for (int i = 0; i < SelectedRandomWordLength; i++)
                {
                    outputTextToConsole.Add(" _ ");
                }

                do
                {
                    bool matchedChar = selectedRandomWord.Contains(guessedLetter, StringComparison.OrdinalIgnoreCase);

                    if (!matchedChar)
                    {
                        nonMatchingLetterCount++;
                        ColorOutputToConsole(ConsoleColor.Red, ConsoleColor.White, $"Wrong guess. Try new letter. You have now {maxTriesAllowedAsPerLengthOfWord- nonMatchingLetterCount} attempt remaining");
                        PrintOutputToConsole(outputTextToConsole);

                        guessedLetter = Console.ReadLine();

                    }
                    else
                    {
                        List<int> selectedLetterIndexes = new List<int>();
                        for (int j = 0; j < SelectedRandomWordLength; j++)
                        {
                            string selectedLetterFromRandomWord = selectedRandomWord[j].ToString();
                            if (string.Equals(selectedLetterFromRandomWord, guessedLetter, StringComparison.CurrentCultureIgnoreCase))
                            {
                                selectedLetterIndexes.Add(j);
                                matchedLetterCount++;
                            }
                        }

                        foreach (var item in selectedLetterIndexes)
                        {
                            outputTextToConsole[item] = outputTextToConsole[item].Replace("_", guessedLetter);
                        }

                        PrintOutputToConsole(outputTextToConsole);


                        if (matchedLetterCount == SelectedRandomWordLength)
                        {
                            Console.WriteLine("Congrats you won");
                            break;
                        }
                        guessedLetter = Console.ReadLine();

                    }

                } while (nonMatchingLetterCount < maxTriesAllowedAsPerLengthOfWord);
                
                if (nonMatchingLetterCount >= maxTriesAllowedAsPerLengthOfWord)
                {
                    ColorOutputToConsole(ConsoleColor.DarkRed, ConsoleColor.White, "You loose");
                }
                
                ColorOutputToConsole(ConsoleColor.DarkYellow, ConsoleColor.White, "Press Y if you want to try new word");
                ColorOutputToConsole(ConsoleColor.Black, ConsoleColor.White, "");
                string input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
                random = rnd.Next(secretWords.Count);
                selectedRandomWord = secretWords[random];
                Console.Clear();
                outputTextToConsole.Clear();
            } 
            while (ifPlayerWantsPlayMore);
                        
        }

        static void PrintOutputToConsole(List<string> input)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

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