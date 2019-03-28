using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Manager.Path
{
    class ResourcesPath
    {
        private static ResourcesPath ins = null;

        public static ResourcesPath Ins {
            get
            {
                if (ins == null)
                {
                    ins = new ResourcesPath();
                }
                return ins;
            }
        }

        /// <summary>
        /// 资源路径对象：资源名称-资源路径
        /// </summary>
        private Dictionary<string,string> Paths = new Dictionary<string, string>();

        public ResourcesPath()
        {
            string str = ResourcesManager.LoadText("Text/ResourceDir");
            string[] tempStr = str.Split('\n');
            string[] keyAndVel;
            for (int i = 0; i < tempStr.Length - 1; i++)
            {
                keyAndVel = tempStr[i].Split(',');
                if (keyAndVel != null && keyAndVel.Length == 2)
                {
                    keyAndVel[1] = keyAndVel[1].Replace("\r", "");
                    Paths.Add(keyAndVel[0],keyAndVel[1]);
                }
                else
                {
                    UnityEngine.Debug.LogWarning("资源路径格式有误：" + keyAndVel);
                }
            }
        }

        /// <summary>
        /// 根据资源名获取路径
        /// </summary>
        /// <param name="filename"></param>
        public string GetPath(string filename)
        {
            string path;
            Paths.TryGetValue(filename,out path);
            return path;
        }
    }
}
