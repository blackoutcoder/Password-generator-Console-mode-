using System;
using System.Text;

namespace Password_generator_Console_mode_
{
    internal class Program
    {
        const string Digits = "0123456789";
        const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        const string Symbols = " ~`@#$%^&*()_+-=[]{};'\\:\"|,./<>?";

        [Flags]
        public enum PasswordChars
        {
            Digits = 0b0001,
            Alphabet = 0b0010,
            Symbols = 0b0100
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">Enter 'password' lenght: ");
            int passwordLength = int.Parse(Console.ReadLine());
            Console.WriteLine("What will 'password' contain: ");
            Console.WriteLine("1.Numbers");
            Console.WriteLine("2.Letters");
            Console.WriteLine("3.Numbers and letters");
            Console.WriteLine("4.Special symbols");
            Console.WriteLine("5.Numbers and spec. symbols");
            Console.WriteLine("6.Letters and spec. symbols"); 
            Console.WriteLine("7.Letters, numbers and spec. symbols");
            Console.Write("What option you want to use?: ");
            int charSet = int.Parse(Console.ReadLine());
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.Clear();
            Console.WriteLine("Your password: [{0}]", GeneratePassword((PasswordChars)charSet, passwordLength));
            Console.ReadLine();
        }

        private static string GeneratePassword(PasswordChars passwordChars, int length)
        {
            var random = new Random();
            var resultPassword = new StringBuilder(length);
            var passwordCharSet = string.Empty;
            if (passwordChars.HasFlag(PasswordChars.Alphabet))
            {
                passwordCharSet += Alphabet + Alphabet.ToUpper();
            }
            if (passwordChars.HasFlag(PasswordChars.Digits))
            {
                passwordCharSet += Digits;
            }
            if (passwordChars.HasFlag(PasswordChars.Symbols))
            {
                passwordCharSet += Symbols;
            }
            for (var i = 0; i < length; i++)
            {
                resultPassword.Append(passwordCharSet[random.Next(0, passwordCharSet.Length)]);
            }
            return resultPassword.ToString();
        }
    }
}
