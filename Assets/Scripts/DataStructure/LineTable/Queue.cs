using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Util.Array;

namespace DataStructure.LineTable
{
    /// <summary>
    /// 通过顺序表实现的Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Queue_SequenceList<T>:IQueue<T>
    {
        private int Count = 0;
        private int front = -1;
        private int rear = -1;
        private T[] Data;

        /// <summary>
        /// 初始化队列容量
        /// </summary>
        /// <param name="size"></param>
        public Queue_SequenceList(int size)
        {
            Data = new T[size];
        }

        /// <summary>
        /// 默认队列容量为100
        /// </summary>
        public Queue_SequenceList():this(100)
        {
        }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return Count;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            Count = 0;
            front = rear = -1;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (Count >= Data.Length)
            {
                Debug.LogError("队列溢出");
                return;
            }

            if (rear == Data.Length - 1)
            {
                Data[0] = item;
                rear = 0;
                Count++;
            }
            else
            {
                Data[rear + 1] = item;
                rear++;
                Count++;
            }
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                Debug.LogError("无元素可出队");
                return default(T);
            }

            T temp = Data[front + 1];
            if (front == Data.Length - 2)
            {
                front = -1;
            }
            else
            {
                front++;
            }
            Count--;
            return temp;
        }

        /// <summary>
        /// 取得队头元素
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return Data[front + 1];
        }

        public string PrintQueue(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                str.Append("data[");
                str.Append(i.ToString());
                str.Append("]:");
                if (front + i + 1> Data.Length - 1)
                {
                    str.Append(Data[front + i - Data.Length + 1]);
                }
                else
                {
                    str.Append(Data[front + i + 1]);
                }
                str.Append("\n");
            }
            return str.ToString();
        }
    }





    /// <summary>
    /// 使用链表实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Queue_LinkedList<T> : IQueue<T>
    {
        private LinkedListNode<T> front;//队首节点
        private LinkedListNode<T> rear;//队尾节点
        private int Count = 0;

        public Queue_LinkedList()
        {
            front = null;
            rear = null;
        }

        public int GetLength()
        {
            return Count;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            Count = 0;
            front = null;
            rear = null;
        }

        public void Enqueue(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);
            if (Count == 0)
            {

                front = newNode;
                rear = newNode;
                Count = 1;
                return;
            }

            rear.NextNode = newNode;
            rear = newNode;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                Debug.LogError("队列为空，无法出队");
                return default(T);
            }

            T temp = front.Data;
            if (Count == 1)
            {
                front = rear = null;
            }
            else
            {
                front = front.NextNode;
                Count--;
            }
            return temp;
        }

        public T Peek()
        {
            return front.Data;
        }

        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="prefixion"></param>
        /// <returns></returns>
        public string PrintQueue(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            LinkedListNode<T> tempNode = front;
            for (int i = 0; i < Count; i++)
            {
                str.Append("data[");
                str.Append(i.ToString());
                str.Append("]:");
                str.Append(tempNode.Data);
                str.Append("\n");
                tempNode = tempNode.NextNode;
            }
            return str.ToString();
        }
    }
}
