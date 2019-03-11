using System.Collections.Generic;
using DataStructure.LineTable;
using Framwork;
using Framwork.Path;
using Module.Component;
using UnityEngine.UI;
using UnityEngine;
using Arithmetic;
using Util.Data;


public class MainPageModule:Panel
{
    /// <summary>
    /// 背景图片
    /// </summary>
    public Image ImgBg;
    /// <summary>
    /// 标题文本
    /// </summary>
    public Text TxtTitle;
    /// <summary>
    /// 按钮列表
    /// </summary>
    public VLIst VList;
    /// <summary>
    /// 线性表页面
    /// </summary>
    private Transform LineTablePanel;

    public MainPageModule():base()
    {
        string rootPath = ResourcesPath.Ins.GetPath("Root.prefab");
        Root = LoadResources.LoadPrefab(rootPath);
        if (!Root)
        {
            Debug.Log(rootPath + "路径有误");
            return;
        }
        ImgBg = Root.transform.Find("panel_Main/img_Bg").GetComponent<Image>();
        TxtTitle = Root.transform.Find("panel_Main/txt_title").GetComponent<Text>();
        VList = new VLIst(Root.transform.Find("panel_Main/V_list").gameObject);
        Init();
    }

    private void Init()
    {
        
        VList.ItemFunction = ListFunction;
        VList.DataCount = 1;
        //TestLinkedList();
        //TestDoubleLinkedList();
        //TestStack();
        //TestQueue();
        TestSort();
    }

    public override void AddListener()
    {
        base.AddListener();
        
    }

    public override void RemoveListener()
    {
        base.RemoveListener();

    }

    /// <summary>
    /// 列表函数
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject ListFunction(int index)
    {
        GameObject item = null;
        switch (index)
        {
            case 0:
                string path = ResourcesPath.Ins.GetPath("Button.prefab");
                item = LoadResources.LoadPrefab(path);
                if (!item)
                {
                    Debug.LogError("按钮资源路径:"+ "path" + "有误");
                    break;
                }
                item.transform.Find("Text").GetComponent<Text>().text = "线性表";

                Button btn = item.GetComponent<Button>();
                if (!btn)
                {
                    Debug.LogError("缺少Button组件");
                    break;
                }
                btn.onClick.AddListener(OnClickLineTable);
                break;
        }
        return item;
    }

    /// <summary>
    /// 线性表按钮回调
    /// </summary>
    public void OnClickLineTable()
    {
        Debug.Log("OnClickLineTable");
        if (!LineTablePanel)
            LineTablePanel = LoadResources.LoadPrefab("Prefab/LineTablePanel").transform;

        if (LineTablePanel && Root)
        {
            LineTablePanel.parent = Root.transform;
            LineTablePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            LineTablePanel.Find("TextPanel/Label").GetComponent<Text>().text = LoadResources.LoadText("Text/线性表");
        }

        TestLineTable();
    }

    /// <summary>
    /// 线性表测试
    /// </summary>
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

    /// <summary>
    /// 链表测试
    /// </summary>
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
        data.PrintList("链表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0, false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("链表是否为空：" + data.IsEmpty());
    }

    /// <summary>
    /// 双链表测试
    /// </summary>
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
        data.PrintList("双链表初始值：\n");
        data.DeleteByIndex(0);
        data.PrintList("删除第一个元素：\n");
        data.FindOfIndex(0, false).PrintList("表中等于0的第一个下标：");
        data.FindOfIndex(0).PrintList("表中等于0的所有下标：");
        Debug.Log("双链表是否为空：" + data.IsEmpty());
    }

    /// <summary>
    /// 栈测试
    /// </summary>
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

    /// <summary>
    /// 队列测试
    /// </summary>
    private void TestQueue()
    {
        Debug.Log("--------------BCL的Queue测试");
        Queue<char> queue = new Queue<char>();
        queue.Enqueue('a');
        queue.Enqueue('b');
        queue.Enqueue('c');
        Debug.Log("添加a/b/c,初始队列数量：" + queue.Count);
        char temp = queue.Dequeue();
        Debug.Log("出队：" + temp);
        Debug.Log("队列：" + queue.Count);

        Debug.Log("--------------顺序表实现的Queue测试");
        Queue_SequenceList<char> queue2 = new Queue_SequenceList<char>(3);
        queue2.Enqueue('a');
        queue2.Enqueue('b');
        queue2.Enqueue('c');
        queue2.PrintQueue("初始队列：\n");
        queue2.PrintQueue("出队：" + queue2.Dequeue() + "\n");
        queue2.PrintQueue("出队：" + queue2.Dequeue() + "\n");
        queue2.Enqueue('a');
        queue2.PrintQueue("入队：a\n");
        queue2.PrintQueue("出队：" + queue2.Dequeue() + "\n");
        queue2.Enqueue('b');
        queue2.PrintQueue("入队：b\n");
        queue2.PrintQueue("出队：" + queue2.Dequeue() + "\n");

        Debug.Log("--------------链表实现的Queue测试");
        Queue_LinkedList<char> queue3 = new Queue_LinkedList<char>();
        queue3.Enqueue('a');
        queue3.Enqueue('b');
        queue3.Enqueue('c');
        queue3.PrintQueue("初始队列：\n");
        queue3.PrintQueue("出队：" + queue3.Dequeue() + "\n");
        queue3.PrintQueue("出队：" + queue3.Dequeue() + "\n");
        queue3.Enqueue('a');
        queue3.PrintQueue("入队：a\n");
        queue3.PrintQueue("出队：" + queue3.Dequeue() + "\n");
        queue3.Enqueue('b');
        queue3.PrintQueue("入队：b\n");
        queue3.PrintQueue("出队：" + queue3.Dequeue() + "\n");
    }

    /// <summary>
    /// 测试排序算法
    /// </summary>
    public void TestSort()
    {
        float[] a = new float[] { 12, 5, 6, 7, 3, 6, 19, 8 };
        //直接插入排序
        //a = SortArithmetic<float>.StraightInsertionSort(a);
        //简单选择排序
        //a = SortArithmetic<float>.SelectionSort(a);
        //快速排序
        a = SortArithmetic<float>.QuickSort(a);

        Debug.Log(ArrayUtil<float>.ArrayToString(a));

    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
