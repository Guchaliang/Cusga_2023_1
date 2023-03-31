using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0201 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHit;//是否为受击状态
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public float addDamage;
    public BagList myBag;
    public float testTime;//装备buff时间剩余
    public float setTime;//额定装备buff时间
    public bool flag=true;
    public bool flag1 = true;
    public float damage1;
    // Update is called once per frame
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0201")))//携带了这件装备
            if (isHit)//将来可以改成如果isHit调用这个脚本下面
        {   
                if (testTime > 0) {testTime -= Time.deltaTime;//一次性计时器
                    if (flag1)
                    {
                        damage1 = AttackData_So.damage;//记录原始damage
                        AttackData_So.damage += addDamage;//受击状态加伤害
                       CharacterData_So.currentHealth += CharacterData_So.currentHealth;//生命加上防御
                        CharacterData_So.currentDefence = 0;//防御清空
                        flag1 = false;//让伤害只能增加一次否则一直加
                    }                                      }
            
              else if(testTime<=0&&flag)
                {
                    testTime = setTime;
                flag = false;
                AttackData_So.damage = damage1;
                }
                                                }
              
        }
    }

