using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class Remainder
    {
        //同余定律，简单来说，就是两个整数 a 和 b，如果它们除以正整数 m 得到的余数相等，我们就可以说 a 和 b 对于模 m 同余，余数肯定在一个范围内
        //加入随机数可用于对数据重新洗牌的场景
        //常规的取余就是均分
        public static void Run()
        {
            //DivideArray();
            int num = 569;
            Console.WriteLine(num.ToString() + "=>" + EncryptNumber(num));
            string idCard = "360826201312134324";
            Console.WriteLine(CheckIDCard(idCard));
        }

        //将数据随机分配三组
        static void DivideArray()
        {
            int[] randomArray = new int[9] { 123, 2323, 333, 33, 22, 11, 55, 66, 44 };
            ArrayList[] resultArray = new ArrayList[3];
            int MAX = 59099; //增加随机数
            for (int i = 0; i < randomArray.Length; i++)
            {
                int index = (i + MAX) % 3;
                if (resultArray[index] == null)
                {
                    resultArray[index] = new ArrayList();
                }
                resultArray[index].Add(randomArray[i]);
            }
            foreach (ArrayList list in resultArray)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// 加密数字,加密规则：
        /// 1、先对每个三位数的个、十和百位数，都加上一个较大的随机数。
        /// 2、然后将每位上的数都除以 7，用所得的余数代替原有的个、十、百位数；
        /// 3、最后将第一位和第三位交换。
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static string EncryptNumber(int num)
        {
            char[] charArray = num.ToString().ToCharArray();
            int[] resultArray = new int[charArray.Length];
            const int RANDOM = 990562;//随机数
            const int m = 11;//大于10的数可以不保留商，否则解密的时候需要回传商
            for(var i = 0; i < charArray.Length; i++)
            {
                //加上随机数取余
                resultArray[i] = (Convert.ToInt32(charArray[i].ToString()) + RANDOM) % m;
            }
            //交换第一位、第三位
            int temp = resultArray[0];
            resultArray[0] = resultArray[2];
            resultArray[2] = temp;
            //拼装返回值
            string result = "";
            foreach(var item in resultArray)
            {
                result += item.ToString();
            }
            return result;
        }

        //逆向运算DecryptNumber，需要商，随机数，模

        //余数应用：身份证校验、银行卡校验、润年计算、随机播放

        //身份证校验
        //公民身份号码是特征组合码，由十七位数字本体码和一位数字校验码组成。排列顺序从左至右依次为：六位数字地址码，八位数字出生日期码，三位数字顺序码，最后一位是数字校验码。
        //ISO 7064:1983.MOD 11-2校验码
        static bool CheckIDCard(string val)
        {
            if (val.Length < 18)
            {
                throw new Exception("请传入18位身份证号码");
            }
            int[] coefficient = new int[17] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            char[] checkChars = new char[11] { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
            char[] arr = val.ToCharArray();
            int sum = 0;
            for(var i=0;i<17;i++)
            {
                var item = arr[i];                
                sum += Convert.ToInt32(item.ToString()) * coefficient[i];
            }
            int remainder = sum % 11;
            char result= checkChars[remainder];
            Console.WriteLine(remainder);
            Console.WriteLine(arr[17]);
            return result.ToString() == arr[17].ToString();
        }

        //银行卡校验规则(Luhn算法)

       
    }
}
