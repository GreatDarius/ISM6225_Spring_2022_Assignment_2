/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }
    

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                // defining a new array to put target inside it
                int[] NewNum = new int[] {target};
                //defining a list to put the result of combining arrays inside it incase we couln't find the target.
                var mylist = new List<int>();
                //using binary search to look for target
                int Result = Array.BinarySearch(nums, target);
                //if we found the target we return the index of our target
                if (Result>0)
                {
                    return Result;
                
                }
                //else we combine the target with our nums array
                else
                {
                    mylist.AddRange(nums);
                    mylist.AddRange(NewNum);
                    //put them inside a list and convert them to array again
                    int[] CombinedArray = mylist.ToArray();
                    //sort the new array
                    Array.Sort(CombinedArray);
                    //again search for the target and return the index.
                    Result = Array.BinarySearch(CombinedArray, target);
                    return Result;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //using built in functions like BinarySearch is really helpfull and time saving. 

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                StringBuilder ban = new StringBuilder();
                ban.Append(banned[0]);
                string res = ban.ToString();
                // Create Dictionary to store word
                // and it's frequency
                Dictionary<String, int> hs = new Dictionary<String, int>();
                paragraph = paragraph.ToLower();
                paragraph = paragraph.Replace(",", ""); //Just cleaning up a bit
                paragraph = paragraph.Replace(".", ""); //Just cleaning up a bit
                string[] arr = paragraph.Split(' '); //Create an array of words

                // Iterate through array of words
                for (int i = 0; i < arr.Length; i++)
                {
                    // If word already exist in Dictionary
                    // then increase it's count by 1
                    if (hs.ContainsKey(arr[i]))
                    {
                        hs[arr[i]] = hs[arr[i]] + 1;
                    }

                    // Otherwise add word to Dictionary
                    else
                    {
                        hs.Add(arr[i], 1);
                    }
                }

                // Create set to iterate over Dictionary
                String key = "";
                int value = 0;
                hs.Remove(res);
                foreach (KeyValuePair<String, int> me in hs)
                {
                    // Check for word having highest frequency
                    if (me.Value > value)
                    {
                        value = me.Value;
                        key = me.Key;
                    }
                }

                // Return word having highest frequency
                return key;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {

                // Create Dictionary to store items
                // and it's frequency
                Dictionary<int, int> hs = new Dictionary<int, int>();

                // Iterate through array of words
                for (int i = 0; i < arr.Length; i++)
                {
                    // If word already exist in Dictionary
                    // then increase it's count by 1
                    if (hs.ContainsKey(arr[i]))
                    {
                        hs[arr[i]] = hs[arr[i]] + 1;
                    }

                    // Otherwise add word to Dictionary
                    else
                    {
                        hs.Add(arr[i], 1);
                    }
                }

                // Create set to iterate over Dictionary
                int key = 0;
                int value = 0;
                foreach (KeyValuePair<int, int> me in hs)
                {
                    // Check for word having highest frequency
                    if (me.Value > value && me.Key==me.Value)
                    {
                        value = me.Value;
                        key = me.Key;
                    }
                    else
                    {
                        key = -1;
                    }
                }

                // Return word having highest frequency
                return key;
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int BullCounter = 0;
                int CowCounter = 0;
                int Guess = Convert.ToInt32(guess);
                int Secret = Convert.ToInt32(secret);
                int[] GuessArray = new int[4];
                int[] SecretArray = new int[40];
                int[] distinctGuess = GuessArray.Distinct().ToArray();
                int[] distinctSecret = SecretArray.Distinct().ToArray();

                for (int i=0;i<GuessArray.Length;i++)
                {
                    GuessArray[i] = Guess % 10;
                    Guess /= 10;
                }
                for (int j = 0; j < SecretArray.Length; j++)
                {
                    SecretArray[j] = Secret % 10;
                    Secret /= 10;
                }
                for (int k=0; k<4;k++)
                {
                    if(GuessArray[k]==SecretArray[k])
                    {
                        BullCounter += 1;
                    }
                }
                for (int l = 0; l < 4; l++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if(GuessArray[m]==SecretArray[l])
                        {
                            CowCounter += 1;
                            break;
                        }
                    }

                }

                return (BullCounter+"A"+(CowCounter-BullCounter)+"B");
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                //Setting up the index based on position of alphabet
                int[] LastIndex = new int[26];
                for (int i =0; i<s.Length;i++)
                {
                    LastIndex[s[i] - 'a'] = i;
                }
                int j = 0;
                int Start = 0;
                List<int> Result = new List<int>();
                //
                for(int i= 0; i<s.Length; i++)
                {   
                    //Updating j
                    j = Math.Max(j, LastIndex[s[i] - 'a']);
                    //If i equals j it means that we are done with our partition i
                    if (i == j)
                    {
                        Result.Add(i - Start + 1);
                        Start = i + 1;
                    }
                }
                return Result ;
            }
            catch (Exception)
            {
                throw;
            }
            //Intresting problem with strings. At first it looked really hard to me but by taking some time to think about it it was really fun solving it
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths,string s)
        {
            try
            {
                //write your code here.
                //Putting string input in an array as Character.
                char[] Input = new char[s.Length];
                Input = s.ToCharArray();
                //Creating an array of all 26 Alphabets.
                char[] Alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                //Defining variables for getting the line numbers and the leftover pixels
                int SumOfWidth = 0;
                int LineCounter = 1;
                //Using 2 loops we can check our inputs against the Alphabets
                for (int j = 0; j < Input.Length; j++)
                {
                    for (int i = 0; i < Alphabets.Length; i++)
                    {
                        //If the input caracter is equal to one of the alphabets
                        if (Input[j] == Alphabets[i])
                        {
                            //We will sum up the width with other alohabet width
                            SumOfWidth += widths[i];
                            //Check to see if Our width is greater than 100 (one line) or not
                            if (SumOfWidth>100)
                            {
                                //If so we will add one to our linecounter and zero our Sum
                                LineCounter += 1;
                                SumOfWidth = 0;
                                SumOfWidth += widths[i];
                            }
                        }                       
                    }
                }
                //Returning the number of the lines with left over width
                return new List<int>() {LineCounter,SumOfWidth };
            }
            catch (Exception)
            {
                throw;
            }
            //It took me 30 minutes to write this code and It helped me learn more about if statement inside for in different way.
        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                //Creating a stack to insert our inputs in it.
                Stack<char> FirstSymbols = new Stack<char>();
                // Loop for each character of the string
                for (int i = 0; i < bulls_string10.Length; i++)
                {
                    // If left symbol is encountered
                    if (bulls_string10[i] == '(' || bulls_string10[i] == '{' || bulls_string10[i] == '[')
                    {
                        //We will insert it inside our stack
                        FirstSymbols.Push(bulls_string10[i]);
                    }
                    // If right symbol is encountered ")"
                    else if (bulls_string10[i] == ')' && FirstSymbols.Count != 0 && FirstSymbols.Contains( '(' ))
                    {
                        //If it was equal to the top element of stack we will pop it
                        FirstSymbols.Pop();
                    }
                    // If right symbol is encountered "}"
                    else if (bulls_string10[i] == '}' && FirstSymbols.Count != 0 && FirstSymbols.Contains('{'))
                    {
                        //If it was equal to the top element of stack we will pop it
                        FirstSymbols.Pop();
                    }
                    // If right symbol is encountered "]"
                    else if (bulls_string10[i] == ']' && FirstSymbols.Count != 0 && FirstSymbols.Contains('['))
                    {
                        //If it was equal to the top element of stack we will pop it
                        FirstSymbols.Pop();
                    }
                    // If none of the valid symbols is encountered
                    else
                    {
                        return false;
                    }
                }
                return true;
                //return false;
            }
            catch (Exception)
            {
                throw;
            }
            // This took me almost 2 hours to figure out (Remebered how to validate symbols using stack) This was a great practice with stacks and a good reminder
        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                //Defining morse code array
                string[] MorseCodes = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                //Defining alphabet array
                //string[] Alphabets = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                char[] Alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                string allthemors = "";
                int Counter = 0;
                //Checking
                string result = string.Join(" ", words);
                char[]Input = result.ToCharArray();
                string[] MorseArray = new string[words.Length];
                for(int i=0; i<words.Length;i++)
                {
                    foreach(char ch in words[i])
                    {
                        for (int j=0; j<26; j++)
                        {
                            if (ch == Alphabets[j])
                            {
                                allthemors += MorseCodes[j];
                            }
                        }
                    }
                    MorseArray[i] = allthemors;
                    allthemors = string.Empty;
                }
                if (words.Length==1)
                {
                    Counter = 1;
                }
                else
                {
                    for (int i = 0; i < MorseArray.Length - 1; i++)
                    {
                        for (int j = i + 1; j < MorseArray.Length; j++)
                        {
                            if (MorseArray[i] == MorseArray[j])
                            {
                                Counter += 1;
                            }
                        }
                    }
                }
               
                return Counter;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                //Getting lenght of arrays
                int len1 = word1.Length;
                int len2 = word2.Length;

                // Create a DP array to memoize result of previous computations
                int[,] DP = new int[2, len1 + 1];


                // Base condition when second String is empty then we remove all characters
                for (int i = 0; i <= len1; i++)
                    DP[0, i] = i;

                // Start filling the DP This loop run for every character in second String
                for (int i = 1; i <= len2; i++)
                {

                    // This loop compares the char fromsecond String with first String characters
                    for (int j = 0; j <= len1; j++)
                    {

                        // if first String is empty then we have to perform add character operation to get second String
                        if (j == 0)
                            DP[i % 2, j] = i;

                
                        else if (word1[j - 1] == word2[i - 1])
                        {
                            DP[i % 2, j] = DP[(i - 1) % 2, j - 1];
                        }

                        // if character from both String is not same then we take the minimum from three specified operation
                        else
                        {
                            DP[i % 2, j] = 1 + Math.Min(DP[(i - 1) % 2, j],
                                                   Math.Min(DP[i % 2, j - 1],
                                                       DP[(i - 1) % 2, j - 1]));
                        }
                    }
                }
                int res =DP[len2 % 2, len1];
                return res;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //This was a intresting question. forcing me out of my confert zone with C# took me hours to work it out
    }
}
