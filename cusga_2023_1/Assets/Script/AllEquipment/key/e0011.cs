using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0011 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isroll;//是否翻滚
    public CharacterData_So characterData_So;
    public float addHealth;//回复血量的值
    public float addDolgeid;//翻滚冷却增量
    public float maxDlolgeid;//翻滚冷却最大值
    public BagList myBag;
    public int x;
    public int y;//概率只能是整数
    // Update is called once per frame
    void Update()
    {
        x = Random.Range(1, 10000);
        if (myBag.itemList.Find(z => z.itemName.Contains("0011")))
        {
            if (isroll)
                 {
                         if (x % y == 0)
                                     {
                    Debug.Log("1");
                                 if (characterData_So.currentHealth + addHealth <= characterData_So.maxHealth)
                                                 characterData_So.currentHealth += addHealth;
                                else
                                         {
                                                characterData_So.currentHealth = characterData_So.maxHealth;
                                        }
                                 if(characterData_So.dodgeId+addDolgeid <= maxDlolgeid)
                                                characterData_So.dodgeId += addDolgeid;
                                else
                                        {
                                                characterData_So.dodgeId = maxDlolgeid;
                                        }
                                     }

              
        }

        }
    }
}
