using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo
{
    public static class CryptoUtils
    {
        public static String GenerateSalt(int length = 8)
        {
            byte[] saltBytes = new byte[length];
            RandomNumberGenerator rng = RandomNumberGenerator.Create(); // Singleton

            rng.GetBytes(saltBytes); // Fills the array with random bytes
            StringBuilder salt = new StringBuilder();

            // Convert each byte in the array to an ASCII character between A-Z and numbers
            // Range: 33 - 126
            foreach (byte b in saltBytes)
            {
                salt.Append((char)(b % 94 + 33));
            }

            return salt.ToString();
        }

        public static String HashPassword(String pwd, String salt)
        {
            // Using keyword is when you're using something that implements IDisposable<>
            // Any instances of a class implementing IDisposable should be created with the using keyword
            // Alternatively, you can use do a using block
            // When the instance goes out of scope, the Dispose method is called
            // This stops the garbage collector from completely disposing of the object, allowing it to keep a state before it is disposed
            using SHA384 sha = SHA384.Create();
            byte[] pwdBytes = Encoding.UTF8.GetBytes(pwd + salt + Program.PEPPER);

            // Takes a byte array and creates a new byte stream with the hashed password
            byte[] hashedPwdBytes = sha.ComputeHash(pwdBytes);
            return Convert.ToBase64String(hashedPwdBytes);
        }
    }
}

 


