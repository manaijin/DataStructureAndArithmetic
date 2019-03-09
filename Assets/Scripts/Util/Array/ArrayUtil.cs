using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Array
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
        public static string ArrayToString(T[] arr,int firstIndex = -1,int lastIndex = -1) {
            StringBuilder str = new StringBuilder();
            if (firstIndex == -1)
                firstIndex = 0;
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
    }
}
