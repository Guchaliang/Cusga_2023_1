using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest2 : MonoBehaviour
{
    public float movespeed = 6f;
    //角色移动速度
    public GameObject[] objs;
    int count = 1;
    public GameObject tearPrefab;

    public static int dirCount = 1;

    public float hp = 100f;
    public float maxHp = 100f;

    //public GameObject[] hpSprs;
    //public Text uiShow;

    public Camera cam;
    bool toDoor1;
    bool toDoor4;

    public Transform[] playerRoomsPos;
    public Transform[] rooms;
    public float camMoveSpeed = 6f;
    bool f2to1 = false;
    bool f1to2 = false;
    bool f2to3 = false;
    bool f3to2 = false;
    bool f3to4 = false;
    bool f4to3 = false;
    bool f4to5 = false;
    bool f5to4 = false;
    bool f5to6 = false;
    bool f6to5 = false;
    bool f4to7 = false;
    bool f7to4 = false;
    bool f7to8 = false;
    bool f8to7 = false;
    bool f7to9 = false;
    bool f9to7 = false;

    public static int killMonster = 0;
    bool f1to2First;

    public int room1MonsterNum = 2;
    public GameObject  room2Door;

    //room2
    public int room2MonsterNum = 4;
    public GameObject dadishen;
    public GameObject tiankongshen;

    //room3
    public GameObject zhanzhengshen;
    public GameObject sishen;

    //状态机
    Animator ani;

    //攻击CD
    //bool isAtt;
    //float attTime = 0;
    //public float attTimeCD = 0.2f; 

    //精灵
    SpriteRenderer spriteRenderer;

    //UI，计数器
    public Text killTxt;
    //血条
    public Image hpIma;

    // Start is called before the first frame update
    void Start()
    {
        //FaceTurnAround(count);
        count = 1;
        dirCount = 1;
        //objs[0].SetActive(true);
        //objs[1].SetActive(false);
        //objs[2].SetActive(false);
        //objs[3].SetActive(false);

        //uiShow.text = "map1";

        ani = transform.GetComponent<Animator>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();

        //room2
        dadishen.SetActive(false);
        tiankongshen.SetActive(false);

        //room3
        zhanzhengshen.SetActive(false);
        sishen.SetActive(false);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movespeed;
        float v = Input.GetAxisRaw("Vertical") * Time.deltaTime * movespeed;

        transform.Translate(h,v,0);

        //必须用绝对值，才能有左右两种都可以变化的动作切换
        ani.SetFloat("moveSpeed",Mathf.Abs(h));
        ani.SetFloat("moveSpeed2", Mathf.Abs(v));
        //如果采用的下面的代码，只有右边可以有动作切换
        //ani.SetFloat("moveSpeed",h);
        // ani.SetFloat("moveSpeed", v);

        if (h > 0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (h < -0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            count = 2;
            
            //objs[0].SetActive(false);
            //objs[1].SetActive(true);
            //objs[2].SetActive(false);
            //objs[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            count = 1;
            //objs[0].SetActive(true);
            //objs[1].SetActive(false);
            //objs[2].SetActive(false);
            //objs[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            count = 3;
            //objs[0].SetActive(false);
            //objs[1].SetActive(false);
            //objs[2].SetActive(true);
            //objs[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            count = 4;
            //objs[0].SetActive(false);
            //objs[1].SetActive(false);
            //objs[2].SetActive(false);
            //objs[3].SetActive(true);
        }

        

        //射击
        Shoot();

        //去第一个门,即map2
        //ToDoor1();
        //回到第一个场景,即map1
        //ToDoor4();

        //
        f1to2_F();
        f2to1_F();
        f2to3_F();
        f3to2_F();
        f3to4_F();
        f4to3_F();
        f4to5_F();
        f5to4_F();
        f5to6_F();
        f6to5_F();
        f4to7_F();
        f7to4_F();
        f7to8_F();
        f8to7_F();
        f7to9_F();
        f9to7_F();

    }

    private void FixedUpdate()
    {
        CheckDoorState();
        CheckKillNum();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            hp -= 10;
            //  hp / maxHp;
            //hpSprs[1].transform.localScale = new Vector3(50* hp/maxHp,5,1);

            if(hp<=0)
            {
                //hpSprs[1].transform.localScale = new Vector3(0, 5, 1);
            }
        }
    }

    void ToDoor1()
    {
        if(toDoor1)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(cam.transform.position.x, 12, cam.transform.position.z),Time.deltaTime*2);

            if(Vector3.Distance(cam.transform.position, new Vector3(cam.transform.position.x, 12, cam.transform.position.z)) <0.1f)
            {
                cam.transform.position = new Vector3(0,12,-10);
                toDoor1 = false;
            }
        }
    }


    void ToDoor4()
    {
        if (toDoor4)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(cam.transform.position.x, 0, cam.transform.position.z), Time.deltaTime * 2);

            if (Vector3.Distance(cam.transform.position, new Vector3(cam.transform.position.x, 0, cam.transform.position.z)) < 0.1f)
            {
                cam.transform.position = new Vector3(0, 0, -10);
                toDoor4 = false;
            }
        }
    }

    

    //从1号房间走入2号房间
    void f1to2_F()
    {
        if (f1to2)
        {

            //人的位置进入第二个房间
            //transform.position = playerRoomsPos[1].position;
            Vector3 pos = new Vector3(rooms[1].position.x, rooms[1].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f1to2 = false;
            }

           
            
            
        }
    }

    void f2to1_F()
    {
        if (f2to1)
        {
            Vector3 pos = new Vector3(rooms[0].position.x, rooms[0].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f2to1 = false;
            }
        }
    }

    void f2to3_F()
    {
        if (f2to3)
        {
            Vector3 pos = new Vector3(rooms[2].position.x, rooms[2].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f2to3 = false;
            }
        }
    }

    void f3to2_F()
    {
        if (f3to2)
        {
            Vector3 pos = new Vector3(rooms[1].position.x, rooms[1].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f3to2 = false;
            }
        }
    }

    void f3to4_F()
    {
        if (f3to4)
        {
            Vector3 pos = new Vector3(rooms[3].position.x, rooms[3].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);

            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f3to4 = false;
            }
        }
    }

    void f4to3_F()
    {
        if (f4to3)
        {
            Vector3 pos = new Vector3(rooms[2].position.x, rooms[2].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f4to3 = false;
            }
        }
    }

    void f4to5_F()
    {
        if (f4to5)
        {
            Vector3 pos = new Vector3(rooms[4].position.x, rooms[4].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f4to5 = false;
            }
        }
    }

    void f5to4_F()
    {
        if (f5to4)
        {
            Vector3 pos = new Vector3(rooms[3].position.x, rooms[3].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f5to4 = false;
            }
        }
    }

    void f5to6_F()
    {
        if (f5to6)
        {
            Vector3 pos = new Vector3(rooms[5].position.x, rooms[5].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f5to6 = false;
            }
        }
    }

    void f6to5_F()
    {
        if (f6to5)
        {
            Vector3 pos = new Vector3(rooms[4].position.x, rooms[4].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f6to5 = false;
            }
        }
    }

    void f4to7_F()
    {
        if (f4to7)
        {
            Vector3 pos = new Vector3(rooms[6].position.x, rooms[6].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f4to7 = false;
            }
        }
    }

    void f7to4_F()
    {
        if (f7to4)
        {
            Vector3 pos = new Vector3(rooms[3].position.x, rooms[3].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f7to4 = false;
            }
        }
    }

    void f7to8_F()
    {
        if (f7to8)
        {
            Vector3 pos = new Vector3(rooms[7].position.x, rooms[7].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f7to8 = false;
            }
        }
    }

    void f8to7_F()
    {
        if (f8to7)
        {
            Vector3 pos = new Vector3(rooms[6].position.x, rooms[6].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f8to7 = false;
            }
        }
    }

    void f7to9_F()
    {
        if (f7to9)
        {
            Vector3 pos = new Vector3(rooms[8].position.x, rooms[8].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f7to9 = false;
            }
        }
    }

    void f9to7_F()
    {
        if (f9to7)
        {
            Vector3 pos = new Vector3(rooms[6].position.x, rooms[6].position.y, cam.transform.position.z);
            cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * camMoveSpeed);
            if (Vector3.Distance(cam.transform.position, pos) < 0.1f)
            {
                cam.transform.position = pos;
                f9to7 = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //去第二个房间
        //if (collision.name == "room2Door")
        //{
        //    Debug.Log("exit the room2Door");
        //    f1to2 = false;
        //}

        //去第一个房间(其实是从第二个房间回到第一个房间)
        //if (collision.name == "room1Door")
        //{
        //    Debug.Log("exit the room1Door");

        //    f2to1 = false;
        //    //transform.position = playerRoomsPos[0].position;
        //}
    }


    //Trigger触发
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //碰到门，触发
        if (collision.tag == "door")
        {
            Debug.Log("door");
        }

        if(collision.tag == "god")
        {
            if(collision.name == "dadishen")
            {
                Debug.Log("大地神");
                tearPrefab.GetComponent<Tear>().t = 0.8f;

            }

            if(collision.name == "zhanzhengshen")
            {
                Debug.Log("战争神");
                tearPrefab.GetComponent<Tear>().attValue = 100f;
            }

            if (collision.name == "kongqishen")
            {
                Debug.Log("空气神");
                movespeed = 4f;
            }
        }

        //碰到怪物之木乃伊
        //if(collision.tag == "munaiyiAtt")
        //{
        //    Debug.Log("munaiyi Att");
        //    hp -= 20;

        //    if(hp<0)
        //    {
        //        Death();
        //    }
        //}

        //去第二个房间
        if (collision.name == "room2Door")
        {
            Debug.Log("enter the room2");
            //toDoor1 = true;
            //toDoor4 = false;

            

            f1to2 = true;
            f2to1 = false;

            //uiShow.text = "map2";
            transform.position = playerRoomsPos[1].position;
            
        }

        //去第一个房间(其实是从第二个房间回到第一个房间)
        if (collision.name == "room1Door")
        {
            Debug.Log("enter the room1");
            f1to2 = false;
            f2to1 = true;
            transform.position = playerRoomsPos[0].position;
        }

        //从第二个房间来，去第三个房间
        if (collision.name == "room3Door")
        {
            Debug.Log("enter the room3");
            f3to2 = false;
            f2to3 = true;
            transform.position = playerRoomsPos[2].position;
        }

        //从3到2
        if (collision.name == "room2Door2")
        {
            Debug.Log("enter the room2");
            f3to2 = true;
            f2to3 = false;
            transform.position = playerRoomsPos[3].position;
        }

        //room4Door,3到4
        if (collision.name == "room4Door")
        {
            Debug.Log("enter the room4");
            f3to4 = true;
            f4to3 = false;
            transform.position = playerRoomsPos[4].position;
        }

        //4到3
        if (collision.name == "room3Door2")
        {
            Debug.Log("enter the room3");
            f3to4 = false;
            f4to3 = true;
            transform.position = playerRoomsPos[5].position;
        }

        //4到5
        if (collision.name == "room5Door")
        {
            Debug.Log("enter the room5");
            f4to5 = true;
            f5to4 = false;
            transform.position = playerRoomsPos[6].position;
        }

        //5到4
        if (collision.name == "room4Door2")
        {
            Debug.Log("enter the room4");
            f5to4 = true;
            f4to5 = false;
            transform.position = playerRoomsPos[7].position;
        }

        //5to6,room6Door
        if (collision.name == "room6Door")
        {
            Debug.Log("enter the room6");
            f5to6 = true;
            f6to5 = false;
            transform.position = playerRoomsPos[8].position;
        }

        //6to5,room5Door2
        if (collision.name == "room5Door2")
        {
            Debug.Log("enter the room5");
            f6to5 = true;
            f5to6 = false;
            transform.position = playerRoomsPos[9].position;
        }

        //4to7,room7Door
        if (collision.name == "room7Door")
        {
            Debug.Log("enter the room7");
            f4to7 = true;
            f7to4 = false;
            transform.position = playerRoomsPos[10].position;
        }

        //7to4,room4Door3
        if (collision.name == "room4Door3")
        {
            Debug.Log("enter the room4");
            f7to4 = true;
            f4to7 = false;
            transform.position = playerRoomsPos[11].position;
        }

        //7to8,room8Door
        if (collision.name == "room8Door")
        {
            Debug.Log("enter the room8");
            f7to8 = true;
            f8to7 = false;
            transform.position = playerRoomsPos[12].position;
        }

        //8to7,room7Door2
        if (collision.name == "room7Door2")
        {
            Debug.Log("enter the room7");
            f8to7 = true;
            f7to8 = false;
            transform.position = playerRoomsPos[13].position;
        }

        //7to9,room9Door
        if (collision.name == "room9Door")
        {
            Debug.Log("enter the room9");
            f7to9 = true;
            f9to7 = false;
            transform.position = playerRoomsPos[14].position;
        }

        //9to7,room7Door3
        if (collision.name == "room7Door3")
        {
            Debug.Log("enter the room7");
            f9to7 = true;
            f7to9 = false;
            transform.position = playerRoomsPos[15].position;
        }
    }

    IEnumerator AttackCD()
    {
        ani.SetBool("attack", true);
        dirCount = 1;
        GameObject tear = Instantiate(tearPrefab, objs[0].transform.position, transform.rotation);
        //tear.transform.SetParent(objs[0].transform);
        transform.GetComponent<SpriteRenderer>().flipX = false;
        tear.GetComponent<SpriteRenderer>().flipX = false;

        yield return new WaitForSeconds(0.2f);

        ani.SetBool("attack", false);
    }

    IEnumerator AttackCD2()
    {
        ani.SetBool("attack", true);
        dirCount = 2;
        GameObject tear = Instantiate(tearPrefab, objs[1].transform.position, transform.rotation);
        //tear.transform.SetParent(objs[1].transform);
        transform.GetComponent<SpriteRenderer>().flipX = true;
        tear.GetComponent<SpriteRenderer>().flipX = true;

        yield return new WaitForSeconds(0.2f);

        ani.SetBool("attack", false);
    }

    void Shoot()
    {
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //Debug.Log("down");
        //GameObject tear = Instantiate(tearPrefab, objs[0].transform.position, transform.rotation);
        //dirCount = 1;

        //count = 1;

        //objs[0].SetActive(true);
        //objs[1].SetActive(false);
        //objs[2].SetActive(false);
        //objs[3].SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //Debug.Log("up");
        //GameObject tear = Instantiate(tearPrefab, objs[1].transform.position, transform.rotation);
        //dirCount = 2;

        //count = 2;
        //objs[0].SetActive(false);
        //objs[1].SetActive(true);
        //objs[2].SetActive(false);
        //objs[3].SetActive(false);
        //}

        //Input.GetKeyDown(KeyCode.LeftArrow)  || 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            //ani.SetBool("attack", true);
            //dirCount = 1;
            //GameObject tear = Instantiate(tearPrefab, objs[0].transform.position, transform.rotation);
            ////tear.transform.SetParent(objs[0].transform);
            //transform.GetComponent<SpriteRenderer>().flipX = false;
            //tear.GetComponent<SpriteRenderer>().flipX = false;

            StartCoroutine("AttackCD");

        }
        //Input.GetKeyUp(KeyCode.LeftArrow) || 
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //ani.SetBool("attack", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //ani.SetBool("attack", true);
            //dirCount = 2;
            //GameObject tear = Instantiate(tearPrefab, objs[1].transform.position, transform.rotation);
            ////tear.transform.SetParent(objs[1].transform);
            //transform.GetComponent<SpriteRenderer>().flipX = true;
            //tear.GetComponent<SpriteRenderer>().flipX = true;

            StartCoroutine("AttackCD2");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //ani.SetBool("attack", false);
        }
    }


    void CheckKillNum()
    {
        killTxt.text = "Kill:"+killMonster.ToString();
    }

    void CheckDoorState()
    {
        if (killMonster >= room1MonsterNum)
        {
            //用最规范的写法
            room2Door.GetComponent<BoxCollider2D>().isTrigger = true;
            room2Door.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (killMonster >= room2MonsterNum)
        {
            dadishen.SetActive(true);
            tiankongshen.SetActive(true);
        }
    }

    public void OpenZhanShen()
    {
        zhanzhengshen.SetActive(true);
        sishen.SetActive(true);
    }

}
