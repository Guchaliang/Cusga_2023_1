using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PolyNav;
using UnityEngine;

public enum Direction
{
    up,down,left,right
};//枚举

public enum RoomType
{
    Initial,Enemy,Boss,Award,Store,Hide
}

public class BasicRoom : MonoBehaviour
{
    [Header("房间属性")] 
    public bool isArrived;//玩家是否抵达
    public bool isCleared;//玩家是否清理空怪物
    public RoomType roomType;//当前房间的类型
    public Vector2 coordinate;//坐标
    [HideInInspector]public int EnemyNum = 0;
    private RoomLayout roomLayout;
    

    public int activeDoorNum
    {
        get { return neighboringRooms.Count; }
    }

    [Header("房间组成")] 
    public List<GameObject> doorList;//启用的门列表
    public Dictionary<Direction, BasicRoom> neighboringRooms = new Dictionary<Direction, BasicRoom>();
    public PolyNavMap map;
    
    //将对应方向的房间门启用
    public void SetDoorActive(Direction direction,BasicRoom neighbor)
    {
        GameObject door = doorList[(int) direction];

        for (int i = 0; i < door.transform.childCount; i++)
        {
            door.transform.GetChild(i).gameObject.SetActive(true);
        }
        
        neighboringRooms.Add(direction,neighbor);
    }
    
    //设置已激活的门
    public void CheckActiveDoor(bool active)
    {
        foreach(Direction direction in neighboringRooms.Keys)
        {
            this.doorList[(int)direction].transform.GetChild(1).gameObject.SetActive(active);
            this.doorList[(int) direction].GetComponent<BoxCollider2D>().enabled = active;
        }
    }

    //初始化设置文件
    public void Initialize()
    {
        this.roomLayout = RoomManager.Instance.GetTheRoomLayout(roomType);
        
    }

    public void GenerateInitContent()
    {
        if (roomLayout)
        {
            Vector2 myCoordinate = (Vector2) RoomManager.Instance.currentRoom.transform.localPosition;
            for (int i = 0; i < roomLayout.enemyGeneratePoints.Count; i++)
            {
                Vector2 temp = myCoordinate + roomLayout.enemyGeneratePoints[i];
                GameObject obj = PoolManager.Release(GameManager.Instance.GetEenmyRandomly(), temp);
                if(obj.GetComponent<EnemyFSM>())
                    obj.GetComponent<EnemyFSM>().awakePos = temp;
                else if (obj.GetComponent<EnemyFSM_Bat>())
                    obj.GetComponent<EnemyFSM_Bat>().awakePos = temp;
                obj.GetComponent<PolyNavAgent>().map = RoomManager.Instance.GetMap();
                EnemyNum++;
            }
        }
        else
        {
            EnemyNum = 0;
            isCleared = true;
        }
    }
}