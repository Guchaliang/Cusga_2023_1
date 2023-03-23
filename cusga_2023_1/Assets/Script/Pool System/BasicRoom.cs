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

    public int activeDoorNum
    {
        get { return neighboringRooms.Count; }
    }

    [Header("房间组成")] 
    public List<GameObject> doorList;//启用的门列表
    public Dictionary<Direction, BasicRoom> neighboringRooms = new Dictionary<Direction, BasicRoom>();
    public PolyNavMap map;
    
    //将对应方向的房间门显示
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
    public void SetDoorActive(bool active)
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
        if (this.roomType == RoomType.Initial)
        {
            this.isCleared = true;
        }
        else if (this.roomType == RoomType.Enemy||this.roomType == RoomType.Boss)
        {
            
        }
        else if (this.roomType == RoomType.Award)
        {
            this.isCleared = true;
        }
        else if (this.roomType == RoomType.Store)
        {
            this.isCleared = true;
        }
    }

    public void GenerateInit()
    {
        
    }
}