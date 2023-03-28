using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data" )]
public class CharacterData_So : ScriptableObject
{
    [Header("Character Info")]
    public float maxHealth;//最大生命值

    public float currentHealth;//当前生命值

    public float Defence;//基础防御

    public float currentDefence;//当前防御

    public float dashSpeed;//冲刺速度

    public float dashLength;//冲刺距离

    public float maxSpeed;//最大移动速度

    public float addSpeed;//起动加速度

    public float delSpeed;//减速加速度

    public float dodgeId ;//位移cd

    public float dodgelength;//位移距离

    
}
