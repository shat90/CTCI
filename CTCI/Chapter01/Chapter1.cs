using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.Chapter01
{
    public class Chapter1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CheckPermutation("test", "stet"));
            Console.WriteLine(URLIfy("test me   ", 7));
            Console.WriteLine(PalindromePermutation("Tact Coa", "taco at"));
        }

        /*
         * Is Unique:
         * Implement an algorithm to determine if a string has all unique characters.
         * What if you cannot use additional data structures?
         */
        public static bool IsUnique(string s)
        {
            bool[] arr = new bool[26];

            foreach (char x in s)
            {
                if (arr[x - 97])
                    return false;
                else
                    arr[x - 97] = true;
            }
            return true;
        }
        /*
         * Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
         */
        public static bool CheckPermutation(string s1, string s2)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char x in s1)
            {
                if (!dict.ContainsKey(x))
                {
                    dict.Add(x, 1);
                }
                else
                {
                    dict[x] += 1;
                }

            }

            foreach (char y in s2)
            {
                if (dict.ContainsKey(y))
                {
                    dict[y]--;
                    if (dict[y] == 0)
                    {
                        dict.Remove(y);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /*
         * URLify: Write a method to replace all spaces in a string with '%2e: 
         * You may assume that the string has sufficient space at the end to hold the additional characters, 
         * and that you are given the "true"length of the string.
         * (Note: if implementing in Java, please use a character array so that you canperform this operation in place.)
         * EXAMPLEInput: "Mr John Smith JJ, 13Output: "Mr%2eJohn%2eSmith"
         */

        public static string URLIfy(string str, int length)
        {

            int spaceCounter = 0;
            foreach (char x in str)
            {
                if (x == ' ')
                    spaceCounter++;
            }
            char[] result = new char[length + spaceCounter * 2];
            int i = 0;
            int j = 0;
            while (i < length)
            {
                if (str[i] != ' ')
                {
                    result[j++] = str[i++];
                }
                else
                {
                    result[j++] = '%';
                    result[j++] = '2';
                    result[j++] = '0';
                    i++;

                }
            }

            return new string(result);

        }
        /*
         * Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
         * A palindrome is a word or phrase that is the same forwards and backwards. 
         * A permutation is a rearrangement of letters. The palindrome does not need to be limited to justdictionary words.
         * EXAMPLEInput: Tact CoaOutput: True (permutations:"taco cat'; "atco cta'; etc.)
         */
        public static bool PalindromePermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            s1 = s1.ToLower();
            s2 = s2.ToLower();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char x in s1)
            {
                if (x == ' ')
                    continue;
                else
                {
                    if (!dict.ContainsKey(x))
                    {
                        dict.Add(x, 1);
                    }
                    else
                    {
                        dict[x] = (dict[x] + 1) % 2;
                    }
                }

            }
            int xCount = 0;
            foreach (var item in dict)
            {
                if (item.Value == 1)
                    xCount++;
                if (xCount > 1)
                    return false;

            }
            return true;
        }
    }
}
