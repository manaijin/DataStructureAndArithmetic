using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arithmetic
{
    /// <summary>
    /// 排序算法
    /// </summary>
    class SortArithmetic
    {
        /// <summary>
        /// 直接插入排序
        /// </summary>
        /// <param name="data">源数据</param>
        /// <param name="sortType">排序类型，1：降序排序；-1：升序排序</param>
        public static float[] StraightInsertionSort(float[] data, SortType sortType = SortType.DESC)
        {
            if (data.Length == 0)
                return default(float[]);

            List<float> sortData = new List<float>();
            sortData.Add(data[0]);

            float tempData;
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



        public enum SortType
        {

            DESC = 1,
            ASC = -1
        }
    }
}
