using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "NPCTalkContant/Data")]
public class NPCTalkContant : ScriptableObject
{
    [TextArea(1,3)]public string[] _contant;
}
