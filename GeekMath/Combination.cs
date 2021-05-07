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
            ArrayList results = new ArrayList();
            Combine(teams, result, 2, results);

            //假设现在需要设计一个抽奖系统。需要依次从 10 个人中，抽取三等奖 3 名，二等奖 2 名和一等奖 1 名。请列出所有可能的组合，需要注意的每人最多只能被抽中 1 次。
            ArrayList members = new ArrayList(10);
            for (int i = 0; i < 10; i++)
            {
                members.Add("p" + i);
            }
            ArrayList round1_results = new ArrayList();
            Combine(members, new ArrayList(), 1, round1_results);//10个人当中取1个数的组合
            for (int i = 0; i < round1_results.Count; i++)
            {
                ArrayList round1_won = (ArrayList)round1_results[i];
                Console.WriteLine("一等奖：" + String.Join(" ", round1_won.ToArray()));
                ArrayList round2_results = new ArrayList();
                ArrayList rount1_rest = GetRestMembers(members, round1_won);//9个人当中取2个数的组合
                Combine(rount1_rest, new ArrayList(), 2, round2_results);
                for (int j = 0; j < round2_results.Count; j++)
                {
                    ArrayList round2_won = (ArrayList)round2_results[j];
                    Console.WriteLine("二等奖：" + String.Join(" ", round2_won.ToArray()));
                    ArrayList round3_results = new ArrayList();
                    ArrayList rount2_rest = GetRestMembers(members, round2_won);
                    Combine(rount2_rest, new ArrayList(), 3, round3_results);//7个人当中取3个数
                    string round3_win = "";
                    foreach (var list in round3_results)
                    {
                        round3_win += String.Join(" ", ((ArrayList)list).ToArray()) + "\n";
                    }
                    Console.WriteLine("三等奖可能是：\n" + round3_win);
                }
            }
        }

        static ArrayList GetRestMembers(ArrayList members, ArrayList won_members)
        {
            ArrayList rest = new ArrayList();
            for (int i = 0, n = members.Count; i < n; i++)
            {
                if (!won_members.Contains(members[i]))
                {
                    rest.Add(members[i]);
                }
            }
            return rest;
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

        static void Combine(ArrayList teams, ArrayList result, int m, ArrayList results)
        {
            if (result.Count == m)
            {
                //Console.WriteLine(String.Join(" ", result.ToArray()));
                results.Add(result);
                return;
            }
            for (int i = 0; i < teams.Count; i++)
            {
                ArrayList new_result = (ArrayList)result.Clone();
                new_result.Add(teams[i]);

                ArrayList rest_teams = teams.GetRange(i + 1, teams.Count - i - 1);
                Combine(rest_teams, new_result, m, results);
            }
        }
    }
}
