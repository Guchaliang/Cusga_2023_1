using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0006 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float changerate_health = 0.05f;
    public float maxrate = 0.6f;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (templeteData.currentHealth <= 0)//击杀敌人用的是敌人血量低于0，后期再调
            {
                if (changerate_health + templeteData.healthdropRate <= maxrate) templeteData.healthdropRate += changerate_health;
                else
                    templeteData.healthdropRate = maxrate;
            }

        }
    }
}

