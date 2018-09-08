using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;
using System.Timers;

namespace BloomFilter
{
    class Program
    {
        static BitArray[] bitmap = new BitArray[10000];
        static List<String> dictionary = new List<String>();
        Object hashset1;
        static void Main(string[] args)
        {
            //Load File
            LoadFile();

            //for each word in the file, produce as HashSet which is used to set the bit of array;
            foreach (var word in dictionary)
            {
                var hashset = MD5Hash(word);
                Object hashset1 = hashset;

                //Set the bitmap using hashset and setting the bitarray to the elements at 1 and 3rd index
                bitmap[(int)hashset.GetValue(0)].Set((int)hashset.GetValue(0), true);
                bitmap[hashset.ElementAt(3)].Set(hashset.ElementAt(0), true);
            }


            //check to see if new word is in the array using same hash 

            //check to see if corresponding bits correspond to the hash values set

            //if no bit set, reject word

        }

        //Load the dictionary into an List
        public static void LoadFile()
        {
            string wordlist = System.IO.File.ReadAllText("wordlist.txt");
            string[] words = wordlist.Split('\n');

            foreach (var word in words)
            {
                dictionary.Add(word);
            }
        }

        //Hashing
        public static Byte[] MD5Hash(String input)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(input);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(bytes);

            return hash;
        }

        
    }
}
