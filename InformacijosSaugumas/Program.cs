using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas
{
    internal class Program
    {

        static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        static string Encrypt(string plainText, string key)
        {
            string encryptedText = "";
            plainText = plainText.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    int plainTextIndex = Array.IndexOf(alphabet, c);
                    int keyCharIndex = Array.IndexOf(alphabet, key[keyIndex % key.Length]);
                    int encryptedIndex = (plainTextIndex + keyCharIndex) % alphabet.Length;
                    encryptedText += alphabet[encryptedIndex];
                    keyIndex++;
                } else
                {
                    encryptedText += c;
                }
            }
            return encryptedText;
        }

        static string Decrypt(string cypherText, string key)
        {
            string decryptedText = "";
            cypherText = cypherText.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;

            foreach (char c in cypherText)
            {
                if (char.IsLetter(c))
                {
                    int ciphertextIndex = Array.IndexOf(alphabet, c);
                    int keyCharIndex = Array.IndexOf(alphabet, key[keyIndex % key.Length]);
                    int decryptedIndex = (ciphertextIndex - keyCharIndex + alphabet.Length) % alphabet.Length;
                    decryptedText += alphabet[decryptedIndex];
                    keyIndex++;
                }
                else
                {
                    decryptedText += c;
                }
            }
            return decryptedText;
        }

        static string ASCIIEncrypt(string plainText, string key)
        {
            string encryptedText = "";
            int keyIndex = 0;

            foreach (char c in plainText)
            {
                int charValue = (int)c;

                // Check if the character is a printable ASCII character
                if (charValue >= 32 && charValue <= 126)
                {
                    int encryptedCharValue = (charValue + key[keyIndex % key.Length]) % 127;

                    // Handle wrap around
                    if (encryptedCharValue < 32)
                    {
                        encryptedCharValue += 95;
                    }

                    encryptedText += (char)encryptedCharValue;
                    keyIndex++;
                }
                else
                {
                    // For non printable characters, just append them unchanged.
                    encryptedText += c;
                }
            }
            return encryptedText;
        }

        static string ASCIIDecrypt(string cypherText, string key)
        {
            string decryptedText = "";
            int keyIndex = 0;

            foreach (char c in cypherText)
            {
                int charValue = (int)c;

                // Check if the character is printable ASCII character
                if (charValue >= 32 && charValue <= 126)
                {
                    int decryptedCharValue = ((charValue - 32) - (key[keyIndex % key.Length] - 32) + 95) % 95 + 32;


                    decryptedText += (char)decryptedCharValue;
                    keyIndex++;
                } else
                {
                    // For non-printable characters, just append them unchanged
                    decryptedText += c;
                }
            }
            return decryptedText;
        }

        static void Main(string[] args)
        {

            int app = 0;
            int choice;

            while (app == 0)
            {
                Console.WriteLine("Pasirinkite funkcija, kuria norite naudoti:\n");
                Console.WriteLine("1. Kryptuoti naudojant Vigenere ir tik raides.\n");
                Console.WriteLine("2. Kryptuoti naudojant Vigenere ASCII koduote.\n");
                Console.WriteLine("3. Dekryptuoti naudojant Vigenere ir tik raides.\n");
                Console.WriteLine("4. Dekryptuoti naudojant Vigenere ASCII koduote.\n");
                Console.WriteLine("5. Iseiti.\n");
                choice = Int32.Parse(Console.ReadLine());
                

                if (choice == 1)
                {
                    Console.WriteLine("Enter the original text:");
                    string originalText = Console.ReadLine();

                    Console.WriteLine("Enter the key:");
                    string key = Console.ReadLine();

                    string encryptedText = Encrypt(originalText, key);
                    Console.WriteLine("Encrypted text: " + encryptedText);
                    Console.WriteLine("==============================================================================");
                } else if (choice == 2)
                {
                    Console.WriteLine("Enter the original text:");
                    string originalText = Console.ReadLine();

                    Console.WriteLine("Enter the key:");
                    string key = Console.ReadLine();

                    string encryptedText = ASCIIEncrypt(originalText, key);
                    Console.WriteLine("Encrypted text: " + encryptedText);
                    Console.WriteLine("==============================================================================");
                } else if (choice == 3)
                {
                    Console.WriteLine("Enter the encrypted text:");
                    string encryptedText = Console.ReadLine();

                    Console.WriteLine("Enter the key:");
                    string key = Console.ReadLine();

                    string decryptedText = Decrypt(encryptedText, key);
                    Console.WriteLine("Decrypted text: " + decryptedText);
                    Console.WriteLine("==============================================================================");
                } else if (choice == 4)
                {
                    Console.WriteLine("Enter the encrypted text:");
                    string encryptedText = Console.ReadLine();

                    Console.WriteLine("Enter the key:");
                    string key = Console.ReadLine();

                    string decryptedText = ASCIIDecrypt(encryptedText, key);
                    Console.WriteLine("Decrypted text: " + decryptedText);
                    Console.WriteLine("==============================================================================");
                } else
                {
                    app = 1;
                }
            }
            
        }
    }
}
