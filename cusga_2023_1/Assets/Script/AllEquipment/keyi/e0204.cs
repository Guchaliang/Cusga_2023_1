using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0204 : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public int roomCount;//进入房间个数
    public bool new_room;//是否进入新房间

    // Update is called once per frame
    void Update()
    {//将来把这个update改成一个函数，进入房间后调用这个函数
        if (new_room)
        {//进入新房间
            if (myBag.itemList.Find(x => x.itemName.Contains("0204")))
            {
                CharacterData_So.currentHealth += roomCount;
                Debug.Log("当前生命" + CharacterData_So.currentHealth);
            }
        }
    }
}
