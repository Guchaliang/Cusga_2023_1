using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0007 : MonoBehaviour
{
    // Start is called before the first frame update
     enum room_award {health,defence};
    public int roomaward=1;//��������
    public CharacterData_So characterData_So;
    public bool new_room;
    public BagList myBag;
  void Update()
    {
        if (new_room)
        {//�����·��䡯0007��
            if (myBag.itemList.Find(x => x.itemName.Contains("0007"))){//װ�������װ��
                roomaward=(int)room_award.health;
                characterData_So.room_award=roomaward;

            }
        }
    }
}
