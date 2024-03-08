namespace Caesar_Cipher;

class Program
{
    static void Main(string[] args)
    {
        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


        Console.WriteLine("Enter your secret message: ");
        string input = Console.ReadLine().ToLower();
        char[] secretMessage = input.ToCharArray();
        char[] encryptedMessage = Encrypt(secretMessage, 3, alphabet);
        string encryptedString = new string(encryptedMessage);
        Console.WriteLine($"Your encoded message is: {encryptedString}");

        //If user wants to decrypt

        Console.WriteLine("Would you like to decrypt the message?(Y/N)");
        string decision = Console.ReadLine();
        if (decision.ToUpper() == "Y")
        {
            char[] decryptedMessage = Decrypt(encryptedMessage, 3, alphabet);
            string decryptedString = new string(decryptedMessage);
            Console.WriteLine($"Youre decrypted message is: {decryptedString}");
        }



        static char[] Encrypt(char[] message, int key, char[] alphabet)
        {
            char[] encryptedMessage = new char[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                int letterPosition = Array.IndexOf(alphabet, message[i]);
                if (letterPosition == -1)
                {
                    encryptedMessage[i] = message[i];
                    continue;
                }
                int newLetterPosition = (letterPosition + key) % alphabet.Length;
                encryptedMessage[i] = alphabet[newLetterPosition];
            }
            return encryptedMessage;
        }
        static char[] Decrypt(char[] encryptedMessage, int key, char[] alphabet)
        {
            char[] decryptedMessage = new char[encryptedMessage.Length];
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                int letterPosition = Array.IndexOf(alphabet, encryptedMessage[i]);
                if (letterPosition == -1)
                {
                    // Skip the character if it's not in the alphabet
                    decryptedMessage[i] = encryptedMessage[i];
                    continue;
                }
                int newLetterPosition = (letterPosition - key + alphabet.Length) % alphabet.Length;
                decryptedMessage[i] = alphabet[newLetterPosition];
            }
            return decryptedMessage;
        }
    }
}


