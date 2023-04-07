using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbag : MonoBehaviour
{
    public GameObject myBag;
    public GameObject mySore;
    bool isOpenb;
    bool isOpens;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        OpenBag();
        Openstore();
    }

    void OpenBag()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            isOpenb = myBag.activeSelf;
            isOpenb=!isOpenb;
            myBag.SetActive(isOpenb);
        }
    }
    void Openstore()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            isOpens = mySore.activeSelf;
            isOpens = !isOpens;
            mySore.SetActive(isOpens);
        }
    }
}
