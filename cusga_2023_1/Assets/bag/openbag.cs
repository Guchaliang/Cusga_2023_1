using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openbag : MonoBehaviour
{
    bool isOpenb;
    bool isOpens;
    void Update()
    {
        OpenBag();
        Openstore();
    }

    void OpenBag()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            UIManager.Instance.ShowUI<BagUI>("BagUI");
            Time.timeScale = 0;
        }
    }
    void Openstore()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {

        }
    }
}
