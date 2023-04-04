using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PolyNav;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomManager : Singleton<RoomManager>
{
    public BasicRoom[,] roomArray;//所有房间的二维数组
    public int roomNum;
    
    [Header("房间属性")]
    public GameObject roomPrefab;//房间种类
    public Vector2 offset;//房间的x y大小
    
    [HideInInspector]
    public BasicRoom currentRoom;
    [HideInInspector]
    public PlayerTest player;
    
    //房间生成点位管理
    public Dictionary<RoomType, List<RoomLayout>> layoutsMap = new Dictionary<RoomType, List<RoomLayout>>();
    [SerializeField]
    private List<RoomLayout> enemyRoomLayouts;
    [SerializeField]
    private List<RoomLayout> storeRoomLayouts;


    protected override void Awake()
    {
        base.Awake();
        roomArray = new BasicRoom[roomNum * 2, roomNum * 2];
        
        layoutsMap.Add(RoomType.Enemy,enemyRoomLayouts);
        layoutsMap.Add(RoomType.Store,storeRoomLayouts);
    }

    private void Start()
    {
        this.player = GameManager.Instance.player;
        CreateRooms();
    }
    
    public BasicRoom CreateRoom(Vector2 Pos)
    {
        BasicRoom newRoom = PoolManager.Release(roomPrefab, new Vector2(((int) Pos.x - roomArray.GetLength(0) / 2) * offset.x,
            ((int) Pos.y - roomArray.GetLength(1) / 2) * offset.y),Quaternion.identity).GetComponent<BasicRoom>();
        newRoom.coordinate = Pos;
        newRoom.map.GenerateMap();
        
        return newRoom;
    }

    public void CreateRooms()
    {
        List<BasicRoom> singleDoorRoomList = new List<BasicRoom>();//只有一个门的房间列表
        List<Vector2> alternativeRoomList = new List<Vector2>();//试探创建房间坐标列表
        List<Vector2> removedRoomList = new List<Vector2>();//被舍去的房间坐标列表

        while (singleDoorRoomList.Count < 3)
        {
            //清空数据
            Array.Clear(roomArray,0,roomArray.Length);
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            singleDoorRoomList.Clear();
            alternativeRoomList.Clear();
            removedRoomList.Clear();
            
            //创建起始房间
            BasicRoom lastRoom = roomArray[roomArray.GetLength(0) / 2, roomArray.GetLength(1) / 2] =
                CreateRoom(new Vector2(roomArray.GetLength(0)/2,roomArray.GetLength(1)/2));
            currentRoom = lastRoom;
            
            //创建其他房间
            //Lambda表达式构建临时函数
            Action<int, int> NextRoom = (newX, newY) =>
            {
                if (0<=newX&&newX< roomArray.GetLength(0)&&0<=newY&&newY<roomArray.GetLength(1))
                {
                    Vector2 coordinate = new Vector2(newX, newY);
                    if (!roomArray[newX, newY])
                    {
                        if (alternativeRoomList.Contains(coordinate))
                        {
                            alternativeRoomList.Remove(coordinate);
                            removedRoomList.Add(coordinate);
                        }
                        else if (!removedRoomList.Contains(coordinate))
                        {
                            alternativeRoomList.Add(coordinate);
                        }
                    }
                }
            };

            for (int i = 1; i < roomNum; i++)
            {
                NextRoom((int)lastRoom.coordinate.x+1, (int)lastRoom.coordinate.y);
                NextRoom((int)lastRoom.coordinate.x-1, (int)lastRoom.coordinate.y);
                NextRoom((int)lastRoom.coordinate.x, (int)lastRoom.coordinate.y+1);
                NextRoom((int)lastRoom.coordinate.x, (int)lastRoom.coordinate.y-1);

                Vector2 newRoomCoordinate = alternativeRoomList[Random.Range(0, alternativeRoomList.Count)];
                lastRoom = roomArray[(int) newRoomCoordinate.x, (int)newRoomCoordinate.y] = CreateRoom(newRoomCoordinate);
                alternativeRoomList.Remove(newRoomCoordinate);
            }
            
            //将房间与房间之间的门启用
            DoorActive();

            foreach (BasicRoom room in roomArray)
            {
                if (room && room.activeDoorNum == 1 && room != currentRoom)
                {
                    singleDoorRoomList.Add(room);
                }
            }
            
            SetRoomType(singleDoorRoomList);
            
            FindObjectOfType<MiniMap>().CreateMiniMap();
            
            foreach (BasicRoom room in roomArray)
            {
                if (room )
                {
                    room.CheckActiveDoor(false);
                }
            }
        }

        StartCoroutine(MoveToRoom(Vector2.zero));
    }
    

    //将游戏物体门启用
    public void DoorActive()
    {
        foreach (BasicRoom room in roomArray)
        {
            if (room)
            {
                int x = (int)room.coordinate.x; 
                int y = (int)room.coordinate.y;
                if (x+1<roomArray.GetLength(0)&&roomArray[x + 1, y])
                {
                    room.SetDoorActive(Direction.right,roomArray[x+1,y]);
                }
                if (x-1>=0&&roomArray[x - 1, y])
                {
                    room.SetDoorActive(Direction.left,roomArray[x-1,y]);
                }
                if (y+1<roomArray.GetLength(1)&&roomArray[x , y + 1])
                {
                    room.SetDoorActive(Direction.up,roomArray[x,y+1]);
                }
                if (y-1>=0&&roomArray[x , y - 1])
                {
                    room.SetDoorActive(Direction.down,roomArray[x,y-1]);
                }
            }
        }
    }

    public void MoveToNextRoom(Vector2 moveDirection)
    {
        if (currentRoom.isCleared)
        {
            StartCoroutine(MoveToRoom(moveDirection));
        }
    }

    IEnumerator MoveToRoom(Vector2 moveDirection)
    {
        currentRoom = roomArray[(int)(currentRoom.coordinate.x + moveDirection.x), (int)(currentRoom.coordinate.y + moveDirection.y)];
        
        //假如没有到达过这个房间，将这个房间生成对应的东西
        if (!currentRoom.isArrived)
        {
            currentRoom.GenerateInitContent();
            currentRoom.isArrived = true;
        }

        //更新小地图
        FindObjectOfType<MiniMap>().UpdateMiniMap(moveDirection);
        
        player.canAct = false;
        player.transform.position += (Vector3)moveDirection*3;
        
        //移动摄像机
        float time = 0;
        Vector3 targetPos = currentRoom.transform.position;
        targetPos.z = -10;
        while (time <= 0.3f)
        {
            GameManager.Instance.myCamera.transform.position = Vector3.Lerp(GameManager.Instance.myCamera.transform.position, targetPos, (1 / 0.3f) * (time += Time.deltaTime));
            yield return null;
        }

        player.canAct = true;
        yield return null;
    }

    public void SetRoomType(List<BasicRoom> singleDoorRoom)
    {
        foreach (BasicRoom room in roomArray)
        {
            if (room)
                room.roomType = RoomType.Enemy;
        }
        
        //初始房间设置
        currentRoom.roomType = RoomType.Initial;
        
        //设置Boss房，奖励房，商店房
        //奖励房
        for (int i = 0; i < singleDoorRoom.Count-2; i++)
        {
            singleDoorRoom[i].roomType = RoomType.Award;
        }
        
        //Boss房
        singleDoorRoom[singleDoorRoom.Count - 1].roomType = RoomType.Boss;

        //商店房
        singleDoorRoom[singleDoorRoom.Count - 2].roomType = RoomType.Store;
        
        //初始化
        foreach (BasicRoom room in roomArray)
        {
            if(room)
                room.Initialize();
        }
    }

    public RoomLayout GetTheRoomLayout(RoomType type)
    {
        if (layoutsMap.ContainsKey(type)&&layoutsMap[type].Count!=0)
        {
            return layoutsMap[type][Random.Range(0, layoutsMap[type].Count - 1)];
        }
        else
        {
            return null;
        }
    }

    public PolyNavMap GetMap()
    {
        return currentRoom.GetComponentInChildren<PolyNavMap>();
    }
}
