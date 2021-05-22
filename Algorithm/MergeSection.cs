using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Algorithm
{
    class MergeSection
    {
        //合并区间
        public static void Run()
        {
            //int[][] intervals = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            //int[][] intervals = new int[][] { new int[] { 1, 4 }, new int[] { 0, 4 } };
            int[][] intervals = new int[][] { new int[] { 1, 4 }, new int[] { 0, 1 } };
            int[][] result = Merge(intervals);
            foreach (var item in result)
            {
                Console.WriteLine(item[0] + " " + item[1]);
            }

        }
        static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length < 2)
            {
                return intervals;
            }
            ArrayList result = new ArrayList();
            intervals = Sort(intervals);
            int result_min = intervals[0][0];
            int result_max = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
            {
                int min = intervals[i][0];
                int max = intervals[i][1];
                if (result_max >= min)
                {
                    if (result_max < max)
                    {
                        result_max = max;
                    }
                }
                else
                {
                    result.Add(new int[] { result_min, result_max });
                    result_min = min;
                    result_max = max;
                }
                if (i == intervals.Length - 1)
                {
                    result.Add(new int[] { result_min, result_max });
                }
            }
            int[][] result_list = new int[result.Count][];
            int index = 0;
            foreach (var item in result)
            {
                result_list[index] = (int[])result[index];
                index++;
            }
            return result_list;
        }
        static int[][] Sort(int[][] intervals)
        {

            for (int i = 0; i < intervals.Length - 1; i++)
            {
                for (int j = i + 1; j < intervals.Length; j++)
                {
                    if (intervals[j][0] < intervals[i][0])
                    {
                        int[] t = intervals[j];
                        intervals[j] = intervals[i];
                        intervals[i] = t;
                    }
                }
            }

            return intervals;

        }
    }
}
