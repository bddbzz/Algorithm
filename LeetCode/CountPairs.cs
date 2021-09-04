using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCode
{
    //https://leetcode-cn.com/problems/count-good-meals/
    public class CountPairs
    {
        public static void Run()
        {
            int[] deliciousness = { 1, 3, 5, 7, 9 };
            int result = GetCountPairs(deliciousness);
            Console.WriteLine(result);
        }

        static int GetCountPairs(int[] deliciousness)
        {
            const int MOD = 1000000007;            
            int pairs = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int n = deliciousness.Length;
            int maxVal = 0;
            foreach (int i in deliciousness)
            {
                maxVal = Math.Max(i, maxVal);
            }
            int maxSum = maxVal * 2;
            for (int i = 0; i < n; i++)
            {
                int val = deliciousness[i];
                for(int sum = 1; sum <= maxSum; sum <<= 1)
                {
                    int count = 0;
                    map.TryGetValue(sum - val, out count);
                    pairs = (pairs + count) % MOD;
                }
                if (map.ContainsKey(val))
                {
                    map[val]++;
                }
                else
                {
                    map.Add(val, 1);
                }
            }
            return pairs;
        }

    }

}
