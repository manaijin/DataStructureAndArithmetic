using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util.Data
{
    internal static class ArrayUtil<T>
    {
        /// <summary>
        /// 输出数组的字符串，默认firstIndex为0，lastIndex为数组最短index
        /// </summary>
        /// <param name="arr">源数据</param>
        /// <param name="firstIndex">起始下标</param>
        /// <param name="lastIndex">结束下标</param>
        /// <returns></returns>
        public static string ArrayToString(T[] arr,int firstIndex = 0,int lastIndex = -1) {
            StringBuilder str = new StringBuilder();
            if (lastIndex == -1)
                lastIndex = arr.Length - 1;
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                if (arr[i] != null)
                {
                    str.Append("data[");
                    str.Append(i.ToString());
                    str.Append("]:");
                    str.Append(arr[i].ToString());
                    str.Append("\n");
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 交换数组下标元素
        /// </summary>
        /// <param name="arr">源数据</param>
        /// <param name="firstIndex">第一个下标位置</param>
        /// <param name="secondIndex">第二个下标位置</param>
        /// <returns></returns>
        public static T[] ExchangeIndex(T[] arr, int firstIndex, int secondIndex)
        {
            if (firstIndex == secondIndex)
                return arr;

            if (firstIndex < 0 || firstIndex >= arr.Length)
            {
                Debug.LogError("firstIndex查出范围");
                return arr;
            }

            if (secondIndex < 0 || secondIndex >= arr.Length)
            {
                Debug.LogError("secondIndex查出范围");
                return arr;
            }

            var tempData = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = tempData;
            return arr;
        }
    }
}
