using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataStructure.LineTable
{
    /// <summary>
    /// 使用顺序表实现栈功能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Stack_SequenceList<T>: IStack<T>
    {
        private int Count => Data.GetLength();
        private readonly SequenceList<T> Data = new SequenceList<T>();

        public Stack_SequenceList()
        {
            
        }

        public Stack_SequenceList(T item)
        {
            Push(item);
        }

        public Stack_SequenceList(SequenceList<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            Data.Insert(item);
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T temp = Data[Count - 1];
            Data.DeleteByIndex();
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
            Data.Clear();
        }

        public bool IsEmpty()
        {
            return Data.IsEmpty();
        }

        public int GetLength()
        {
            return Count;
        }

        public string PrintStack(string prefixtion = "")
        {
            return Data.PrintList(prefixtion);
        }
    }


    /// <summary>
    /// 使用链表实现栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Stack_LinkedList<T> : IStack<T>
    {
        private int Count => Data.GetLength();
        private readonly LinkedList<T> Data = new LinkedList<T>();

        public Stack_LinkedList()
        {

        }

        public Stack_LinkedList(T item)
        {
            Push(item);
        }

        public Stack_LinkedList(LinkedList<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            Data.Insert(item,0);
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T temp = Data[0];
            Data.DeleteByIndex(0);
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
            Data.Clear();
        }

        public bool IsEmpty()
        {
            return Data.IsEmpty();
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
            StringBuilder str = new StringBuilder();
            for (int i = Data.GetLength() - 1; i >= 0; i--)
            {
                str.Append("data[");
                str.Append(i.ToString());
                str.Append("]:");
                str.Append(Data[i]);
                str.Append("\n");
            }
            return str.ToString();
        }
    }
}
