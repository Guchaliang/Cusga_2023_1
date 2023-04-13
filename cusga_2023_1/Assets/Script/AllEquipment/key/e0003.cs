using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0003 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float changerate_defence = 0.05f;
    public float maxrate = 0.6f;
    // Update is called once per frame
    public void f0003()
    {
        
            if (changerate_defence + templeteData.defencedropRate <= maxrate) templeteData.defencedropRate += changerate_defence;
            else
                templeteData.defencedropRate = maxrate;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0003();

        }
    }
}

