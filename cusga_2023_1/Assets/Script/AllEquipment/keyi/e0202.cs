using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0202 : MonoBehaviour
{
    public bool isHit;//是否为受击状态
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float injuryMax;//最大免伤量
    public float currentInjury;//当前免伤量
    public float passroom_num;//通过房间数量
    public float thisinjury;//当前收到的伤害
    public float injury_total;//最终应受到的伤害
    public int room_num_total;//总房间数量，后期在用房间的脚本改
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0202")))//携带了这件装备
            if (isHit)//将来可以改成如果isHit调用这个脚本下面
            {
                
                if (currentInjury < injuryMax)
                {
                    currentInjury += thisinjury;//记录总免伤量
                }
                else
                {

                 injury_total = (room_num_total-passroom_num) / room_num_total* injuryMax+(currentInjury-injuryMax);//加上超出的部分才行

                }
              
            }
    }
}
