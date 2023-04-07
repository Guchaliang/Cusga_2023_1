using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commodityOnWorld : MonoBehaviour
{

    public commodity commodity;
    public storeData playStore;

    private void Start()
    {
        
        for (int i = 0; i < playStore.commodityList.Count; i++)
        {

            storemanager.CreateNewItem(playStore.commodityList[i]);
        }




    }
}
