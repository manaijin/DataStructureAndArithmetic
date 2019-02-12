using Framwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Component
{
    public class VLIst: Framwork.Component
    {
        public delegate GameObject SetItemFunction(int index);
        public SetItemFunction itemFunction;
        private Transform content;

        public VLIst()
        {
            component = LoadResources.LoadPrefab("Prefab/Custom/V_list");
            content = component.transform.Find("content");
        }

        public VLIst(GameObject _component)
        {
            component = _component;
            content = component.transform.Find("content");
        }

        private int _dataCount;

        public int dataCount
        {
            get { return _dataCount; }
            set
            {
                _dataCount = value;
                Framwork.Component.removeAllChilds(content);
                if (itemFunction == null)
                    return;
                for (int i = 0; i < _dataCount; i++)
                {
                    GameObject item = itemFunction(i);
                    AddChild(item);
                }
            }
        }

        public void AddChild(GameObject item)
        {
            item.transform.SetParent(content);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
