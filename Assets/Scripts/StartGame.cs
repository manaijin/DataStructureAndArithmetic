using UnityEngine;
using Framwork.Path;


public class StartGame : MonoBehaviour
{
    private MainPageModule root;

    void Start()
    {
        Init();
        if (root.Root)
        {
            GUIList.SetItemSize(200,100, root.Root.transform.Find("panel_Main/V_list"));
        }
        else
        {
            Debug.Log("加载主页面失败");
        }
    }

    private void Init()
    {
        //加载主页面
        root = new MainPageModule();
    }
}
