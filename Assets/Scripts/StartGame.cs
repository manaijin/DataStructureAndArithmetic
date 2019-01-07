using System;
using System.Collections;
using System.Collections.Generic;
using DataStructure.LineTable;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject root;
    private Button LineTable;
    private GameObject LineTablePanel;

    void Start()
    {
        Screen.SetResolution(1920,1080,false);
        Init();
        if (root)
        {
            GUIList.SetItemSize(200,100, root.transform.Find("panel_Main/img_list"));
        }
        else
        {
            Debug.Log("加载主页面失败");
        }
    }

    private void Init()
    {
        root = LoadResources.LoadPrefab("Prefab/Root");
        LineTable = root.transform.Find("panel_Main/img_list/content/LineTable").GetComponent<Button>();
        AddListener();
    }

    private void AddListener()
    {
        LineTable.onClick.AddListener(OnClickLineTable);
    }

    private void RemoveListener()
    {
        LineTable.onClick.RemoveAllListeners();
    }

    private void OnClickLineTable()
    {
        if(!LineTablePanel)
            LineTablePanel = LoadResources.LoadPrefab("Prefab/LineTablePanel");

        if (LineTablePanel && root)
        {
            LineTablePanel.transform.parent = root.transform;
        }

        SequenceList<GameObject> data = new SequenceList<GameObject>(100);
        data.Insect(new GameObject());
        data.Insect(new GameObject());
        data.Insect(new GameObject());
        data.Insect(new GameObject(), 10);
        data.PrintList();
    }

    void OnDestroy()
    {
        RemoveListener();
    }

}
