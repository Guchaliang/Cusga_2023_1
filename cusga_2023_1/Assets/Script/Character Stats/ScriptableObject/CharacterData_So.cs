using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data" )]
public class CharacterData_So : ScriptableObject
{
    [Header("Character Info")]
    public int maxHealth;//最大生命值

    public int currentHealth;//当前生命值

    public int maxDenfence;//最大护盾值

    public int currentDefence;//当前护盾值
}
