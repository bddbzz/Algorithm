using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class DynamicProgramming
    {
        //在这种情况下，我们需要在各种可能的局部解中，找出那些可能达到最优的局部解，而放弃其他的局部解。这个寻找最优解的过程其实就是动态规划
        //动态规划需要通过子问题的最优解，推导出最终问题的最优解，因此这种方法特别注重子问题之间的转移关系。
        //我们通常把这些子问题之间的转移称为状态转移，并把用于刻画这些状态转移的表达式称为状态转移方程。

        //搜索下拉提示和关键词纠错，这两个功能其实就是查询推荐
        //查询推荐的核心思想其实就是，对于用户的输入，查找相似的关键词并进行返回。而测量拉丁文的文本相似度，最常用的指标是编辑距离（Edit Distance）。
        //由一个字符串转成另一个字符串所需的最少编辑操作次数，我们就叫作编辑距离
        //编辑操作有这三种：把一个字符替换成另一个字符；插入一个字符；删除一个字符。

        //我们确实可以把求编辑距离这个复杂的问题，划分为更多更小的子问题。
        //而且，更为重要的一点是，我们在每一个子问题中，都只需要保留一个最优解。
        //之后的问题求解，只依赖这个最优值。
        //这种求编辑距离的方法就是动态规划，而这些子问题在动态规划中被称为不同的状态

        //有了这些定义，下面我们用迭代来表达上述的推导过程。
        //如果 i 为 0，且 j 也为 0，那么 d[i, j]为 0。
        //如果 i 为 0，且 j 大于 0，那么 d[i, j]为 j。
        //如果 i 大于 0，且 j 为 0，那么 d[i, j]为 i。
        //如果 i 大于 0，且 j 大于 0，那么 d[i, j]=min(d[i-1, j] + 1, d[i, j-1] + 1, d[i-1, j-1] + r(i, j))。
        //这里面最关键的一步是 d[i, j]=min(d[i-1, j] + 1, d[i, j-1] + 1, d[i-1, j-1] + r(i, j))。
        //这个表达式表示的是动态规划中从上一个状态到下一个状态之间可能存在的一些变化，以及基于这些变化的最终决策结果。我们把这样的表达式称为状态转移方程

        public static void Run()
        {
            //ArrayList coins = new ArrayList();
            //coins.Add(2);
            //coins.Add(5);
            //coins.Add(7);
            //GetCoinCombination(coins, new ArrayList());

            Console.WriteLine(GetJumpWays(4));
            Console.WriteLine(GetUniquePaths(2, 2));
            int[,] arr = { { 1, 23, 4 }, { 3, 6, 9 }, { 15, 16, 20 } };
            Console.WriteLine(GetMinimumPathSum(arr));
        }

        //leecode 322: 你有三种硬币，2元、5元、7元，每种硬币足够多，买一本书需要27元，用最少的硬币组合
        static int[] coins = { 2, 5, 7 };
        static void GetCoinCombination(ArrayList coins, ArrayList result)
        {
            int total = 0;
            foreach (var item in result)
            {
                total += Convert.ToInt32(item);
            }
            if (total > 27)
            {
                return;
            }
            if (total == 27)
            {
                Console.WriteLine(String.Join(" ", result.ToArray()));
            }
            ArrayList new_result = (ArrayList)result.Clone();
            for (int i = 0; i < coins.Count; i++)
            {

                new_result.Add(coins[i]);
                GetCoinCombination(coins, new_result);
            }
        }

        //问题描述：一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法。
        //青蛙跳上n级台阶，有两种可能性，从n-1个台阶跳上来，从n-2个台阶跳上来，因此dp[n]=dp[n-1]+dp[n-2]
        //初始条件dp[0]=0 dp[1]=1 dp[2]=2,即 n <= 2 时，dp[n] = n.
        static int GetJumpWays(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        //一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。
        //机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
        //问总共有多少条不同的路径？

        //dp[m-1] [n-1] 就是我们要找的答案
        //机器人要怎么样才能到达 (i, j) 这个位置？由于机器人可以向下走或者向右走，所以有两种方式到达
        //dp[i][j] = dp[i-1][j] + dp[i][j-1]
        //初始值：dp[0] [0….n-1] = 1; // 相当于最上面一行，机器人只能一直往左走 dp[0…m - 1][0] = 1; // 相当于最左面一列，机器人只能一直往下走
        static int GetUniquePaths(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                return 0;
            }
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        //求最小路径和
        //1、定义数组元素的含义
        //2、找出关系数组元素间的关系式
        //3、找出初始值
        static int GetMinimumPathSum(int[,] arr)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int[,] dp = new int[m, n];
            dp[0, 0] = arr[0, 0];
            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + arr[i, 0];
            }
            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + arr[0, i];
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + arr[i, j];
                }
            }
            return dp[m - 1, n - 1];
        }

        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (m <= 0 || n <= 0)
            {
                return 0;
            }
            int[,] dp = new int[m, n];
            dp[0, 0] = grid[0][0];
            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            }
            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0][i];
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}
