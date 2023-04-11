using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBag : MonoBehaviour
{
    public Itemm slotItem;
    public Image slotImage;
    [TextArea]
    public Text slotText;

    public void ItemOnClick1()
    {
        UIManager.Instance.GetUI<BagUI>("BagUI").UpdateItemText(slotItem.itemText);
        UIManager.Instance.GetUI<BagUI>("BagUI").UpdateCurItem(slotItem);
    }
}
