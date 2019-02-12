using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Framwork
{
    public class Component : MonoBehaviour, IComponent
    {
        public GameObject component;

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

        public virtual void Dispose()
        {
            Destroy(component);
        }
    }
}
