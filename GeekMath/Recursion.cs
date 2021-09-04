using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class Recursion
    {
        static long totalProduct = 12;
        public static void Run()
        {
            //long totalReward = 10;
            //GetResult(totalReward, new ArrayList());
           
            GetFactor(totalProduct, new ArrayList());

        }
        static long[] rewards = { 1, 2, 5, 10 };
        static void GetResult(long totalReward, ArrayList result)
        {
            if (totalReward == 0)
            {
                Console.WriteLine(String.Join(",", result.ToArray()));
                return;
            }
            if (totalReward < 0)
            {
                return;
            }
            for (int i = 0; i < rewards.Length; i++)
            {
                ArrayList newResult = (ArrayList)result.Clone();
                newResult.Add(rewards[i]);
                GetResult(totalReward - (long)rewards[i], newResult);
            }

        }
        //递归和循环其实都是迭代法的实现，某些情况下它们的实现可以互相转化，某些情况下递归很难被循环取代
        //递归将当期的问题化解位两部分，一个当期所采取的步骤和另一个更简单的问题

        //因式分解
        static void GetFactor(long product, ArrayList result)
        {
            if (product == 1)
            {
                Console.WriteLine(String.Join("*", result.ToArray()));
                return;
            }
            for (long i = 1; i <= product; i++)
            {
                if (product % i == 0)
                {
                    ArrayList newResult = (ArrayList)result.Clone();

                    if (i == 1)
                    {
                        continue;
                       
                    }
                    else if (i == totalProduct)
                    {
                        if (!newResult.Contains(totalProduct))
                        {
                            newResult.Add(totalProduct);
                            newResult.Add(1);
                            GetFactor(1, newResult);
                        }
                    }
                    else
                    {
                        newResult.Add(i);
                        GetFactor(product / i, newResult);
                    }

                }
            }
        }
    }
}
