using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "commodity", menuName = "commodityManage")]

public class commodity : ScriptableObject
{
    public string commodityName;
    public int commodityID;
    public float commodityprice;//�۳��۸�
    public float commoditycost;//����۸�
    public Sprite commodityImage;
    [TextArea]
    public string commodityText;
}
