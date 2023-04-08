using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MiniMap : UIBase
{
    public GameObject miniRoomPrefab;
    public Transform roomNode;
    
    private Vector2 offset = new Vector2(50, 50);
    
    private GameObject[,] miniMap;
    private Vector2 currentCoordinate;
    private GameObject currentRoom;
    private List<Vector2> hasBeenToList = new List<Vector2>();
    
    Color white = new Color(1f, 1f, 1f, 1);
    Color gray = new Color(0.6f, 0.6f, 0.6f, 1);
    Color black = new Color(0.3f, 0.3f, 0.3f, 1);


    public void CreateMiniMap()
    {
        if (miniMap != null){
            Array.Clear(miniMap,0,miniMap.Length);
        }

        miniMap = new GameObject[RoomManager.Instance.roomArray.GetLength(0), RoomManager.Instance.roomArray.GetLength(1)];
        
        foreach (var room in RoomManager.Instance.roomArray)
        {
            if (room)
            {
                var miniRoom = PoolManager.Release(miniRoomPrefab,transform.position);
                miniMap[(int) room.coordinate.x, (int) room.coordinate.y] = miniRoom;

                miniRoom.transform.localPosition = new Vector2((room.coordinate.x - miniMap.GetLength(0)/2)*offset.x,
                    (room.coordinate.y - miniMap.GetLength(1)/2)*offset.y);
                
                //特殊地图图标
                switch(room.roomType)
                { 
                    case RoomType.Boss:
                        break;
                    case RoomType.Award:
                        break;
                    case RoomType.Store:
                        break;
                    default:
                        break;
                }
            }
        }

        currentCoordinate = new Vector2(RoomManager.Instance.currentRoom.coordinate.x,
            RoomManager.Instance.currentRoom.coordinate.x);
        currentRoom = miniMap[(int) currentCoordinate.x, (int) currentCoordinate.x];
    }

    public void ResetTheMinimap()
    {
        
    }

    public void UpdateMiniMap(Vector2 moveDirection)
    {
        hasBeenToList.Add(currentCoordinate);
        
        currentRoom.GetComponent<Image>().color = gray;
        currentCoordinate.x += moveDirection.x;
        currentCoordinate.y += moveDirection.y;
        currentRoom = miniMap[(int)currentCoordinate.x, (int)currentCoordinate.y];
        currentRoom.GetComponent<Image>().color = white;

        List<Vector2> neighboringCoordinate = new List<Vector2>()
        {
            currentCoordinate + Vector2.right,currentCoordinate + Vector2.left,
            currentCoordinate + Vector2.down,currentCoordinate + Vector2.up
        };
        
        foreach (var coordinate in neighboringCoordinate)
        {
            GameObject miniRoom = miniMap[(int)coordinate.x, (int)coordinate.y];
            if (miniRoom  && !hasBeenToList.Contains(coordinate))
            {
                miniRoom.GetComponent<Image>().color = black;
            }
        }
        
        roomNode.transform.localPosition -= new Vector3(moveDirection.x * offset.x, moveDirection.y * offset.y, 0);
    }
}
