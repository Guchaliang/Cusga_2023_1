using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0011 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isroll;//�Ƿ񷭹�
    public CharacterData_So characterData_So;
    public float addHealth;//�ظ�Ѫ����ֵ
    public float addDolgeid;//������ȴ����
    public float maxDlolgeid;//������ȴ���ֵ
    public BagList myBag;
    public int x;
    public int y;//����ֻ��������
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
