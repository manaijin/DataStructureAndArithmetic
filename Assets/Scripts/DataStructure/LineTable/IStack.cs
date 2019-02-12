using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.LineTable
{
    internal interface IStack<T>
    {
        /// <summary>
        /// 入栈操作
        /// </summary>
        void Push(T item);

        /// <summary>
        /// 出栈操作
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// 返回栈顶值
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// 清空栈
        /// </summary>
        void Clear();

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 数组长度
        /// </summary>
        /// <returns></returns>
        int GetLength();
    }
}
