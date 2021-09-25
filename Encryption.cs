using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretAgentNew
{
    public class Encryption
    {
        // Instance Variables
        private string input;
        private int key;
        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        // Constructer
        public Encryption(string input, int key)
        {
            char[] encryptedMessage = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char letter = Char.ToLower(input[i]);

                if (letter == ' ')
                {
                    encryptedMessage[i] = ' ';
                    continue;
                }

                // if new line add ...

                if (Char.IsLetter(letter) == true)
                {
                    int letterPos = Array.IndexOf(alphabet, letter);

                    int newletterPos = (letterPos + key) % alphabet.Length;

                    if (letter <= 'a')
                    {
                        newletterPos = (letterPos + key) % alphabet.Length;
                    }

                    else if (letter >= 'z')
                    {
                        newletterPos = (letterPos - key) % alphabet.Length;
                    }

                    char newLetter = alphabet[newletterPos];

                    encryptedMessage[i] = newLetter;
                }
            }

            this.input = String.Join("", encryptedMessage);
            this.key = key;
        }

        public string Input { get; }
        public int Key { get; }

        // ToString()
        public override string ToString()
        {
            return input + " (key: " + key + ")";
        }
    }
}