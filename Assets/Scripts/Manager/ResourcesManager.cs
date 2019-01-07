using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadResources:MonoBehaviour
{
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
}
