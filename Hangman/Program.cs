namespace Hangman
{
    internal class Program
    {
        static List<string> secretWords = new List<string>();
        
        static void Main(string[] args)
        {
            int random = new Random().Next(0, secretWords.Count +1);
            FillSecretWords();
            Console.WriteLine("Guess Animals");
            Console.WriteLine("Guess letter");
            string guessedLetter = Console.ReadLine();
            
            string selectRandomWord = secretWords[random].ToLower();
            
            bool ifPlayerWantsPlayMore = true;
            List<string> consoleWrite = new List<string>();
            do
            {
                int maxTriesAllowedAsPerLengthOfWord = selectRandomWord.Length * 50 / 100;
                int nonMatchingLetterCount = 0;
                int matchedLetterCount = 0;

                for (int i = 0; i < selectRandomWord.Length; i++)
                {
                    consoleWrite.Add("_ ");
                }
                for (int i = 0; i < selectRandomWord.Length; i++)
                {
                    bool matchedChar = selectRandomWord.Contains(guessedLetter, StringComparison.OrdinalIgnoreCase);
                             
                    if (!matchedChar)
                    {
                        nonMatchingLetterCount++;
                        if (nonMatchingLetterCount > maxTriesAllowedAsPerLengthOfWord)
                        {
                            Console.WriteLine("You loose");
                            break;
                        }

                        Console.WriteLine("Wrong guess. Please guess new letter");
                        i--;
                        
                        guessedLetter = Console.ReadLine();
                        
                    }
                    else
                    {
                        matchedLetterCount++;
                        int selectedLetterIndex = selectRandomWord.IndexOf(guessedLetter, StringComparison.OrdinalIgnoreCase);
                        if (selectedLetterIndex < 0)
                        {
                            selectedLetterIndex = 0;
                        }
                        selectRandomWord =  selectRandomWord.Remove(selectedLetterIndex, 1);
                        selectRandomWord = selectRandomWord.Insert(selectedLetterIndex, "$");
                        consoleWrite[selectedLetterIndex] = consoleWrite[selectedLetterIndex].Replace("_", guessedLetter);
                        for (int j = 0; j < consoleWrite.Count; j++)
                        {
                            Console.Write(consoleWrite[j]);
                        }
                        
                        Console.WriteLine("\n");
                        

                        if (matchedLetterCount == selectRandomWord.Length)
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
                    ifPlayerWantsPlayMore = false;
                    break;
                }
                random = new Random().Next(0, secretWords.Count + 1);
                selectRandomWord = secretWords[random];
                Console.Clear();
                guessedLetter = Console.ReadLine();
                consoleWrite.Clear();
            } 
            while (ifPlayerWantsPlayMore);
            
            
        }

        static void FillSecretWords()
        {
            secretWords.Add("Snkke");
            secretWords.Add("Lizard");
            secretWords.Add("Anaconda");
            secretWords.Add("Hippopotamus");
            secretWords.Add("Monkey");
            secretWords.Add("Penguin");
            secretWords.Add("Kangaroo");
            secretWords.Add("Chihuahua");
            secretWords.Add("Jellyfish");
            secretWords.Add("Gazelle");
            secretWords.Add("Shark");
            secretWords.Add("Hyena");
            secretWords.Add("Lemur");
            secretWords.Add("Limpet");
            secretWords.Add("Llama");
            secretWords.Add("Ladybug");
            secretWords.Add("Megalodon");
            secretWords.Add("Lemming");
            secretWords.Add("Mongoose");
            secretWords.Add("Pelican");
            secretWords.Add("Puma");
            secretWords.Add("Salamander");
            secretWords.Add("Torkie");
            secretWords.Add("Toxodon");
            secretWords.Add("Walrus");
            secretWords.Add("Zonkey");
            secretWords.Add("Xiaosaurus");
            secretWords.Add("Urial");


        }
    }
}