using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public static class StringManager
{
    public const string DATA_INDEX = "data[{0}]:";

    static StringManager()
    {
        Debug.Log("初始化静态类");
    }
}
