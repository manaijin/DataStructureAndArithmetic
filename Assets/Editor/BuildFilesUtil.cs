using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildFilesUtil
{
    [MenuItem("GameTools/Bulid/创建Prefab类文件")]
    public static void BuildScriptsForPrefabs()
    {
    }

    [MenuItem("GameTools/Bulid/创建资源路径文件")]
    public static void BuildResourcesPathFile()
    {

    }

    /// <summary>
    /// 返回根目录下的所有结构目录
    /// </summary>
    /// <param name="rootPath">根节点</param>
    /// <param name="list">输出列表</param>
    /// <param name="subDir"></param>
    /// <returns></returns>
    public static List<string> GetAllDir(string rootPath, List<string> list ,string subDir = "")
    {
        DirectoryInfo dir = new DirectoryInfo(rootPath);
        DirectoryInfo[] dirinfo = dir.GetDirectories();

        for (int i = 0; i < dirinfo.Length; i++)
        {
            list.Add(dirinfo[i].FullName);
            GetAllDir(dirinfo[i].FullName, list);
        }
        return list;
    }

    /// <summary>
    /// 遍历目录，输出所有文件目录
    /// </summary>
    /// <param name="Dir1">搜索节点</param>
    /// <param name="Dir2">截取节点</param>
    public static void TraversalDir(string Dir1,  string Dir2)
    {

    }
}
