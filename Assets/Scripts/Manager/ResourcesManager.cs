using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class LoadResources:MonoBehaviour
{
    /// <summary>
    /// 加载Prefab
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static GameObject LoadPrefab(string path)
    {
        Object prefabObj = Resources.Load(path);
        GameObject obj = null;
        if (prefabObj)
        {
            obj = Instantiate(prefabObj) as GameObject;
        }
        else
        {
            Debug.Log(path + "不存在");
        }
        return obj;
    }

    /// <summary>
    /// 删除对象并清理资源
    /// </summary>
    /// <param name="obj"></param>
    public static void Destory(GameObject obj)
    {
        Destroy(obj);
        Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// 加载Resources文本文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string LoadText(string path)
    {
        string s = "";
        TextAsset textFile = Resources.Load<TextAsset>(path);
        if (textFile != null)
        {
            s = textFile.text;
        }
        return s;
    }
}
