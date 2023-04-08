using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New item",menuName ="equipment data/New item")]
public class Itemm : ScriptableObject
{
    public string itemName;
    public int itemID;
    public Sprite itemImage;
    [TextArea]
    public string itemText;
}
