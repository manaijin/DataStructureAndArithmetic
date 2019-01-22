using DataStructure.LineTable;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject root;
    private Button LineTable;
    private Transform LineTablePanel;

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
            LineTablePanel = LoadResources.LoadPrefab("Prefab/LineTablePanel").transform;

        if (LineTablePanel && root)
        {
            LineTablePanel.parent = root.transform;
            LineTablePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            LineTablePanel.Find("TextPanel/Label").GetComponent<Text>().text = LoadResources.LoadText("Text/线性表");
        }

        SequenceList<int> data = new SequenceList<int>(100);
        Debug.Log("顺序表是否为空："+data.IsEmpty());
        data.Insect(10);
        data.Insect(10);
        data.Insect(30,0);
        data.Insect(10, 10);
        data.PrintList("顺序表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0,false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("顺序表是否为空："+data.IsEmpty());
    }

    void OnDestroy()
    {
        RemoveListener();
    }

}
