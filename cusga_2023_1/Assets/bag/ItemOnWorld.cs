using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Itemm thisItem;
    public BagList playerBag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
    void AddNewItem()
    {
        playerBag.itemList.Add(thisItem);
        UIManager.Instance.GetUI<BagUI>("BagUI").CreateNewItem(thisItem);
    }

}
