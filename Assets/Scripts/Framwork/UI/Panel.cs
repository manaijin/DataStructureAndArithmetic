using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = System.Object;

namespace Framwork
{
    public class Panel : IPage
    {
        /// <summary>
        /// 页面根节点
        /// </summary>
        public GameObject Root;

        public Panel()
        {
            AddListener();
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        public virtual void AddListener()
        {
            
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        public virtual void RemoveListener()
        {
            
        }

        /// <summary>
        /// 移除对象所有子节点
        /// </summary>
        /// <param name="obj"></param>
        public static void RemoveAllChilds(Transform  obj)
        {
            if (obj == null)
            {
                return;
            }

            GameObject childObj = null;
            for (int i = 0; i < obj.childCount; i++)
            {
                childObj = obj.GetChild(i).gameObject;
                if (childObj)
                {
                    GameObject.Destroy(childObj);
                }
            }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        public virtual void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 清空引用
        /// </summary>
        public virtual void Dispose()
        {
            RemoveListener();

            if (Root)
            {
                foreach (Transform child in Root.transform)
                {
                    GameObject.Destroy(child);
                }
                GameObject.Destroy(Root);
            }

            Resources.UnloadUnusedAssets();
        }
    }
}
