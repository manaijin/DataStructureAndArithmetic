using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;


namespace DataStructure.LineTable
{
    class SequenceList<T>: ILineTable<T>
    {
        private T[] data;
        private int count = 0;

        public SequenceList(int size)
        {
            data = new T[size];
        }

        public SequenceList():this(10)
        {
        }

        /// <summary>
        /// 插入元素，无默认index值时，在末尾添加
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insect(T item, int index = -100000)
        {
            //在末尾添加一个元素
            if (index == -100000)
            {
                Insect(item, count);
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
        /// 删除指定位置的元素
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

            if (!isIndexInCount(index))
            {
                return;
            }

            for (int i = index + 1; i < count; i++)
            {
                data[i - 1] = data[i];
            }

            count--;
        }

        /// <summary>
        /// 删除指定元素
        /// </summary>
        /// <param name="item"></param>
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
        private bool isIndexInCount(int index){
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
                if (isIndexInCount(index))
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
        /// <returns></returns>
        public SequenceList<int> FindOfIndex(T item, bool isAll = true)
        {
            SequenceList<int> data = new SequenceList<int>();
            for (int i = count - 1; i >= 0; i--)
            {
                if (data[i].Equals(item))
                {
                    data.Insect(i);
                    if (!isAll)
                        return data;
                }
            }
            if(data.count == 0)
                data.Insect(-1);
            return data;
        }

        /// <summary>
        /// 列表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0 ? true : false;
        }

        /// <summary>
        /// 清空列表
        /// </summary>
        public void Clear()
        {
            count = 0;
            data = new T[data.Length];
        }

        /// <summary>
        /// 打印列表
        /// </summary>
        public void PrintList()
        {
            StringBuilder str = new StringBuilder("列表数据:\n");
            for (int i = 0; i < count; i++)
            {
                if (data[i] != null)
                {
                    str.Append(str);
                    str.Append("data[");
                    str.Append(i.ToString());
                    str.Append("]:");
                    str.Append(data[i].ToString());
                    str.Append("\n");
                }
            }
            Debug.Log(str);
        }
    }
}
