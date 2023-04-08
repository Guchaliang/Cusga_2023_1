using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //现在物品的父物体
    private Transform nowparent;
    //Top的位置
    private Transform TopPos;
    //物品移动的偏移量
    private Vector3 offset = new Vector3();

    private RectTransform rectTransform;
    //原尺寸
    private Vector3 initScale;
    public void OnPointerDown(PointerEventData eventData)
    {
        //按下鼠标计算鼠标和自己轴心的偏移量
        offset = Input.mousePosition - transform.position;
        //记录当下的父节点
        nowparent = transform.parent;       

        //initScale = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //rectTransform = GetComponent<RectTransform>();
        //rectTransform.sizeDelta = initScale * 1.5f;
        //把物品渲染到最高层
        //transform.parent = TopPos;

    }
    public void OnDrag(PointerEventData eventData)
    {       
        //拖拽
        transform.position = Input.mousePosition - offset;          
        IsRaycast(false);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // 检测当前射线碰撞到的物体
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        IsRaycast(true);
        //rectTransform.sizeDelta = initScale;
        //transform.DOKill();
        //Debug.Log(go.name);
        //Debug.Log(go.tag);
        //判断射线是否检测到物体
        if (go.tag == "Untagged")
        {
            Debug.Log("拖到其他地方时，物体返回到开始的父物体的位置和成为子物体");   
            //拖到其他地方时，物体返回到开始的父物体的位置和成为子物体
            SetPosandParent(transform, nowparent);
            return;
        }
        //如果当前物体是装备栏（没有物品）
        else if (go.tag == "Equip")
        {
            Debug.Log("当前物体是装备格子（没有物品）");
            SetPosandParent(transform, go.transform);

            //调用装备数据
        }
        //如果当前物体是格子（没有物品）
        else if (go.tag == "Bag")
        {
            Debug.Log("当前物体是背包格子（没有物品）");
            SetPosandParent(transform, go.transform);
        }
        //如果当前物体是物品
        else if (go.tag == "goods")
        {
            Debug.Log("当前物体是物品（交换位置）");
            Transform GoParent = go.transform.parent;
            SetPosandParent(go.transform, nowparent);
            SetPosandParent(transform, GoParent);
        }
    }

    //写入我们的父物体以及位置
    private void SetPosandParent(Transform trans, Transform parent)
    {
        trans.SetParent(parent);
        trans.position = parent.position;
    }
    private void IsRaycast(bool flag)
    {
        //设置物体是否挡住射线
        transform.GetComponent<Image>().raycastTarget = flag;
    }
    
}