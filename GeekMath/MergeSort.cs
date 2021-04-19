using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace GeekMath
{
    class MergeSort
    {
        //归并：两个有序的数列 A 和 B 合并到 C
        //归并排序中引入分而治之（Divide and Conquer）的思想。分而治之，我们通常简称为分治。
        //它的思想就是，将一个复杂的问题，分解成两个甚至多个规模相同或类似的子问题，
        //然后对这些子问题再进一步细分，直到最后的子问题变得很简单，很容易就能被求解出来
        //我们把归并和分治的思想结合起来，这其实就是归并排序算法。
        //归并排序使用了分治的思想，而这个过程需要使用递归来实现
        //2路归并排序算法，时间复杂度是O(NlogN)
        //3路归并排序的时间复杂度为O(NlogN)，其中logN以3为底
        //尽管3路合并排序与2路相比，时间复杂度看起来比较少，但实际上花费的时间会变得更高，因为合并功能中的比较次数会增加。类似的问题还有二分查找比三分查找更受欢迎。
        public static void Run()
        {
            int[] arr = { 7, 6, 2, 4, 1, 9, 3, 8, 0, 5, 11 };
            int[] result = Sort(arr);
            Console.WriteLine(String.Join(" ", result));
        }

        static int[] Sort(int[] arr)
        {
            if (arr.Length < 1)
            {
                return new int[0] { };
            }
            if (arr.Length == 1)
            {
                return arr;
            }
            int middle = arr.Length / 2;
            int[] left = arr.Take(middle).ToArray();
            int[] right = arr.TakeLast(arr.Length - middle).ToArray();
            left = Sort(left);
            right = Sort(right);
            int[] merged = Merge(left, right);
            return merged;
        }

        static int[] Merge(int[] left, int[] right)
        {
            ArrayList result = new ArrayList();
            while (left.Length > 0 && right.Length > 0)
            {
                if (left[0] > right[0])
                {
                    result.Add(right[0]);
                    right = ArraySplice(right, 0);
                }
                else
                {
                    result.Add(left[0]);
                    left = ArraySplice(left, 0);

                }
            }
            if (left.Length > 0)
            {
                foreach (var item in left)
                {
                    result.Add(item);
                }
            }
            if (right.Length > 0)
            {
                foreach (var item in right)
                {
                    result.Add(item);
                }
            }
            return (int[])result.ToArray(typeof(int));
        }

        static int[] ArraySplice(int[] arr, int index)
        {
            List<int> list = arr.ToList();
            list.RemoveAt(index);
            return list.ToArray();
        }

    }
}
