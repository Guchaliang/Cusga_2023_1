using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0103 : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public int roomCount;//���뷿�����
    public bool new_room;//�Ƿ�����·���

    // Update is called once per frame
    void Update()
    {//���������update�ĳ�һ�����������뷿�������������
        if (new_room)
        {//�����·���
            if (myBag.itemList.Find(x => x.itemName.Contains("0103")))
            {
                CharacterData_So.protect += roomCount;
                Debug.Log("��ǰ����" + CharacterData_So.protect);
            }
        }
    }
}
