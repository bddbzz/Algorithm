using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class Combination
    {
        //组合是不考虑每个元素出现的顺序的
        //定义上来说，组合是指，从 n 个不同元素中取出 m（1≤m≤n）个不同的元素。
        //对于所有 m 取值的组合之全集合，我们可以叫作全组合（All Combination）
        //n 个元素里取出 m 个的组合，可能性数量就是 n 个里取 m 个的排列数量，除以 m 个全排列的数量，也就是 (n! / (n-m)!) / m!。
        //对于全组合而言，可能性为 2^n 种。例如，当 n=3 的时候，全组合包括了 8 种情况。
        public static void Run()
        {
            //证明全组合
            Console.WriteLine(Prove(1) == 2);
            Console.WriteLine(Prove(2) == 4);
            Console.WriteLine(Prove(3) == 8);

            //从三个元素中选择二个元素的组合
            ArrayList teams = new ArrayList(new string[3] { "t1", "t2", "t3" });
            ArrayList result = new ArrayList();
            Combine(teams, result, 2);
        }

        //数学归纳法证明全组合
        static int Prove(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return Prove(n - 1) * 2;
        }

        static void Combine(ArrayList teams, ArrayList result, int m)
        {
            if (result.Count == m)
            {
                Console.WriteLine(String.Join(" ",result.ToArray()));
                return;
            }
            for(int i = 0; i < teams.Count; i++)
            {
                ArrayList new_result = (ArrayList)result.Clone();
                new_result.Add(teams[i]);

                ArrayList rest_teams = new ArrayList(new_result);
                Combine(rest_teams, new_result, m);
            }
        }
    }
}
