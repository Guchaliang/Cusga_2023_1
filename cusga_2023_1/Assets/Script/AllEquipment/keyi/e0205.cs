using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0205 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHit;//是否为受击状态
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float testTime;//装备buff时间剩余
    public float setTime;//额定装备buff时间
    public bool flag = true;
    public float damage1;//本次攻击伤害
    public float suckblood;//吸血量
    public float suckbloodRate;//吸血率
    public float delmaxHealth;//永久扣除n点血量上限
    // Update is called once per frame
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0205")))//携带了这件装备
            if (isHit)//将来可以改成如果isHit调用这个脚本下面
            {
                if (testTime > 0)
                {
                    testTime -= Time.deltaTime;//一次性计时器
                    suckblood = suckbloodRate * damage1;//吸血量
                    if (CharacterData_So.currentHealth < CharacterData_So.maxHealth)
                        CharacterData_So.currentHealth += suckblood;
                    else { CharacterData_So.currentHealth = CharacterData_So.maxHealth; }
                }


                else if (testTime <= 0 && flag)//计时结束
                {
                   
                    CharacterData_So.maxHealth -= delmaxHealth;
                    CharacterData_So.currentHealth -= CharacterData_So.maxHealth;
                    flag = false;
                     testTime = setTime;
                }
            }
    }
    }

