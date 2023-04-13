using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e206 : MonoBehaviour
{
    public bool isHit;//是否为受击状态
    public AttackData_So AttackData_So;
    public CharacterData_So CharacterData_So;
    public BagList myBag;
    public float damage1;//本次攻击伤害
    public float suckblood;//吸血量
    public CharacterData_So enemy;
    public int enemycount;//敌人数量
    public float n;//对所有敌人造成的单体伤害
    public float e206_Id;//206装备冷却
    public float thisId;//当前装备冷却剩余时间
    private bool flag=true;
    // Update is called once per frame
    void Update()
    {
        if (myBag.itemList.Find(z => z.itemName.Contains("0206")))//携带了这件装备
            if (flag)
            { 
                flag = false;
                thisId = e206_Id;
            }     
        if (thisId <0) { //装备冷却
            
                if (isHit)//将来可以改成如果isHit调用这个脚本下面
            {
                if (damage1 > CharacterData_So.currentHealth)//当前收到的伤害超过了生命值
                {
                    
                    if(Random.Range(0, 10000) / 5 == 0)//20%的概率
                    {
                        damage1 = 0;//免伤
                        enemy.currentHealth-=n;//全部伤害
                        suckblood += enemycount * 2;//按敌人数量2倍回血
                        if (CharacterData_So.currentHealth < CharacterData_So.maxHealth)
                            CharacterData_So.currentHealth += suckblood;//回血
                        else { CharacterData_So.currentHealth = CharacterData_So.maxHealth; }
                    }
                }
            }
        }else if (thisId >=0 )
        { thisId-=Time.deltaTime;  
        }
    }
}
