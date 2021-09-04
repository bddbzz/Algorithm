using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCode
{
    public class MaxIceCream
    {
        //https://leetcode-cn.com/problems/maximum-ice-cream-bars/submissions/
        public static void Run()
        {
            int[] costs = new int[] { 1, 3, 2, 4, 1 };
            int coins = 7;
            //int[] costs = new int[] { 1, 5 };
            //int coins = 7;
            int count = 0;
            count = GetMaxIceCream(costs, coins);
            Console.WriteLine(count);
        }
        static int GetMaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);
            int count = 0;
            for (int i = 0; i < costs.Length; i++)
            {
                int cost = costs[i];
                if (coins - cost >= 0)
                {
                    coins = coins - cost;
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}
