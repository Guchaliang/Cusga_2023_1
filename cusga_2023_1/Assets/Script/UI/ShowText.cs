using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //必须要继承的接口 具体就不多说，可以网上查
{
    private Item item;
    public GameObject tupian;//要显示的文字
    private Text itemInfo;
    private void Start()
    {
        itemInfo.text = item.itemInfo;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        tupian.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
        tupian.SetActive(false);
    }
}