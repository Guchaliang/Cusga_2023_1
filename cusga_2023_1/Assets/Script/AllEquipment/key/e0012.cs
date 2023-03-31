using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0012 : MonoBehaviour
{
    public CharacterData_So templeteData;//绑定boss
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (templeteData.currentHealth <= 0)//击杀敌人用的是敌人血量低于0，后期再调
            {
                templeteData.boss_award += 1;
            }
        }
    }
}

