using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data" )]
public class CharacterData_So : ScriptableObject
{
    [Header("Character Info")]
    public float maxHealth;//最大生命值

    public float currentHealth;

    public float defence;
    
    public void ResetInfo(float def)
    {
        currentHealth = maxHealth;
        defence = def;
    }
}
