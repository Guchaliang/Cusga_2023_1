using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
{
    public enum Direction { up,down,left,right};//ö��
    public Direction direction;
    [Header("������Ϣ")]
    public GameObject roomPrefab_main; 
    public GameObject roomPrefab;
    public int roomNumber;//��������
    public Color startColor, endColor;
    private GameObject endRoom;

    [Header("λ�ÿ���")]
    public Transform generatorPoint;
    public float xOffset;//����λ��
    public float yOffset;
    public LayerMask roomLayer; //ͼ��
    public int maxStep;
    public List<Room> rooms = new List<Room>(); //List�洢����
  
    List<GameObject> farRooms = new List<GameObject>();//��Զ�ķ���
    List<GameObject> lessFarRooms=new List<GameObject>();//����Զ�Ľ�һ��ķ���
    List<GameObject>oneWayRooms=new List<GameObject>();//������ڷ���

    void Start()
    {
        
        for (int i = 0; i < roomNumber; i++)
        {
            if (i == 0) { rooms.Add(Instantiate(roomPrefab_main, generatorPoint.position, Quaternion.identity).GetComponent<Room>()); }
            else { rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>()); }//����roomNumber������add��List

            //�ı�Point λ��
            ChangePos();

        }
        endRoom = rooms[0].gameObject;

        //�ҵ���󷿼�
        foreach(var room in rooms)
        {
            //if (room.transform.position.sqrmagnitude > endroom.transform.position.sqrmagnitude)
            //{
            //    endroom = room.gameobject;//ѭ���жϵ�ǰ�����Ƿ������ʼ������Զ��
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
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);//��������������л�����
        //}
    }
    public void ChangePos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

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
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);

        newRoom.UpdateRoom(xOffset,yOffset);
    }
    public void FindEndRoom()
    {//�����Զ�����С
        for(int i = 0; i < rooms.Count; i++)
        {
            if(rooms[i].stepToStart>maxStep)
                maxStep = rooms[i].stepToStart;
        }
        //����Զ���䣬��Զ�������
        foreach(var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            if(room.stepToStart == maxStep-1)
                lessFarRooms.Add(room.gameObject);
            
        }
        Debug.Log(farRooms.Count);
        Debug.Log(lessFarRooms.Count);
        //�ж����޵����ŷ���
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
        Debug.Log(oneWayRooms.Count);
        //����Զ����Ϊ������
        if(oneWayRooms.Count != 0)
        {
            endRoom=oneWayRooms[Random.Range(0,oneWayRooms.Count)];
        }
        //û����Զ����Ϊ�����ţ�����Զ���������һ��
        else
        {
            endRoom=farRooms[Random.Range(0,farRooms.Count)];
        }

    }
}
