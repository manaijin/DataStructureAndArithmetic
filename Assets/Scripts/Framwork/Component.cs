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

        public virtual void Dispose()
        {
            Destroy(component);
        }
    }
}
