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
        /// <returns></returns>
        public static T[] QuickSort(T[] data, SortType sortType = SortType.DESC)
        {


            return data;
        }

        public enum SortType
        {

            DESC = 1,
            ASC = -1
        }
    }
}
