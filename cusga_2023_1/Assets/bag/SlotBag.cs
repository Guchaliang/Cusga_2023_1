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
        BagMangaer.UpdateItemText(slotItem.itemText);
    }
}
