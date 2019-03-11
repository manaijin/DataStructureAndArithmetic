using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Util.Data;

namespace Arithmetic
{
    /// <summary>
    /// 排序算法
    /// </summary>
    class SortArithmetic<T>
    {
        /// <summary>
        /// 直接插入排序
        /// </summary>
        /// <param name="data">源数据</param>
        /// <param name="sortType">排序类型，1：降序排序；-1：升序排序</param>
        public static T[] StraightInsertionSort(T[] data, SortType sortType = SortType.DESC)
        {
            if (data.Length == 0)
                return default(T[]);

            List<T> sortData = new List<T>();
            sortData.Add(data[0]);

            dynamic tempData;
            for (int i = 1; i < data.Length; i++)
            {
                tempData = data[i];
                for (int j = 0; j < sortData.Count; j++)
                {
                    if ((tempData - sortData[j]) * (int)sortType >= 0)
                    {
                        sortData.Insert(j,tempData);
                        break;
                    }

                    if (j == sortData.Count - 1)
                    {
                        sortData.Add(tempData);
                        break;
                    }
                }
            }

            return data = sortData.ToArray();
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="data">源数据</param>
        /// <param name="sortType">排序类型，1：降序排序；-1：升序排序</param>
        public static T[] SelectionSort(T[] data, SortType sortType = SortType.DESC)
        {
            if (data.Length == 0)
                return default(T[]);

            dynamic tempData;
            int seondIndex;
            for (int i = 0; i < data.Length; i++)
            {
                tempData = data[i];
                seondIndex = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if ((int) sortType * (tempData - data[j]) < 0)
                    {
                        tempData = data[j];
                        seondIndex = j;
                    }
                }
                ArrayUtil<T>.ExchangeIndex(data, i, seondIndex);
            }

            return data;
        }

        /// <summary>
        /// 快速排序法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sortType"></param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        /// <returns></returns>
        public static T[] QuickSort(T[] data,SortType sortType = SortType.DESC, int firstIndex = 0, int secondIndex = -1)
        {
            if (secondIndex == -1)
                secondIndex = data.Length - 1;

            if (firstIndex >= secondIndex)
                return data;

            int left = firstIndex;
            int right = secondIndex;
            dynamic key = data[firstIndex];

            //从数组两端相向遍历，直到两者下标相等
            while (left < right)
            {
                //从后向前比较：找到大于等于key值的数
                while (left < right)
                {
                    if ((int)sortType * (data[right] - key) >= 0)
                    {
                        data[left] = data[right];
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }

                //从前向后比较：找到小于key值的数
                while (left < right)
                {
                    if ((int)sortType * (data[left] - key) < 0)
                    {
                        data[right] = data[left];
                        break;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            //此时left == right
            data[left] = key;
            data = QuickSort(data, sortType, firstIndex, left - 1);
            data = QuickSort(data, sortType, left + 1, secondIndex);
            return data;
        }

        public enum SortType
        {
            DESC = 1,
            ASC = -1
        }
    }
}
