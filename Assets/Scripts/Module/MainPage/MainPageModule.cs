using System.Collections;
using System.Collections.Generic;
using Framwork;
using Module.Component;
using UnityEngine.UI;
using UnityEngine;


public class MainPageModule:Panel
{
    public Image img_Bg;
    public Text txt_title;
    public VLIst img_list;

    public MainPageModule():base() {
        page = LoadResources.LoadPrefab("Prefab/MainPage/Root");
        if (!page)
        {
            Debug.Log("Prefab/MainPage/Root不存在");
            return;
        }
        img_Bg = page.transform.Find("panel_Main/img_Bg").GetComponent<Image>();
        txt_title = page.transform.Find("panel_Main/txt_title").GetComponent<Text>();
        img_list = new VLIst(page.transform.Find("panel_Main/V_list").gameObject);
    }

    public override void AddListener()
    {
        base.AddListener();
    }

    public override void RemoveListener()
    {
        base.RemoveListener();
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
