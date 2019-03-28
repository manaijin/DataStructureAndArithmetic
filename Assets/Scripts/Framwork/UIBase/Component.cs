using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Framwork.UIBase
{
    public class Component : IComponent
    {
        /// <summary>
        /// 组件根节点
        /// </summary>
        public GameObject component;

        /// <summary>
        /// 移除所有子对象
        /// </summary>
        /// <param name="obj"></param>
        public static void removeAllChilds(Transform obj)
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

        /// <summary>
        /// 销毁component
        /// </summary>
        public virtual void Dispose()
        {
            GameObject.Destroy(component);
        }
    }
}
