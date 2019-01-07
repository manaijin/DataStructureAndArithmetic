using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVUtil
{
    /// <summary>
    /// 主键名
    /// </summary>
    public string MainKey { get { return _id; } }
    private readonly string _id;

    /// <summary>
    /// 所有键名
    /// </summary>
    public string[] Keys { get { return _keys; } }
    private readonly string[] _keys;

    /// <summary>
    /// 键值类型
    /// </summary>
    private Dictionary<string, string> _keysType;

    /// <summary>
    /// 获取键值
    /// </summary>
    public static void SetKeys()
    {

    }

    /// <summary>
    /// 设置主键
    /// </summary>
    public static void SetMainKey()
    {

    }
}
