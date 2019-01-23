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

        public virtual void Dispose()
        {
            RemoveListener();
            foreach (Transform child in this.transform)
            {
                Destroy(child);
            }
            Destroy(page);
            Resources.UnloadUnusedAssets();
        }
    }
}
