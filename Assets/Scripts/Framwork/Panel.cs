using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Framwork
{
    public class Panel : MonoBehaviour,IPage
    {
        public GameObject page;

        public Panel()
        {
            AddListener();
        }

        public virtual void AddListener()
        {
            
        }

        public virtual void RemoveListener()
        {
            
        }

        /// <summary>
        /// 移除所有子节点
        /// </summary>
        /// <param name="obj"></param>
        public static void removeAllChilds(Transform  obj)
        {
            if (obj == null)
            {
                return;
            }
            for (int i = 0; i < obj.childCount; i++)
            {
                GameObject.Destroy(obj.GetChild(i).gameObject);
            }
            obj.DetachChildren();
        }

        public virtual void Dispose()
        {
            RemoveListener();
            foreach (Transform child in this.transform)
            {
                Destroy(child);
            }
            Destroy(page);
            page = null;
            Resources.UnloadUnusedAssets();
        }
    }
}
