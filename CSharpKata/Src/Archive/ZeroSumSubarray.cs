using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKata.Src.Archive
{
    internal class ZeroSumSubarray
    {
        private static void Insert(Dictionary<int, List<int>> hashMap, int key, int value)
        {
            // if the key is seen for the first time, initialize the list
            if (!hashMap.ContainsKey(key)) hashMap.Add(key, new List<int>());
            hashMap[key].Add(value);
        }

        internal List<int[]> Call(int[] input)
        {
            var output = new List<int[]>(); 
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            Insert(map, 0, -1);
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
                if(map.ContainsKey(sum))
                {
                    List<int> list = map[sum];
                    foreach(var num in list)
                        output.Add(input.Skip(num + 1).Take(i - num).ToArray());
                }
                Insert(map, sum, i);
            }

            return output;
        }

        //internal List<int[]> BruteForce(int[] input)
        //{
        //    var output = new List<int[]>();
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        var pivot = input[i];
        //        var sum = pivot;

        //        for (int j = i + 1; j < input.Length; j++)
        //        {
        //            var cursor = input[j];
        //            sum += cursor;
        //            if (sum == 0) output.Add(input.Skip(i).Take(j - i + 1).ToArray());
        //        }
        //    }
        //    return output;
        //}
    }
}