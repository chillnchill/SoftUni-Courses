using System;

namespace T04_Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isPassLengthValid = ValidatePasswordLength(password);
            bool doesPasswordContainValidSymbols = ValidatePasswordSymbols(password);
            bool doesPasswordContainTwoDigits = ValidateAmoundOfDigits(password);

            if (!isPassLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!doesPasswordContainValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!doesPasswordContainTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isPassLengthValid && doesPasswordContainValidSymbols && doesPasswordContainTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }                            
        }

        private static bool ValidatePasswordLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
        //i was thinking of doing this the wrong way via try.Parse, but insteaaaad:
        private static bool ValidatePasswordSymbols(string password)
        {
            foreach (char symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }          
            }
            return true;
        }
        private static bool ValidateAmoundOfDigits(string password)
        {
            int digitCount = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCount++;
                }
            }
            if (digitCount < 2)
            {
                return false;
            }
            return true;
        }


    }
}
