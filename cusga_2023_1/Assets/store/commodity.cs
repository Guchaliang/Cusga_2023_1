using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "commodity", menuName = "commodityManage")]

public class commodity : ScriptableObject
{
    public string commodityName;
    public int commodityID;
    public float commodityprice;//售出价格
    public float commoditycost;//购买价格
    public Sprite commodityImage;
    [TextArea]
    public string commodityText;
}
