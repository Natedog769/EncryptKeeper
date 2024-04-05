using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///     The role of this service will be to take in a string and encrypt it, or decrypt it with some sort of algorith I make up
///     There can be different methods for ecrypting maybe
/// </summary>
namespace TheEncryptKeeper4.Services
{
    public class EncryptorService
    {

        private Dictionary<char, char> Cipher = new Dictionary<char, char>();

        private IList<char> keys = new List<char>();
        private IList<char> values = new List<char>();


        public EncryptorService()
        {
            for (char index = 'A'; index < 'Z'; index++)
            {
                keys.Add(index);
            }
            for (char index = 'a'; index < 'a'; index++)
            {
                keys.Add(index);
            }

            //create the values
        }


        //so first we will create a simple encryption method
        public string EncryptString(string toEncrypt)
        {
            string encryption = "";

            foreach (char letter in toEncrypt)
            {
                if (letter == 'Z')
                {
                    encryption += ('A');
                }
                else if (letter == 'z')
                {
                    encryption += 'a';
                }
                else
                {
                    encryption += letter + 1;
                }
            }

            return encryption;
        }

        public string DecryptString(string toDecrypt)
        {
            string decryption = "";

            foreach (char letter in toDecrypt)
            {

            }

            return decryption;
        }

    }
}
