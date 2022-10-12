using System;
using System.Collections.Generic;
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
        #endregion
    }
}
