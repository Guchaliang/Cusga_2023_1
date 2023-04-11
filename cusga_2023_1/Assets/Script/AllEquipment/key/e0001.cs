using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0001 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dodgeIdchange;
    
    public void f0001()
    {
        if (templeteData.dodgeId > dodgeIdchange)
            templeteData.dodgeId -= dodgeIdchange;
        else
            templeteData.dodgeId = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            f0001();
            
        }
    }
}
