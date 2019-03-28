using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataStructure.LineTable
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T> : ILineTable<T>
    {
        /// <summary>
        /// 首节点
        /// </summary>
        private LinkedListNode<T> FirstNode;

        /// <summary>
        /// 元素个数
        /// </summary>
        private int Count;

        public LinkedList()
        {
            FirstNode = null;
            Count = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">首节点值</param>
        public LinkedList(T value)
        {
            FirstNode = new LinkedListNode<T>(value);
            Count = 1;
        }

        public T this[int index] {
            get
            {
                if (!IsIndexInCount(index))
                {
                    return default(T);
                }
                return GetNode(index).Data;
            }
        }

        private LinkedListNode<T> GetNode(int index)
        {
            if (!IsIndexInCount(index))
                return default(LinkedListNode<T>);

            LinkedListNode<T> data = FirstNode;
            for (int i = 0; i <= index - 1; i++)
            {
                data = data.NextNode;
            }
            return data;
        }

        /// <summary>
        /// 判断index是否在[0,count-1]之间
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IsIndexInCount(int index)
        {
            if (0 > index || index > Count - 1)
            {
                Debug.Log("下标超出范围");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            FirstNode = null;
            Count = 0;
        }

        /// <summary>
        /// 删除单个下标,默认删除最后一个对象
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index = -1)
        {
            if (index == -1 && Count > 0)
                DeleteByIndex(Count - 1);

            if (!IsIndexInCount(index))
                return;

            if (index == 0)
            {
                FirstNode = FirstNode.NextNode;
                Count--;
                return;
            }

            ThressNode<T> nodes = GetNodesByIndex(index);
            if (nodes.PreNode != null)
            {
                nodes.PreNode.NextNode = nodes.NextNode;
            }
            else
            {
                Debug.Log("nodes.PreNode为空");
                return;
            }
            Count--;
            return;
        }

        /// <summary>
        /// 删除对应元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isAll"></param>
        public void DeleteByItem(T item, bool isAll = true)
        {
            LinkedListNode<T> tempNode = FirstNode;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (tempNode.Data.Equals(item))
                {
                    DeleteByIndex(i);
                    if(!isAll)
                        return;
                }
                tempNode = tempNode.NextNode;
            }
        }

        /// <summary>
        /// 查找元素对应下标，若没有则返回-1
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public SequenceList<int> FindOfIndex(T item, bool isAll = true)
        {
            SequenceList<int> list = new SequenceList<int>();
            LinkedListNode<T> tempNode = FirstNode;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (tempNode.Data.Equals(item))
                {
                    list.Insert(i);
                    if (!isAll)
                        return list;
                }
                tempNode = tempNode.NextNode;
            }

            return list;
        }

        public int GetLength()
        {
            return Count;
        }

        /// <summary>
        /// 插入操作，默认在末尾插入
        /// </summary>
        /// <param name="item">插入的对象</param>
        /// <param name="index">下标</param>
        public void Insert(T item, int index = -1)
        {
            LinkedListNode<T> lastNode = null; ;
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);
            if (index == -1)
            {
                if (Count == 0)
                {
                    FirstNode = newNode;
                }
                else
                {
                    lastNode = GetNode(Count - 1);
                    lastNode.NextNode = newNode;
                }
                Count++;
                return;
            }

            if (!IsIndexInCount(index))
                return;

            if (index == 0)
            {
                newNode.NextNode = FirstNode;
                FirstNode = newNode;
                Count++;
                return;
            }

            ThressNode<T> nodes = GetNodesByIndex(index);
            LinkedListNode<T> insertNode = new LinkedListNode<T>(item, nodes.CurrentNode);
            nodes.PreNode.NextNode = insertNode;
            Count++;

            return;
        }

        public bool IsEmpty()
        {
            return Count == 0 ? true : false;
        }

        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="prefixion"></param>
        /// <returns></returns>
        public string PrintList(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            LinkedListNode<T> tempNode = FirstNode;
            for (int i = 0; i < Count; i++)
            {
                str.Append(System.String.Format(StringManager.DATA_INDEX, i));
                str.Append(tempNode.Data);
                str.Append("\n");
                tempNode = tempNode.NextNode;
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取下表对应关联的三个节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ThressNode<T> GetNodesByIndex(int index)
        {
            ThressNode<T> data = new ThressNode<T>();

            if (index == 0)
            {
                data.PreNode = null;
                data.CurrentNode = FirstNode;
                data.NextNode = FirstNode.NextNode;
                return data;
            }
            else
            {
                data.PreNode = FirstNode;
                data.CurrentNode = null;
                data.NextNode = null;
            }

            for (int i = 0; i <= index - 1; i++)
            {
                data.PreNode = data.PreNode.NextNode;
            }

            if (data.PreNode != null)
            {
                data.CurrentNode = data.PreNode.NextNode;
            }

            if (data.CurrentNode != null)
            {
                data.NextNode = data.CurrentNode.NextNode;
            }
            return data;
        }
    }

    /// <summary>
    /// 单链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedListNode<T>
    {
        public T Data;
        public LinkedListNode<T> NextNode;

        public LinkedListNode()
        {
            Data = default(T);
            NextNode = null;
        }

        public LinkedListNode(T value)
        {
            Data = value;
            NextNode = null;
        }

        public LinkedListNode(T value, LinkedListNode<T> next)
        {
            Data = value;
            NextNode = next;
        }
    }

    /// <summary>
    /// 双链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DoubleLinkedList<T> : ILineTable<T>
    {
        /// <summary>
        /// 首节点
        /// </summary>
        private DoubleLinkedListNode<T> FirstNode;

        /// <summary>
        /// 元素个数
        /// </summary>
        private int Count;

        public DoubleLinkedList()
        {
            FirstNode = null;
            Count = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">首节点值</param>
        public DoubleLinkedList(T value)
        {
            FirstNode = new DoubleLinkedListNode<T>(value);
            Count = 1;
        }

        public T this[int index]
        {
            get
            {
                if (!IsIndexInCount(index))
                {
                    return default(T);
                }
                return GetNode(index).Data;
            }
        }

        private DoubleLinkedListNode<T> GetNode(int index)
        {
            if (!IsIndexInCount(index))
                return default(DoubleLinkedListNode<T>);

            DoubleLinkedListNode<T> data = FirstNode;
            if (index < (float)Count / 2)
            {
                for (int i = 0; i <= index - 1; i++)
                {
                    data = data.NextNode;
                }
            }
            else
            {
                for (int i = 0; i <= Count - index - 1; i++)
                {
                    data = data.PreNode;
                }
            }
            return data;
        }

        /// <summary>
        /// 判断index是否在[0,count-1]之间
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IsIndexInCount(int index)
        {
            if (0 > index || index > Count - 1)
            {
                Debug.Log("下标超出范围");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            FirstNode = null;
            Count = 0;
        }

        /// <summary>
        /// 删除单个下标
        /// </summary>
        /// <param name="index"></param>
        public void DeleteByIndex(int index)
        {
            if (!IsIndexInCount(index))
                return;

            if (index == 0)
            {
                FirstNode = FirstNode.NextNode;
                Count--;
                return;
            }

            ThressDoubleNode<T> nodes = GetNodesByIndex(index);

            if (nodes.PreNode != null)
            {
                nodes.PreNode.NextNode = nodes.NextNode;
            }
            else
            {
                Debug.Log("nodes.PreNode为空");
                return;
            }

            if (nodes.NextNode != null)
            {
                nodes.NextNode.PreNode = nodes.PreNode;
            }
            else
            {
                Debug.Log("nodes.PreNode为空");
                return;
            }

            Count--;
            return;
        }

        /// <summary>
        /// 删除对应元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isAll"></param>
        public void DeleteByItem(T item, bool isAll = true)
        {
            DoubleLinkedListNode<T> tempNode = FirstNode;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (tempNode.Data.Equals(item))
                {
                    DeleteByIndex(i);
                    if (!isAll)
                        return;
                }
                tempNode = tempNode.NextNode;
            }
        }

        /// <summary>
        /// 查找元素对应下标，若没有则返回-1
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public SequenceList<int> FindOfIndex(T item, bool isAll = true)
        {
            SequenceList<int> list = new SequenceList<int>();
            DoubleLinkedListNode<T> tempNode = FirstNode;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (tempNode.Data.Equals(item))
                {
                    list.Insert(i);
                    if (!isAll)
                        return list;
                }
                tempNode = tempNode.NextNode;
            }

            return list;
        }

        public int GetLength()
        {
            return Count;
        }

        /// <summary>
        /// 插入操作，默认在末尾插入
        /// </summary>
        /// <param name="item">插入的对象</param>
        /// <param name="index">下标</param>
        public void Insert(T item, int index = -1)
        {
            DoubleLinkedListNode<T> lastNode = null;
            DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(item);

            //在末尾插入
            if (index == -1 || index == Count-1)
            {
                if (Count == 0)
                {
                    FirstNode = newNode;
                }
                else
                {
                    lastNode = GetNode(Count - 1);
                    newNode.PreNode = lastNode;
                    newNode.NextNode = FirstNode;
                    lastNode.NextNode = newNode;
                    FirstNode.PreNode = newNode;
                }
                Count++;
                return;
            }

            if (!IsIndexInCount(index))
                return;

            //在头节点插入
            if (index == 0)
            {
                if (Count == 0)
                {
                    FirstNode = newNode;
                }
                else
                {
                    lastNode = GetNode(Count - 1);
                    newNode.NextNode = FirstNode;
                    newNode.PreNode = lastNode;
                    FirstNode.PreNode = newNode;
                    lastNode.NextNode = newNode;
                    FirstNode = newNode;
                }
                Count++;
                return;
            }

            //中间节点插入
            ThressDoubleNode<T> nodes = GetNodesByIndex(index);
            DoubleLinkedListNode<T> insertNode = new DoubleLinkedListNode<T>(item, nodes.CurrentNode, nodes.PreNode);

            if (nodes.PreNode != null)
            {
                nodes.PreNode.NextNode = insertNode;
            }
            else
            {
                Debug.Log("nodes.PreNode为空");
            }

            if (nodes.NextNode != null)
            {
                nodes.NextNode.PreNode = insertNode;
            }
            else
            {
                Debug.Log("nodes.NextNode为空");
            }
            Count++;
            return;
        }

        public bool IsEmpty()
        {
            return Count == 0 ? true : false;
        }

        /// <summary>
        /// 打印列表
        /// </summary>
        /// <param name="prefixion"></param>
        /// <returns></returns>
        public string PrintList(string prefixion = "")
        {
            StringBuilder str = new StringBuilder(prefixion);
            str.Append(ToString());
            Debug.Log(str);
            return str.ToString();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            DoubleLinkedListNode<T> tempNode = FirstNode;
            for (int i = 0; i < Count; i++)
            {
                str.Append(System.String.Format(StringManager.DATA_INDEX, i));
                str.Append(tempNode.Data);
                str.Append("\n");
                tempNode = tempNode.NextNode;
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取下表对应关联的三个节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ThressDoubleNode<T> GetNodesByIndex(int index)
        {
            ThressDoubleNode<T> data = new ThressDoubleNode<T>();

            if (index == 0)
            {
                data.PreNode = null;
                data.CurrentNode = FirstNode;
                data.NextNode = FirstNode.NextNode;
                return data;
            }
            else
            {
                data.PreNode = FirstNode;
                data.CurrentNode = null;
                data.NextNode = null;
            }

            for (int i = 0; i <= index - 1; i++)
            {
                data.PreNode = data.PreNode.NextNode;
            }

            if (data.PreNode != null)
            {
                data.CurrentNode = data.PreNode.NextNode;
            }

            if (data.CurrentNode != null)
            {
                data.NextNode = data.CurrentNode.NextNode;
            }
            return data;
        }
    }

    /// <summary>
    /// 双链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DoubleLinkedListNode<T>: LinkedListNode<T>
    {
        //public T Data;
        public new DoubleLinkedListNode<T> NextNode;
        public DoubleLinkedListNode<T> PreNode;

        public DoubleLinkedListNode()
        {
            Data = default(T);
            NextNode = null;
            PreNode = null;
        }

        public DoubleLinkedListNode(T value)
        {
            Data = value;
            NextNode = null;
            PreNode = null;
        }

        public DoubleLinkedListNode(T value, DoubleLinkedListNode<T> next, DoubleLinkedListNode<T> pre)
        {
            Data = value;
            NextNode = next;
            PreNode = pre;
        }
    }


    class ThressNode<T>
    {
        public LinkedListNode<T> PreNode;
        public LinkedListNode<T> CurrentNode;
        public LinkedListNode<T> NextNode;
    }

    class ThressDoubleNode<T>
    {
        public DoubleLinkedListNode<T> PreNode;
        public DoubleLinkedListNode<T> CurrentNode;
        public DoubleLinkedListNode<T> NextNode;
    }
}
