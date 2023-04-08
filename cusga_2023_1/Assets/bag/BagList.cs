using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mybag",menuName ="BagData/Mybag")]
public class BagList     : ScriptableObject
{
    public List<Itemm> itemList= new List<Itemm>();
    
}
