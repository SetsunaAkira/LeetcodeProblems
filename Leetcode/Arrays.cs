using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Arrays
    {
        #region FIND THE MAX CONSECUTIVE ONES IN AN ARRAY
        //Counts the Max number of Consecutive 1's in an array
        //Hate it, breaks DRY
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;
            int finalCount = 0;
            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] == 1) count++;
                else
                {
                    if (count > maxCount) maxCount = count;
                    count = 0;
                }
            }
            if (count > maxCount) maxCount = count;

            finalCount = maxCount;

            return finalCount;
        }
        #endregion

        #region FIND EVEN NUMBER OF DIGITS PER NUMBER IN AN ARRAY

        public int FindNumbers(int[] nums)
        {
            int count = 0;
            foreach(int num in nums)
            {
                if(GetDigit(num)%2 == 0) count++;
            }
            return count;
        }

        public int GetDigit(int i)
        {
            if(i  >= 0)
            {
                if (i < 10) return 1;
                if (i < 100) return 2;
                if (i < 1000) return 3;
                if (i < 10000) return 4;
                if (i < 100000) return 5;
                if (i < 1000000) return 6;
                if (i < 10000000) return 7;
                if (i < 100000000) return 8;
                if (i < 1000000000) return 9;
                return 10;
            }
            else
            {
                if (i < -10) return 1;
                if (i < -100) return 2;
                if (i < -1000) return 3;
                if (i < -10000) return 4;
                if (i < -100000) return 5;
                if (i < -1000000) return 6;
                if (i < -10000000) return 7;
                if (i < -100000000) return 8;
                if (i < -1000000000) return 9;
                return 10;
            }
        }
        #endregion

        #region GIVE THE SQUARES OF A SORTED ARRAY

        public int[] SortedSquares(int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
            {
                int number = (int)Math.Pow(Math.Abs(num), 2);
                result.Add(number);
            }
            result.Sort();

            return result.ToArray();
        }

        #endregion

    }

    internal class Maths
    {
        #region FIND THE 2 DIGIT SUM OF TARGET NUMBER
        public int[] TwoSum(int[] nums, int target)
        {
            // the easiest way you can probably find a solution to this, tho it will be O(n^2)
            bool found = false;
            List<int> result = new List<int>();
            for(int i = 0; i < nums.Length; i++)
            {

                for (int j = i + 1; j < nums.Length; j++)
                {
                    Console.WriteLine(nums[i] + " + " + nums[j] + " = " + (nums[i] + nums[j]));
                    if (nums[i] + nums[j] == target)
                    {
                        result.Add(i);
                        result.Add(j);
                        found = true;
                    }
                }
                if (found) break;
            }

            return result.ToArray();
            
        }

        public int[] TwoSumHash(int[] nums, int target)
        {
            //The hashmap Method of my creation, beats double for loop by 72 ms at the cost of 1.3 more MB
            int[] result = new int[2];
            Dictionary<int, int> hashmap = new Dictionary<int, int>();
            bool foreachLooper = true;
            for(int i = 0; i< nums.Length; i++)
            {
                hashmap.Add(i, nums[i]);
            }

            while (foreachLooper == true)
            {
                foreach (KeyValuePair<int, int> entry in hashmap)
                {
                    if (hashmap.ContainsKey(target - nums[entry.Key]) && entry.Key != entry.Value)
                    {
                        result[1] = entry.Key;
                        result[0] = hashmap[target - nums[entry.Key]];
                      
                        if(result[0] >= 0 && result[0] < nums.Length)
                        {
                            if (nums[result[1]] + nums[result[0]] == target && result[0] != result[1])
                            {
                                foreachLooper = false;
                                break;
                            }
                        }
                    }
                    if (hashmap.ContainsKey(nums[entry.Key]))
                    {
                        hashmap[nums[entry.Key]] = entry.Key;
                    }
                    else
                    {
                        hashmap[nums[entry.Key]] = entry.Key;
                        break;
                    }

                }
            }
         
            Console.WriteLine("[ " + result[0] + "," + result[1] + " ]");
            return result;
        }

        public int[] TwoSumOptimal(int[] nums, int target)
        {
            //the answer with the fastest runtime submission
            if (nums.Length != 2)
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();

                dictionary[nums[0]] = 0;
                int x = 0;
                while (true)
                {
                    x++;
                    int num = nums[x];
                    if (dictionary.ContainsKey(target - num)) return new int[] { dictionary[target - num], x };
                    dictionary[num] = x;
                    if (x == nums.Length - 2) return new int[] { dictionary[target - nums[nums.Length - 1]], nums.Length - 1 };
                }
            }

            return new int[] { 0, 1 };
        }

        #endregion

        #region PALINDROME NUMBER

        public bool IsPalindrome(int x)
        {
            char[] convert = x.ToString().ToCharArray();
            Array.Reverse(convert);
            string temp = new string(convert);
            if (convert[convert.Length-1] !=  '-')
            {
                if (temp == x.ToString()) return true;
                else return false;
            }
            else return false;

            
        }


        #endregion
    }

    internal class DumbEnglish
    {
        public string LongestCommonPrefix(string[] strs)
        {
            char[] stringChar = strs[0].ToCharArray();
            List<char> MasterChar = new List<char>();
            List<char> currentChar = new List<char>();

            for(int i = 1; i < 2; i++)
            {
                char[] temp = strs[i].ToCharArray();
                currentChar.AddRange(temp);
                
                if(currentChar.Count < stringChar.Length)
                {
                    for(int j =0; j < currentChar.Count; j++)
                    {
                        if(currentChar[j] == stringChar[j])
                        {
                            MasterChar.Add(currentChar[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < stringChar.Length; j++)
                    {
                        if (currentChar[j] == stringChar[j])
                        {
                            MasterChar.Add(currentChar[j]);
                        }
                    }
                }

            }

           

            return "fuck";
        }


    }
}
