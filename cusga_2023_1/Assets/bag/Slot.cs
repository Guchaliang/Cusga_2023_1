using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Itemm slotItem;
    public Image slotImage;
    [TextArea]
    public Text slotText;

    public void ItemOnClick()
    {
       UIManager.Instance.GetUI<BagUI>("BagUI").UpdateItemText(slotItem.itemText);
    }
}
