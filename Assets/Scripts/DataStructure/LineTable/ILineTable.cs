using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILineTable<T>
{
    /// <summary>
    /// 插入一个元素
    /// </summary>
    /// <param name="index"></param>
    void Insect(T item,int index);

    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="index">所有下表</param>
    void Delete(int index);

    /// <summary>
    /// 删除指定元素  
    /// </summary>
    /// <param name="item"></param>
    void Delete(T item);

    /// <summary>
    /// 索引器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    T this[int index] { get; }

    /// <summary>
    /// 获取长度
    /// </summary>
    void GetLength();

    /// <summary>
    /// 查找对象在列表中的下标
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    int FindOfIndex(T item);

    /// <summary>
    /// 是否为空
    /// </summary>
    /// <returns></returns>
    bool IsEmpty();

    /// <summary>
    /// 清空数据
    /// </summary>
    void Clear();

    /// <summary>
    /// 打印列表
    /// </summary>
    void PrintList();
}
