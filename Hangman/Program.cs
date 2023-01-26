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
            Console.WriteLine("Guess letter");
            string guessedLetter = Console.ReadLine();
            bool ifPlayerWantsPlayMore = true;
            List<string> outputTextToConsole = new List<string>();
            do
            {
                int maxTriesAllowedAsPerLengthOfWord = selectedRandomWord.Length * 50 / 100;
                int nonMatchingLetterCount = 0;
                int matchedLetterCount = 0;
                int SelectedRandomWordLength = selectedRandomWord.Length;

                for (int i = 0; i < SelectedRandomWordLength; i++)
                {
                    outputTextToConsole.Add("_ ");
                }

                
                for (int i = 0; i < SelectedRandomWordLength; i++)
                {
                    bool matchedChar = selectedRandomWord.Contains(guessedLetter, StringComparison.OrdinalIgnoreCase);
                             
                    if (!matchedChar)
                    {
                        nonMatchingLetterCount++;
                        if (nonMatchingLetterCount > maxTriesAllowedAsPerLengthOfWord)
                        {
                            Console.WriteLine("You loose");
                            break;
                        }

                        Console.WriteLine("Wrong guess. Please guess new letter");
                        PrintOutputToConsole(outputTextToConsole);
                        i--;
                        
                        guessedLetter = Console.ReadLine();
                        
                    }
                    else
                    {
                        
                        List<int> selectedLetterIndexes = new List<int>();
                        for (int j = 0; j < selectedRandomWord.Length; j++)
                        {
                            string selectedLetterFromRandomWord = selectedRandomWord[j].ToString();
                            if (string.Equals(selectedLetterFromRandomWord, guessedLetter, StringComparison.CurrentCultureIgnoreCase ))
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

                }
                Console.WriteLine("Press Y if you want to try new word");
                string input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
                random = rnd.Next(secretWords.Count);
                selectedRandomWord = secretWords[random];
                Console.Clear();
                guessedLetter = Console.ReadLine();
                outputTextToConsole.Clear();
            } 
            while (ifPlayerWantsPlayMore);
                        
        }

        static void PrintOutputToConsole(List<string> input)
        {
            for (int j = 0; j < input.Count; j++)
            {
                Console.Write(input[j]);
            }
            Console.WriteLine("\n");
        }


    }
}