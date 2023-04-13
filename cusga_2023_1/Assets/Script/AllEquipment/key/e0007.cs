using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0007 : MonoBehaviour
{
    // Start is called before the first frame update
     enum room_award {health,defence};
    public int roomaward=1;//奖励类型
    public CharacterData_So characterData_So;
    public bool new_room;
    public BagList myBag;
    public void f0007()
    {
        if (new_room)
        {//进入新房间’0007‘
            if (myBag.itemList.Find(x => x.itemName.Contains("0007")))
            {//装备了这个装备
                roomaward = (int)room_award.health;
                characterData_So.room_award = roomaward;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            f0007();
    }
}
