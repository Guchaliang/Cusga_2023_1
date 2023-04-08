using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "store", menuName = "storeData")]
public class storeData : ScriptableObject
{
    public List<commodity> commodityList = new List<commodity>();

}
