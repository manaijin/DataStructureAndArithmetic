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
    /// 使用顺序表实现栈功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Stack_SequenceList<T>: IStack<T>
    {
        private int Count = 0;
        private T[] Data;

        public Stack_SequenceList(int size)
        {
            Data = new T[size];
            Count = 0;
        }

        public Stack_SequenceList():this(100)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (Count >= Data.Length)
            {
                Debug.LogError("当前栈容量已满");
                return;
            }
            Data[Count] = item;
            Count++;
        }

        /// <inheritdoc />
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T temp = Data[Count - 1];
            Count--;
            return temp;
        }

        /// <summary>
        /// 返回栈顶对象
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return Data[Count - 1];
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int GetLength()
        {
            return Count;
        }

        public string PrintStack(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            return ArrayUtil<T>.ArrayToString(Data,0,Count - 1);
        }
    }



    /// <summary>
    /// 使用链表实现栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Stack_LinkedList<T> : IStack<T>
    {
        private int Count = 0;
        private LinkedListNode<T> FirstNode;

        public Stack_LinkedList()
        {
            FirstNode = null;
            Count = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">首节点值</param>
        public Stack_LinkedList(T value)
        {
            FirstNode = new LinkedListNode<T>(value);
            Count = 1;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);
            if (Count == 0)
            {
                FirstNode = newNode;
            }
            else
            {
                newNode.NextNode = FirstNode;
                FirstNode = newNode;
            }
            Count++;
        }

        /// <inheritdoc />
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                Debug.LogError("当前栈已空，无法出栈");
                return default(T);
            }
            T temp = FirstNode.Data;
            FirstNode = FirstNode.NextNode;
            Count--;
            return temp;
        }

        /// <inheritdoc />
        /// <summary>
        /// 返回栈顶对象
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                Debug.LogError("当前栈已空，无法出栈");
                return default(T);
            }
            return FirstNode.Data;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public int GetLength()
        {
            return Count;
        }

        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="prefixion"></param>
        /// <returns></returns>
        public string PrintStack(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            LinkedListNode<T> tempNode = FirstNode;
            for (int i = 0; i < Count; i++)
            {
                str2.Clear();
                str2.Append("data[");
                str2.Append((Count - i - 1).ToString());
                str2.Append("]:");
                str2.Append(tempNode.Data);
                str2.Append("\n");
                tempNode = tempNode.NextNode;
                str.Insert(0, str2);
            }
            return str.ToString();
        }
    }
}
