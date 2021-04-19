using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekMath
{
    class Iterative
    {
        //迭代法，不断地用旧的变量值递推新的变量值
        public static void Run()
        {
            //Console.WriteLine(CalcSqrt(10, 0.0000001, 100000));
            string[] dictionary = new string[10] { "e", "f", "g", "h", "i", "j", "a", "b", "c", "d", };
            Array.Sort(dictionary);
            string wordToFind = "a";
            Console.WriteLine(Search(dictionary, wordToFind));
        }
        static double CalcSqrt(int n, double deltaThreshold, int maxTry)
        {
            if (n < 1)
            {
                return -1.0;
            }
            double min = 1.0;
            double max = (double)n;
            for (int i = 0; i < maxTry; i++)
            {
                double middle = (min + max) / 2;
                double square = middle * middle;
                double delta = Math.Abs(square / n - 1);
                if (delta <= deltaThreshold)
                {
                    Console.WriteLine(i);
                    return middle;
                }
                else
                {
                    if (square > n)
                    {
                        max = middle;
                    }
                    else
                    {
                        min = middle;
                    }
                }
            }
            return -2.0;
        }
        //机器学习算法中的迭代。相关的算法或者模型有很多，比如 K- 均值算法（K-means clustering）、PageRank 的马尔科夫链（Markov chain）、梯度下降法（Gradient descent）等等。
        //迭代法之所以在机器学习中有广泛的应用，是因为很多时候机器学习的过程，就是根据已知的数据和一定的假设，求一个局部最优解。
        //而迭代法可以帮助学习算法逐步搜索，直至发现这种解。

        static bool Search(string[] dictionary, string wordToFind)
        {
            if (dictionary == null || dictionary.Length == 0)
            {
                return false;
            }
            int left = 0;
            int right = dictionary.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2; //有溢出的问题
                //int middle = left + (right - left) / 2; //没有溢出的问题
                if (dictionary[middle].Equals(wordToFind))
                {
                    return true;
                }
                else
                {
                    if (dictionary[middle].CompareTo(wordToFind) > 0)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
            }
            return false;
        }
    }
}
