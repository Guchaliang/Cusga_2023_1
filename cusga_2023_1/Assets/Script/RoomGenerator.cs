using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{
   //public enum Stone1 { stone1,stone2, stone3,stone4 };//枚举石头
    public Direction direction;
    //public Stone1 stone;
    [Header("房间信息")]
    public GameObject roomPrefab_main; 
    public GameObject roomPrefab;
    //public GameObject stonePrefab;
    public int roomNumber;//房间数量
   // public int stone_NumberMax;//每个房间石头数量最大值
   // public int stone_Number;//房间石头数量
    public Color startColor, endColor;
    private GameObject endRoom;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;//房间位移
    public float yOffset;
    public LayerMask roomLayer; //图层
    public int maxStep;
    public List<Room> rooms = new List<Room>(); //List存储房间
    //public List<Stone> stones = new List<Stone>();
    List<GameObject> farRooms = new List<GameObject>();//最远的房间
    List<GameObject> lessFarRooms=new List<GameObject>();//比最远的近一点的房间
    List<GameObject>oneWayRooms=new List<GameObject>();//单独入口房间

    void Start()
    {
        
        for (int i = 0; i < roomNumber; i++)
        { /*stone_Number = Random.Range(0, stone_NumberMax);//随机确定石头数量*/
            if (i == 0) 
            {
                rooms.Add(Instantiate(roomPrefab_main, generatorPoint.position, Quaternion.identity).GetComponent<Room>());
                rooms[0].name = "Room0";
            }
            else
            {
                rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());
                rooms[i].name = "Room" + i;
                //for ( int j = 0; j<stone_Number; j++) {
                //stones.Add(Instantiate(stonePrefab, generatorPoint.position, Quaternion.identity).GetComponent<Stone>()); }
            }//生成roomNumber个房间add进List,加入stone列表

            //改变Point 位置
            ChangePos();

        }
        endRoom = rooms[0].gameObject;

        //找到最后房间
        foreach(var room in rooms)
        {
            //if (room.transform.position.sqrmagnitude > endroom.transform.position.sqrmagnitude)
            //{
            //    endroom = room.gameobject;//循环判断当前房间是否是离初始房间最远的
            //}
            SetupRoom(room,room.transform.position);
        }
        FindEndRoom();
        endRoom.GetComponent<SpriteRenderer>().color = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.anyKeyDown)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);//按下任意键可以切换场景
        //}
    }
    public void ChangePos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);
            //stone=(Stone1)Random.Range(0, 4);//4种随机选一种
            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
            }
        }while(Physics2D.OverlapCircle(generatorPoint.position,0.2f,roomLayer));
    }
    public void SetupRoom(Room newRoom,Vector3 roomPosition)
    {
        //bool j;
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);
       //for(int x = 0; x < 4; x++) { 
       // int i=Random.Range(0, 2);
       // if (i == 0) j = false; else j = true;
       // newRoom.stone_1 = j;
       // }
        newRoom.UpdateRoom(xOffset,yOffset);
    }
    public void FindEndRoom()
    {//获得最远房间大小
        for(int i = 0; i < rooms.Count; i++)
        {
            if(rooms[i].stepToStart>maxStep)
                maxStep = rooms[i].stepToStart;
        }
        //将最远房间，次远房间加入
        foreach(var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            if(room.stepToStart == maxStep-1)
                lessFarRooms.Add(room.gameObject);
            
        }
        //Debug.Log(farRooms.Count);
        //Debug.Log(lessFarRooms.Count);
        //判断有无单项门房间
        for(int i = 0;i<farRooms.Count;i++)
        {
            if(farRooms[i].GetComponent<Room>().doorNumber==1)
                oneWayRooms.Add(farRooms[i]);
        }
        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if (lessFarRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(lessFarRooms[i]);
        }
        //Debug.Log(oneWayRooms.Count);
        //有最远房间为单向门
        if(oneWayRooms.Count != 0)
        {
            endRoom=oneWayRooms[Random.Range(0,oneWayRooms.Count)];
        }
        //没有最远房间为单向门，在最远房间中随机一个
        else
        {
            endRoom=farRooms[Random.Range(0,farRooms.Count)];
        }

    }
}
