using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekMath
{
    class Binary
    {
        public static void Run()
        {
            int a = 53;
            int b = 35;

            Console.WriteLine(a | b);
            Console.WriteLine(DecimalToBinary(a | b));
            Console.WriteLine(a & b);
            Console.WriteLine(a ^ b);
            Console.WriteLine(a >> 1);
            Console.WriteLine(a << 1);

            string bstr1 = "00110111";
            //转二进制
            byte b1 = Convert.ToByte(bstr1, 2);
            Console.WriteLine(b1);
            //十进制转二进制
            Console.WriteLine("64 --> 十进制转二进制: " + Convert.ToString(64, 2));
            //十进制转八进制
            Console.WriteLine("64 --> 十进制转八进制: " + Convert.ToString(64, 8));
            //十进制转十六进制
            Console.WriteLine("64 --> 十进制转十六进制: " + Convert.ToString(64, 16));
            //二进制转十进制
            Console.WriteLine("00000100 --> 二进制转十进制: " + Convert.ToInt32("00000100", 2));
            //八进制转十进制
            Console.WriteLine("64 --> 八进制转十进制:" + Convert.ToInt32("64", 8));
            //十六进制转十进制
            Console.WriteLine("FF --> 十六进制转十进制: " + Convert.ToInt32("FF", 16));
        }

        //掩码与位与结合实现十进制转二进制
        static string DecimalToBinary(int num)
        {
            StringBuilder sb = new StringBuilder();
            int bitMask = 1 << 31;
            for (int i = 1; i <= 32; i++)
            {
                if ((num & bitMask) == 0)
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append("1");
                }
                num <<= 1;
                if (i % 8 == 0)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        //余数短除法
        static string DecimalToBinary2(int num)
        {
            StringBuilder sb = new StringBuilder();
            while (num !=0)
            {
                sb.Append(num % 2);
                num >>= 1;
            }
            return ReverseString(sb.ToString());
        }

        //位运算
        static string DecimalToBinary3(int num)
        {
            StringBuilder sb = new StringBuilder();
            while (num != 0)
            {
                sb.Append(num & 1);
                num >>= 1;
            }
            return ReverseString(sb.ToString());
        }

        static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
