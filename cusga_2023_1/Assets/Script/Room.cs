using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room : MonoBehaviour
{
    public GameObject doorLeft,doorRight,doorUp,doorDown;
    public bool roomLeft,roomRight,roomUp,roomDown;
    public Text text;
    public int stepToStart;
    public int doorNumber=0;
    void Start()
    {
        /*doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);*/
       
    }

    // Update is called once per frame
    public void UpdateRoom(float xoffset,float yoffset)
    {    
        stepToStart =(int)(Mathf.Abs(transform.position.x /xoffset ) + Mathf.Abs(transform.position.y / yoffset));
        text.text = stepToStart.ToString();
        if (roomUp)
            doorNumber++;
        if(roomDown)
            doorNumber++;
        if(roomLeft)
            doorNumber++;
        if (roomLeft)
            doorNumber++;
    }
}
