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

    public float dodgeId ;//冲刺cd

    public float dodgelength;//位移距离

    public float defencedropRate;//护盾掉落率

    public float healthdropRate;//血包掉落率

    public int room_award=1;//是否进入新房间

    public int boss_award = 2;//boss掉落装备数量

    public int protect=0;//护盾值
}
