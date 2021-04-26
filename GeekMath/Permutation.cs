using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class Permutation
    {

        //从 n 个不同的元素中取出 m（1≤m≤n）个不同的元素，按照一定的顺序排成一列，这个过程就叫排列（Permutation）。
        //当 m=n 这种特殊情况出现的时候，这就是全排列（All Permutation）。
        //如果选择出的这 m 个元素可以有重复的，这样的排列就是为重复排列（Permutation with Repetition），
        //否则就是不重复排列（Permutation without Repetition）
        //从 n个元素取出 m（0<m≤n）个元素的可重复全排列，总数量为 n^m
        public static void Run()
        {
            //HorseRace();
            CrackPassword(new ArrayList());
            Console.WriteLine("有几种密码组合：" + total);
        }
        static Hashtable t_horses_time = new Hashtable();
        static Hashtable q_horses_time = new Hashtable();
        static void HorseRace()
        {
            //田忌和齐王赛马,田忌要怎么样安排赛马才能赢

            //田忌的马跑完需要的时间          
            t_horses_time.Add("t1", 1.5);
            t_horses_time.Add("t2", 2.5);
            t_horses_time.Add("t3", 3.5);
            //齐王的马跑完需要的时间
            q_horses_time.Add("q1", 1.0);
            q_horses_time.Add("q2", 2.0);
            q_horses_time.Add("q3", 3.0);

            ArrayList t_horses = new ArrayList();
            t_horses.Add("t1");
            t_horses.Add("t2");
            t_horses.Add("t3");

            //田忌的全排列
            ArrayList t_results = new ArrayList();
            Permutate(t_horses, new ArrayList(), t_results);

            ArrayList q_horses = new ArrayList();
            q_horses.Add("q1");
            q_horses.Add("q2");
            q_horses.Add("q3");

            //齐王的全排列
            ArrayList q_results = new ArrayList();
            Permutate(q_horses, new ArrayList(), q_results);

            int t_won_count = 0;
            for (int i = 0; i < t_results.Count; i++)
            {
                for (int j = 0; j < q_results.Count; j++)
                {
                    ArrayList t = (ArrayList)t_results[i];
                    ArrayList q = (ArrayList)q_results[j];
                    Console.WriteLine("田忌派出：" + String.Join(" ", t.ToArray()));
                    Console.WriteLine("齐王派出：" + String.Join(" ", q.ToArray()));
                    bool is_t_won = Compare(t, q);
                    if (is_t_won)
                    {
                        Console.WriteLine("田忌赢了");
                        t_won_count++;
                    }
                }
            }
            Console.WriteLine("田忌赢了" + t_won_count + "次");
            Console.WriteLine("总共比了" + t_results.Count * q_results.Count + "次");
        }

        static void Permutate(ArrayList horses, ArrayList result, ArrayList results)
        {
            if (horses.Count == 0)
            {
                results.Add(result);
                return;
            }
            for (int i = 0; i < horses.Count; i++)
            {
                ArrayList new_result = (ArrayList)result.Clone();
                new_result.Add(horses[i]);

                ArrayList rest_horses = (ArrayList)horses.Clone();
                rest_horses.RemoveAt(i);

                Permutate(rest_horses, new_result, results);
            }
        }

        static bool Compare(ArrayList t, ArrayList q)
        {
            int t_won_count = 0;
            for (int i = 0; i < q.Count; i++)
            {
                if ((double)t_horses_time[t[i]] < (double)q_horses_time[q[i]])
                {
                    t_won_count++;
                }
            }
            if (t_won_count > q.Count / 2)
            {
                return true;
            }
            return false;
        }
        static char[] origin_chars = { 'a', 'b', 'c', 'd', 'e' };
        static int total = 0;
        //假设有一个 4 位字母密码，每位密码是 a～e 之间的小写字母。你能否编写一段代码，来暴力破解该密码？（5^4=625）
        static void CrackPassword(ArrayList result)
        {
            if (result.Count == 4)
            {
                string try_pwd = String.Join("", result.ToArray());
                Console.WriteLine(try_pwd);              
                total++;
                return;
            }
            for (int i = 0; i < origin_chars.Length; i++)
            {
                ArrayList new_result = (ArrayList)result.Clone();
                new_result.Add(origin_chars[i]);
                CrackPassword(new_result);
            }
        }

    }
}
