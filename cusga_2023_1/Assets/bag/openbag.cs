using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbag : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        OpenBag();
    }

    void OpenBag()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            isOpen = myBag.activeSelf;
            isOpen=!isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
