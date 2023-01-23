namespace Hangman
{
    internal class Program
    {
        static List<string> secretWords = new List<string>();
        
        static void Main(string[] args)
        {
            int totalWrongGuessesAllowed = 5;
            int random = new Random().Next(0, secretWords.Count +1);
            FillSecretWords();
            Console.WriteLine("Guess Animals");
            Console.WriteLine("Guess letter");
            string guessedLetter = Console.ReadLine();
            int nonMatchingLetterCount = 0;
            string selectRandomWord = secretWords[random];
            for (int i = 0; i < selectRandomWord.Length; i++)
            {
                
            }
            foreach (string letter in secretWords)
            {
                bool matchedChar = letter.Contains(guessedLetter, StringComparison.OrdinalIgnoreCase);
                if (!matchedChar)
                {
                    Console.WriteLine("Please guess new letter");
                    guessedLetter = Console.ReadLine();
                    if (nonMatchingLetterCount > totalWrongGuessesAllowed)
                    {
                        Console.WriteLine("You loose");
                        break;
                    }
                    nonMatchingLetterCount++;
                }
                else
                {

                }
            }
        }

        static void FillSecretWords()
        {
            secretWords.Add("Snake");
            secretWords.Add("Lizard");
            secretWords.Add("Anaconda");
            secretWords.Add("Hippopotamus");
            secretWords.Add("Monkey");
            secretWords.Add("Penguin");
            secretWords.Add("Kangaroo");
            secretWords.Add("Chihuahua");
            secretWords.Add("Freshwater Jellyfish");
            secretWords.Add("Gazelle");
            secretWords.Add("Goblin Shark");
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