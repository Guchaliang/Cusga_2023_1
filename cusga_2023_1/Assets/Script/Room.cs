using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Room : MonoBehaviour
{
    public enum Direction1 { up, down, left, right };//枚ju
    public Direction1 direction1;
    public float x;//石头位移
    public float y;
    public List<Stone> stones =new List<Stone>();
    public GameObject stonePrefab1, stonePrefab2, stonePrefab3, stonePrefab4;
    public int stone1_number, stone2_number, stone3_number, stone4_number;
    public Transform point;
    public GameObject doorLeft,doorRight,doorUp,doorDown;
    public bool roomLeft,roomRight,roomUp,roomDown;
    public Text text;
    public int stepToStart;
    public int doorNumber=0;
    public LayerMask stoneLayer; //图层
    public Transform parent1;
    public GameObject zuoshang,youxia;
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
        stone1_number = Random.Range(0, 3);
        stone2_number = Random.Range(0,3);
        stone3_number = Random.Range(0,3);
        stone4_number = Random.Range(0,3);
        for (int i=0;i<stone1_number;i++) 
        {
            stones.Add(Instantiate(stonePrefab1, point.position, Quaternion.identity).GetComponent<Stone>());
            ChangePos1();
            
        }
        
        for (int i = 0; i < stone2_number; i++)
        {
            stones.Add(Instantiate(stonePrefab2, point.position, Quaternion.identity).GetComponent<Stone>());
            ChangePos1();
        }
        
        for (int i = 0; i < stone3_number; i++)
        {
            stones.Add(Instantiate(stonePrefab3, point.position, Quaternion.identity).GetComponent<Stone>()); 
            ChangePos1();
        }
       
        for (int i = 0; i < stone4_number; i++)
        {
            stones.Add(Instantiate(stonePrefab4, point.position, Quaternion.identity).GetComponent<Stone>()); 
            ChangePos1();
        }
        for (int i = 0; i < stones.Count; i++)
        { stones[i].transform.SetParent(parent1);
           // stones[i].transform.localPosition = Vector3.zero;
           }
        
   
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
    public void ChangePos1()
    {
        do
        {
            direction1 = (Direction1)Random.Range(0, 4);
            //stone=(Stone1)Random.Range(0, 4);//4种随机选一种
            switch (direction1)
            {
                case Direction1.up:
                    point.position += new Vector3(0, y, 0);
                    
                    break;
                case Direction1.down:
                    point.position += new Vector3(0, -y, 0);
              
                    break;
                case Direction1.left:
                    point.position += new Vector3(-x, 0, 0);
                
                    break;
                case Direction1.right:
                    point.position += new Vector3(x, 0, 0);
                 
                    break;
            }
        } while (Physics2D.OverlapCircle(point.position,0.2f, stoneLayer));
    }
}
