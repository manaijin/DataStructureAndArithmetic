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
        /// <summary>
        /// 列表函数委托
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public delegate GameObject SetItemFunction(int index);
        /// <summary>
        /// 创建单个item
        /// </summary>
        public SetItemFunction ItemFunction;
        /// <summary>
        /// 用于生产单个item
        /// </summary>
        private Transform content;
        /// <summary>
        /// 容器节点数量
        /// </summary>
        private int dataCount;
        /// <summary>
        /// 设置容器节点数量，并调用ItemFunction创建节点
        /// </summary>
        public int DataCount
        {
            get { return dataCount; }
            set
            {
                dataCount = value;
                Framwork.Component.removeAllChilds(content);
                if (ItemFunction == null)
                    return;
                for (int i = 0; i < dataCount; i++)
                {
                    GameObject item = ItemFunction(i);
                    AddChild(item);
                }
            }
        }

        /// <summary>
        /// 默认List
        /// </summary>
        public VLIst()
        {
            component = LoadResources.LoadPrefab("Prefab/Custom/V_list");
            content = component.transform.Find("content");
            TestVar();
        }

        /// <summary>
        /// 自定义List
        /// </summary>
        /// <param name="_component"></param>
        public VLIst(GameObject _component)
        {
            component = _component;
            content = component.transform.Find("content");
            TestVar();
        }

        /// <summary>
        /// 检测变量是否存在
        /// </summary>
        private void TestVar()
        {
            if (!component)
            {
                Debug.LogError("List加载失败");
            }
            if (!content)
            {
                Debug.LogError("未找到容器节点");
            }
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="item"></param>
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
