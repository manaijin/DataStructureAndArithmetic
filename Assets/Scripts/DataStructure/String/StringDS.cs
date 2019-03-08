using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataStructure.String
{
    class StringDS: IString
    {
        /// <summary>
        /// 字符数量
        /// </summary>
        private int Count = 0;
        /// <summary>
        /// 字符数据
        /// </summary>
        private char[] Data;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="size">字符串容量</param>
        public StringDS(int size = 100)
        {
            Data = new char[size];
            Count = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">字符串初始值</param>
        /// <param name="size">字符串容量</param>
        public StringDS(char data,int size = 100)
        {
            Data = new char[size];
            Data[0] = data;
            Count = 1;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">字符串初始值</param>
        /// <param name="size">字符串容量</param>
        public StringDS(char[] data, int size = 100)
        {
            Data = new char[size];
            Data = data;
            Count = data.Length;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get
            {
                if (index > Count - 1 || index< 0)
                {
                    Debug.LogError("超出索引");
                    return default(char);
                }
                return Data[index];
            }

            set
            {

                if (index > Count - 1 || index < 0)
                {
                    Debug.LogError("超出索引");
                }

                Data[index] = value;
            }
        }

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Count;
        }

        /// <summary>
        /// 比较两个字符串:
        /// 从0位置依次比较字符ASCII值
        /// 若此字符串大于输入的字符串，返回1
        /// 若此字符串小于输入的字符串，返回-1
        /// 若相等，则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Compare(StringDS str)
        {
            int len = Math.Min(Count,str.GetLength());
            int result = 0;
            for (int i = 0; i < len; i++)
            {
                if (Data[i] > str[i])
                {
                    result = 1;
                    break;
                }
                if (Data[i] < str[i])
                {
                    result = -1;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="index">起始位置</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public StringDS SubString(int index, int len)
        {
            StringDS data = new StringDS(len);
            for (int i = index; i < index + len; i++)
            {
                data[i - index] = Data[i];
            }

            return data;
        }

        /// <summary>
        /// 插入字符串操作
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public StringDS Insert(int index, StringDS str)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除字符串操作
        /// </summary>
        /// <param name="index">起始节点</param>
        /// <param name="len">删除长度</param>
        /// <returns></returns>
        public StringDS Delete(int index, int len)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public StringDS Concat(StringDS s)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 字符连接
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static StringDS Concat(StringDS s1, StringDS s2)
        {
            char[] newData = new char[s1.GetLength() + s2.GetLength()];
            for (int i = 0; i < s1.GetLength(); i++)
            {
                newData[i] = s1[i];
            }

            for (int i = s1.GetLength(); i < newData.Length; i++)
            {
                newData[i] = s2[i - s1.GetLength()];
            }
            return new StringDS(newData);

        }

        /// <summary>
        /// 返回字符串对应的首个相同字符串下标
        /// 如果没有，则返回-1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int IndexOf(StringDS str)
        {
            int len = str.GetLength();
            if (len > Count)
                return -1;

            for (int i = 0; i < Count - len; i++)
            {
                if (Compare(SubString(i, len)) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
