using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotStore : MonoBehaviour
{
    public commodity slotItem;
    public Image slotImage;
    [TextArea]
    public Text slotText;

    public void ItemOnClick()
    {
        storemanager.UpdateItemText(slotItem.commodityText);
    }
}
