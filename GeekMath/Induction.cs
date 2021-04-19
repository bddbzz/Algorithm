using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekMath
{
    class Result
    {
        public long wheatNum = 0;
        public long wheatTotalNum = 0;
    }
    class Induction
    {
        //证明基本情况（通常是 n=1 的时候）是否成立；
        //假设 n = k - 1 成立，再证明 n = k 也是成立的（k 为任意大于 1 的自然数）。
        //和使用迭代法的计算相比，数学归纳法最大的特点就在于“归纳”二字。它已经总结出了规律。
        //只要我们能够证明这个规律是正确的，就没有必要进行逐步的推算，可以节省很多时间和资源。
        static void Run()
        {
            Result result = new Result();
            Console.WriteLine(Prove(64, result));
        }
        //证明n格棋盘上的麦粒总数等于2**n-1
        static bool Prove(int k, Result result)
        {
            if (k == 1)
            {
                if (Math.Pow(2, 1) == 1)
                {
                    result.wheatNum = 1;
                    result.wheatTotalNum = 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                bool proveOfPrevious = Prove(k - 1, result);
                result.wheatNum = (long)Math.Pow(2, k - 1);
                result.wheatTotalNum += result.wheatNum;
                bool proveOfCurrent = result.wheatTotalNum == (long)Math.Pow(2, k) - 1;
                if(proveOfPrevious&&proveOfCurrent)
                {
                    return true;
                }
                return false;
            }
        }
        //递归把时间交给计算机，归纳把时间交给人

    }
}
