using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0105 : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterData_So CharacterData_So;
    public float thisHealth;//记录拾取装备时的生命值-1
    public float thisdefence;
    public float testTime;//装备buff时间剩余
    public float setTime;//额定装备buff时间
    public bool flag = true;
    public bool flag1 = true;
    // Update is called once per frame
    public void f0105()
    {
         CharacterData_So.currentHealth=thisHealth ;//记录原始数据
         CharacterData_So.currentDefence=thisdefence ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (testTime > 0)
            {
                testTime -= Time.deltaTime;//一次性计时器
                if (flag1)
                {
                    Debug.Log(thisHealth);
                    CharacterData_So.currentHealth = 1;
                    CharacterData_So.currentDefence += thisHealth;
                    flag1 = false;
                }

            }
            else if (testTime <= 0 && flag)
            {
                testTime = setTime;
                thisHealth = CharacterData_So.currentHealth ;//记录原始数据
                thisdefence = CharacterData_So.currentDefence;
                flag = false;
            }
            if (testTime <= 0 && !flag && !flag1)
            {
                f0105();//恢复数据用
            }
        }
    }
}
