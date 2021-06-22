using System;
using System.Linq;

namespace PigLatin
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    string userInput = GetInput("Please input a word or sentence to translate to pig Latin");

        //    string translation = ToPigLatin(userInput);
        //    Console.WriteLine(translation);
        //}

        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        public static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            // 1st change:
            // I want to change this method so it returns if c.ToString() is contained in vowels
            return vowels.Contains(c);
            // return c.ToString() == vowels.ToString();
            
            // Now that I fixed this method, the program returns "rkay" for "mark"
        }

        public static string ToPigLatin(string word)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' };
            word = word.ToLower();
            foreach(char c in specialChars)
            {
                foreach(char w in word)
                {
                    if (w == c)
                    {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        return word;
                    }
                }
                
            }

            bool noVowels = true;
            foreach(char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false;
                }
            }

            if (noVowels)
            {
                return word; 
            }

            char firstLetter = word[0];
            string output = "placeholder";
            if (IsVowel(firstLetter) == true)
            {
                // 4th change:
                // Change "ay" to "way" for the case where first letter is a vowel
                // This fixes our program for words that begin with a vowel, namely 'apple' and 'aardvark'
                // Now we just need to fix for sentences
                output = word + "way";
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }
                Console.WriteLine($"vowelIndex: {vowelIndex}");
                // 2nd change:
                // Change (vowelIndex + 1) to(vowelIndex) in order to include vowel in sub
                string sub = word.Substring(vowelIndex);
                // 3rd change:
                // Change (0, vowelIndex - 1) to (0, vowelIndex) because second parameter
                // of Substring is exclusive, not inclusive
                // After these two changes, we get expected output for:
                // heck, strong, tommy@email.com, Tommy, gym
                // Still need to fix bug for words that start with vowels and sentences
                string postFix = word.Substring(0, vowelIndex);
                Console.WriteLine($"sub: {sub}");
                Console.WriteLine($"postfix: {postFix}");
                output = sub + postFix + "ay";
            }

            return output;
        }
    }
}
