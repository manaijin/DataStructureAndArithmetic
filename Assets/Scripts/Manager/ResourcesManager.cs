using Manager.Path;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public static class ResourcesManager
{
    /// <summary>
    /// 根据路径加载Prefab
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static GameObject LoadPrefabByPath(string path)
    {
        Object prefabObj = Resources.Load(path);
        GameObject obj = null;
        if (prefabObj)
        {
            obj = GameObject.Instantiate(prefabObj) as GameObject;
        }
        else
        {
            Debug.Log(path + "不存在");
        }
        return obj;
    }

    /// <summary>
    /// 根据文件名称加载Prefab
    /// </summary>
    /// <returns></returns>
    public static GameObject LoadPrfabByName(string name)
    {
        GameObject Root;
        string rootPath = ResourcesPath.Ins.GetPath("Root.prefab");
        Root = ResourcesManager.LoadPrefabByPath(rootPath);
        if(!Root)
            Debug.LogError("加载路径：" + rootPath + "有误");
        return Root;
    }

    /// <summary>
    /// 删除对象并清理资源
    /// </summary>
    /// <param name="obj"></param>
    public static void Destory(GameObject obj)
    {
        GameObject.Destroy(obj);
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
