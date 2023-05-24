using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{

    public static class Cifrado
    {
        private const int keysize = 256;
        //WINDOWS
        static readonly string initVector = File.ReadAllText(@"C:\Data\textFileInitVector.config");
        static readonly string passPhrase = File.ReadAllText(@"C:\Data\textFilePassPhrase.config");
        static readonly string textFileSalt = File.ReadAllText(@"C:\Data\textFileSalt.config");

        //MACOS
        //static readonly string initVector = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFileInitVector.config");
        //static readonly string passPhrase = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFilePassPhrase.config");
        //static readonly string textFileSalt = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFileSalt.config");

        /// <summary>
        /// Función para la encriptación de cadenas de texto
        /// </summary>
        /// <param name="plainText">texto a ser encriptado</param>
        /// <returns></returns>
        private static string EncryptString(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var salt = Encoding.UTF8.GetBytes(textFileSalt);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        /// <summary>
        /// Función para la encriptación de cadenas de texto
        /// </summary>
        /// <param name="plainText">texto a ser encriptado</param>
        /// <returns></returns>
        private static string DecryptString(string cipherText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            //EspacionEnBlancoCIFRADO
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            var salt = Encoding.UTF8.GetBytes(textFileSalt);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        /// <summary>
        /// Encripta una cadena
        /// </summary>
        /// <param name="cadena">Texto a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public static string Encriptar(string cadena)
        {
            return EncryptString(cadena);
        }

        /// <summary>
        /// Desencripta una cadena
        /// </summary>
        /// <param name="cadena">Texto a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public static string Desencriptar(string cadena)
        {
            return DecryptString(cadena);
        }
    }
}
