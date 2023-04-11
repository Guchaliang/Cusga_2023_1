using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0006 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float changerate_health = 0.05f;
    public float maxrate = 0.6f;
    // Update is called once per frame
    public void f0006()
    {
        if (changerate_health + templeteData.healthdropRate <= maxrate) templeteData.healthdropRate += changerate_health;
        else
            templeteData.healthdropRate = maxrate;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0006();
        }
    }
}

