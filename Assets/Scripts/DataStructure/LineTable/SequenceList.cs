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
                Add(item);
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

        private void Add(T item)
        {
            if (count == data.Length)
            {
                Debug.Log("列表已满");
            }
            else
            {
                data[count] = item;
                count++;
            }
        }

        public void Delete(int index)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index] => throw new System.NotImplementedException();

        public void GetLength()
        {
            throw new System.NotImplementedException();
        }

        public int FindOfIndex(T item)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void PrintList()
        {
            for (int i = 0; i < count; i++)
            {
                if(data[i] != null)
                    Debug.Log("data[" + i.ToString() + "]:" + data[i].ToString());
            }
        }
    }
}
