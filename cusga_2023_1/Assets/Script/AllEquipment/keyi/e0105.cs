using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0105 : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterData_So CharacterData_So;
    public float thisHealth;//记录拾取装备时的生命值-1

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(thisHealth);
        thisHealth = CharacterData_So.currentHealth-1;
            
        CharacterData_So.currentHealth = 1;
        CharacterData_So.currentDefence += thisHealth;
         }
    }
}
