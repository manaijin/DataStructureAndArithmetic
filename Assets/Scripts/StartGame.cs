using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private MainPageModule root;

    void Start()
    {
        Init();
        if (root.page)
        {
            GUIList.SetItemSize(200,100, root.page.transform.Find("panel_Main/V_list"));
        }
        else
        {
            Debug.Log("加载主页面失败");
        }
    }

    private void Init()
    {
        root = new MainPageModule();
    }



}
