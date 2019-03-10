﻿using System.Text;
using DataStructure.LineTable;
using UnityEngine;
using Util.Data;

namespace DataStructure.LineTable
{
    /// <summary>
    /// 顺序表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SequenceList<T>: ILineTable<T>
    {
        private T[] data;
        private int count = 0;

        public SequenceList(int size)
        {
            data = new T[size];
        }

        public SequenceList()
        {
            data = new T[100];
        }

        /// <summary>
        /// 插入元素，无默认index值时，在末尾添加
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(T item, int index = -100000)
        {
            //在末尾添加一个元素
            if (index == -100000)
            {
                Insert(item, count);
                return;
            }

            if (index < 0)
            {
                Debug.Log("下标小于0");
                return;
            }

            if (count == 0 && index == 0)
            {
                data[0] = item;
                count = 1;
                return;
            }

            //下标超出原数组大小
            if (index >= data.Length)
            {
                T[] newData = new T[index - 1];
                for (int i = 0; i < data.Length; i++)
                {
                    newData[i] = data[i];
                }
                data = newData;

                data[index] = item;
                count = data.Length;
                return;
            }

            //下标超出count
            if (index > count - 1)
            {
                data[index] = item;
                count = index + 1;
                return;
            }

            //正常插值
            for (int i = count ; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = item;
            count++;
            return;
        }

        /// <summary>
        /// 删除指定index元素，默认删除最后的元素
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index = -10000)
        {
            //默认删除末尾值
            if (index == -10000)
            {
                DeleteByIndex(count-1);
                return;
            }

            if (!IsIndexInCount(index))
            {
                return;
            }

            for (int i = index + 1; i < count; i++)
            {
                data[i - 1] = data[i];
            }

            count--;
        }

        public void DeleteByItem(T item, bool isAll = true)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(item))
                {
                    DeleteByIndex(i);
                    if (!isAll)
                        return;
                }
            }
        }

        /// <summary>
        /// 判断index是否在[0,count-1]之间
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IsIndexInCount(int index){
            if (0 > index || index > count - 1)
            {
                Debug.Log("下标超出范围");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (IsIndexInCount(index))
                {
                    return data[index];
                }
                return default(T);
            }
        }

        /// <summary>
        /// 列表长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
        }

        /// <summary>
        /// 查找元素下标，未找到返回-1
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isAll">是否返回所有结果</param>
        /// <returns></returns>
        public SequenceList<int> FindOfIndex(T item, bool isAll = true)
        {
            SequenceList<int> list = new SequenceList<int>();
            for (int i = count - 1; i >= 0; i--)
            {
                if (data[i].Equals(item))
                {
                    list.Insert(i);
                    if (!isAll)
                        return list;
                }
            }
            if(list.count == 0)
                list.Insert(-1);
            return list;
        }

        /// <summary>
        /// 列表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0 ? true : false;
        }

        public void Clear()
        {
            count = 0;
            data = new T[data.Length];
        }

        public string PrintList(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            return ArrayUtil<T>.ArrayToString(data, 0, count - 1);
        }
    }
}
