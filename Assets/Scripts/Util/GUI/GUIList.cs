using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIList
{

    /// <summary>
    /// 添加对象
    /// </summary>
    /// <param name="item"> item </param>
    /// <param name="list"> 列表 </param>
    public static void AddItem(GameObject item,Transform list)
    {
        Transform content = list.Find("content");
        item.transform.SetParent(content);
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.parent.GetComponent<RectTransform>());
    }

    /// <summary>
    /// 设置GUIList的大小
    /// </summary>
    /// <param name="width">宽度</param>
    /// <param name="height">高度</param>
    /// <param name="list">列表对象</param>
    public static void SetItemSize(float width, float height, Transform list)
    {
        Transform content = list.Find("content");
        GridLayoutGroup layout = content.GetComponent<GridLayoutGroup>();
        layout.cellSize = new Vector2(width,height);
    }

    /// <summary>
    /// 设置List类型
    /// </summary>
    /// <param name="list">列表对象</param>
    /// <param name="type">固定列数；固定行数</param>
    /// <param name="fixedNum">固定值</param>
    public static void SetListType(Transform list, GridLayoutGroup.Constraint type = GridLayoutGroup.Constraint.FixedColumnCount, int fixedNum = 1)
    {
        Transform content = list.Find("content");
        GridLayoutGroup layout = content.GetComponent<GridLayoutGroup>();
        layout.constraint = type;
        layout.constraintCount = fixedNum;
    }
}
