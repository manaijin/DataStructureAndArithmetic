using Framwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Module.Component
{
    public class VLIst: Framwork.Component
    {
        private delegate void SetItemFunction(System.Object item, int index);
        SetItemFunction itemFunction;

        public VLIst()
        {
            component = LoadResources.LoadPrefab("Prefab/Custom/V_list");
        }

        public VLIst(GameObject _component)
        {
            component = _component;
        }

        public ArrayList dataSource
        {
            get { return dataSource;}
            set
            {
                dataSource = value;
                if (itemFunction == null)
                    return;
                for (int i = 0; i < value.Count; i++)
                {
                    itemFunction(dataSource[i], i);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
