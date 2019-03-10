using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util.Data
{
    class ListUtil<T>
    {
        /// <summary>
        /// 输出列表的字符串，默认firstIndex为0，lastIndex为数组最短index
        /// </summary>
        /// <param name="list">源数据</param>
        /// <param name="firstIndex">起始下标</param>
        /// <param name="lastIndex">结束下标</param>
        /// <returns></returns>
        public static string ListToString(List<T> list, int firstIndex = 0, int lastIndex = -1)
        {
            StringBuilder str = new StringBuilder();
            if (lastIndex == -1)
                lastIndex = list.Count - 1;
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                if (list[i] != null)
                {
                    str.Append("data[");
                    str.Append(i.ToString());
                    str.Append("]:");
                    str.Append(list[i].ToString());
                    str.Append("\n");
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 交换列表下标元素
        /// </summary>
        /// <param name="list">源数据</param>
        /// <param name="firstIndex">第一个下标位置</param>
        /// <param name="secondIndex">第二个下标位置</param>
        /// <returns></returns>
        public static List<T> ExchangeIndex(List<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= list.Count)
            {
                Debug.LogError("firstIndex查出范围");
                return list;
            }

            if (secondIndex < 0 || secondIndex >= list.Count)
            {
                Debug.LogError("secondIndex查出范围");
                return list;
            }

            var tempData = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tempData;
            return list;
        }
    }
}
