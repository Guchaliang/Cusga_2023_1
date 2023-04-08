using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Circle : MonoBehaviour
{
    [Header("ת���ٶ�")]
    public float speed = 1f;
    [Header("�뾶")]
    public float radius = 3.5f;
    [Header("     ")]

    //���ĵ�
    public Transform center;
    private Transform[] childrenTransforms;
    public List<Transform> Points;
    private void Start()
    {
        childrenTransforms = gameObject.transform.GetComponentsInChildren<Transform>();
        Points = new List<Transform>(gameObject.transform.GetComponentsInChildren<Transform>());

        InvokeRepeating("ChildMove", 1f, 0.2f);
    }


    //������������ɢ
    private void ChildMove()
    {
        for (int i = 0; i < childrenTransforms.Length; i++)
        {
            Vector3 dir = childrenTransforms[i].transform.position - center.position;
            dir /= 10;
            childrenTransforms[i].transform.DOMove(dir, 1);
        }
    }
    
}
