using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //����Ҫ�̳еĽӿ� ����Ͳ���˵���������ϲ�
{
    private Item item;
    public GameObject tupian;//Ҫ��ʾ������
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