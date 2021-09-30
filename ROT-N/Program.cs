using System;
using System.Collections.Generic;

namespace Main
{
    public class ROT_N
    {
        private static List<string> upperAlphabets = new List<string>() {
            "A","B","C","D","E","F","G",
            "H","I","J","K","L","M","N",
            "O","P","Q","R","S","T","U",
            "V","W","X","Y","Z"
        };

        private static List<string> upperAlphabetsRev = new List<string>() {
            "Z","Y","X","W","V","U","T",
            "S","R","Q","P","O","N","M",
            "L","K","J","I","H","G","F",
            "E","D","C","B","A"
        };

        private static List<string> lowerAlphabets = new List<string>();
        private static List<string> lowerAlphabetsRev = new List<string>();

        static void Main(string[] args)
        {
            foreach (string str in upperAlphabets)
            {
                lowerAlphabets.Add(str.ToLower());
            }

            foreach (string str in upperAlphabetsRev)
            {
                lowerAlphabetsRev.Add(str.ToLower());
            }

            string word = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());

            //Encrypt(word, num);
            Decrypt(word, num);
        }

        private static void Encrypt(string word, int toSkip)
        {
            char[] encryptedWord = new char[word.Length];
            int pos = 0, newPos = 0, position = -1;
            bool upper;

            foreach (char c in word.ToCharArray())
            {
                position++;

                pos = upperAlphabets.IndexOf(c.ToString());
                if (pos == -1)
                {
                    pos = lowerAlphabets.IndexOf(c.ToString());
                    upper = false;
                }
                else
                {
                    upper = true;
                }

                newPos = (pos + toSkip) > 25 ? (pos + toSkip) % 26 : (pos + toSkip);

                encryptedWord[position] = upper ? char.Parse(upperAlphabets[newPos]) : char.Parse(lowerAlphabets[newPos]);
            }

            Console.WriteLine(encryptedWord);
        }

        private static void Decrypt(string word, int toRev)
        {
            char[] decryptedWord = new char[word.Length];
            int pos = 0, originalPos = 0, position = -1;
            bool upper;

            foreach (char c in word.ToCharArray())
            {
                position++;

                pos = upperAlphabetsRev.IndexOf(c.ToString());
                if(pos == -1)
                {
                    pos = lowerAlphabetsRev.IndexOf(c.ToString());
                    upper = false;
                }
                else
                {
                    upper = true;
                }

                originalPos = (pos + toRev) > 25 ? (pos + toRev) % 26 : (pos + toRev);

                decryptedWord[position] = upper ? char.Parse(upperAlphabetsRev[originalPos]) : char.Parse(lowerAlphabetsRev[originalPos]);
            }

            Console.WriteLine(decryptedWord);
        }
    }
}
