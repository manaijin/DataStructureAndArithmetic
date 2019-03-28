using Manager.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framwork.UIBase;
using UnityEngine;
using UnityEngine.UI;

namespace Framwork.Component
{
    class CustomButton: UIBase.Component
    {
        /// <summary>
        /// 按钮组件
        /// </summary>
        public Button btn;

        /// <summary>
        /// 文本组件
        /// </summary>
        public Text text;

        /// <summary>
        /// 背景图片
        /// </summary>
        public Image bg;

        public CustomButton()
        {
            string path = ResourcesPath.Ins.GetPath("Button.prefab");
            component = ResourcesManager.LoadPrefabByPath(path);
            if (!component)
            {
                Debug.LogError("按钮资源路径:" + path + "有误");
                return;
            }
            
            text = component.transform.Find("Text").GetComponent<Text>();
            if (!text)
            {
                Debug.LogError("缺少Text组件");
                return;
            }

            btn = component.GetComponent<Button>();
            if (!btn)
            {
                Debug.LogError("缺少Button组件");
                return;
            }

            bg = component.GetComponent<Image>();
            if (!bg)
                Debug.LogError("缺少Image组件");

        }
    }
}
