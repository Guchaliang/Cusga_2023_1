using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //������Ʒ�ĸ�����
    private Transform nowparent;
    //Top��λ��
    private Transform TopPos;
    //��Ʒ�ƶ���ƫ����
    private Vector3 offset = new Vector3();

    private RectTransform rectTransform;
    //ԭ�ߴ�
    private Vector3 initScale;
    public void OnPointerDown(PointerEventData eventData)
    {
        //���������������Լ����ĵ�ƫ����
        offset = Input.mousePosition - transform.position;
        //��¼���µĸ��ڵ�
        nowparent = transform.parent;       

        //initScale = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //rectTransform = GetComponent<RectTransform>();
        //rectTransform.sizeDelta = initScale * 1.5f;
        //����Ʒ��Ⱦ����߲�
        //transform.parent = TopPos;

    }
    public void OnDrag(PointerEventData eventData)
    {       
        //��ק
        transform.position = Input.mousePosition - offset;          
        IsRaycast(false);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // ��⵱ǰ������ײ��������
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        IsRaycast(true);
        //rectTransform.sizeDelta = initScale;
        //transform.DOKill();
        //Debug.Log(go.name);
        //Debug.Log(go.tag);
        //�ж������Ƿ��⵽����
        if (go.tag == "Untagged")
        {
            Debug.Log("�ϵ������ط�ʱ�����巵�ص���ʼ�ĸ������λ�úͳ�Ϊ������");   
            //�ϵ������ط�ʱ�����巵�ص���ʼ�ĸ������λ�úͳ�Ϊ������
            SetPosandParent(transform, nowparent);
            return;
        }
        //�����ǰ������װ������û����Ʒ��
        else if (go.tag == "Equip")
        {
            Debug.Log("��ǰ������װ�����ӣ�û����Ʒ��");
            SetPosandParent(transform, go.transform);

            //����װ������
        }
        //�����ǰ�����Ǹ��ӣ�û����Ʒ��
        else if (go.tag == "Bag")
        {
            Debug.Log("��ǰ�����Ǳ������ӣ�û����Ʒ��");
            SetPosandParent(transform, go.transform);
        }
        //�����ǰ��������Ʒ
        else if (go.tag == "goods")
        {
            Debug.Log("��ǰ��������Ʒ������λ�ã�");
            Transform GoParent = go.transform.parent;
            SetPosandParent(go.transform, nowparent);
            SetPosandParent(transform, GoParent);
        }
    }

    //д�����ǵĸ������Լ�λ��
    private void SetPosandParent(Transform trans, Transform parent)
    {
        trans.SetParent(parent);
        trans.position = parent.position;
    }
    private void IsRaycast(bool flag)
    {
        //���������Ƿ�ס����
        transform.GetComponent<Image>().raycastTarget = flag;
    }
    
}