using System.Collections.Generic;
using DataStructure.LineTable;
using Framwork;
using Module.Component;
using UnityEngine.UI;
using UnityEngine;


public class MainPageModule:Panel
{
    public Image ImgBg;
    public Text TxtTitle;
    public VLIst VList;
    private Transform LineTablePanel;

    public MainPageModule():base() {
        page = LoadResources.LoadPrefab("Prefab/MainPage/Root");
        if (!page)
        {
            Debug.Log("Prefab/MainPage/Root不存在");
            return;
        }
        ImgBg = page.transform.Find("panel_Main/img_Bg").GetComponent<Image>();
        TxtTitle = page.transform.Find("panel_Main/txt_title").GetComponent<Text>();
        VList = new VLIst(page.transform.Find("panel_Main/V_list").gameObject);
        Init();
    }

    private void Init()
    {
        VList.itemFunction = new VLIst.SetItemFunction(ListFunction);
        VList.dataCount = 1;
        //TestLinkedList();
        //TestDoubleLinkedList();
        TestStack();
    }

    public override void AddListener()
    {
        base.AddListener();
        
    }

    public override void RemoveListener()
    {
        base.RemoveListener();

    }

    public GameObject ListFunction(int index)
    {
        GameObject item = null;
        switch (index)
        {
            case 0:
                item = LoadResources.LoadPrefab("Prefab/Custom/Button");
                item.transform.Find("Text").GetComponent<Text>().text = "线性表";
                Debug.Log(item.GetComponent<Button>().name);
                Button btn = (Button)item.GetComponent<Button>();
                btn.onClick.AddListener(OnClickLineTable);
                break;
        }
        return item;
    }

    public void OnClickLineTable()
    {
        Debug.Log("OnClickLineTable");
        if (!LineTablePanel)
            LineTablePanel = LoadResources.LoadPrefab("Prefab/LineTablePanel").transform;

        if (LineTablePanel && page)
        {
            LineTablePanel.parent = page.transform;
            LineTablePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            LineTablePanel.Find("TextPanel/Label").GetComponent<Text>().text = LoadResources.LoadText("Text/线性表");
        }

        TestLineTable();
    }

    private void TestLineTable()
    {
        Debug.Log("--------------顺序表测试");
        SequenceList<int> data = new SequenceList<int>(100);
        Debug.Log("顺序表是否为空：" + data.IsEmpty());
        data.Insert(10);
        data.Insert(10);
        data.Insert(30, 0);
        data.Insert(10, 10);
        data.PrintList("顺序表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0, false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("顺序表是否为空：" + data.IsEmpty());
    }

    private void TestLinkedList()
    {
        Debug.Log("--------------单链表测试");
        DataStructure.LineTable.LinkedList<int> data = new DataStructure.LineTable.LinkedList<int>(100);
        Debug.Log("链表是否为空：" + data.IsEmpty());
        data.PrintList();
        data.Insert(1);
        data.PrintList();
        data.Insert(2);
        data.PrintList();
        data.Insert(3, 0);
        data.PrintList("顺序表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0, false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("顺序表是否为空：" + data.IsEmpty());
    }

    private void TestDoubleLinkedList()
    {
        Debug.Log("--------------双链表测试");
        DoubleLinkedList<int> data = new DoubleLinkedList<int>(100);
        Debug.Log("双链表是否为空：" + data.IsEmpty());
        data.PrintList();
        data.Insert(1);
        data.PrintList();
        data.Insert(2);
        data.PrintList();
        data.Insert(3, 0);
        data.PrintList("顺序表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0, false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("顺序表是否为空：" + data.IsEmpty());
    }

    private void TestStack()
    {
        Debug.Log("--------------BCL的Stack测试");
        Stack<char> stack = new Stack<char>();
        stack.Push('a');
        stack.Push('b');
        stack.Push('c');
        Debug.Log(stack.Count);
        char temp = stack.Pop();
        Debug.Log("pop出：" + temp + ",剩余：" + stack.Count);

        Debug.Log("---------------顺序表实现的Stack测试");
        Stack_SequenceList<char> stack2 = new Stack_SequenceList<char>();
        stack2.Push('a');
        stack2.PrintStack();
        stack2.Push('b');
        stack2.PrintStack();
        stack2.Push('c');
        stack2.PrintStack("stack初始值：\n");
        temp = stack2.Pop();
        Debug.Log("pop出：" + temp);
        stack2.PrintStack("stack值：\n");

        Debug.Log("---------------单链表实现的Stack测试");
        Stack_LinkedList<char> stack3 = new Stack_LinkedList<char>();
        stack3.Push('a');
        stack3.Push('b');
        stack3.Push('c');
        stack3.PrintStack("stack初始值：\n");
        temp = stack3.Pop();
        Debug.Log("pop出：" + temp);
        stack3.PrintStack("stack值：\n");

    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
