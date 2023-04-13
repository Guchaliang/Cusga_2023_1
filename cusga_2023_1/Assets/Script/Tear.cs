using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    int dirCount = 1;
    public float movespeed = 10f;

    public GameObject tearBoomPrefab;
    public float t = 0.5f;

    public GameObject mnyD_obj;
    public float attValue = 20;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        dirCount = PlayerTest2.dirCount;
        Invoke("Death", t);
        Destroy(gameObject, t);


        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //1,2,分别对应的是右,左
        switch (dirCount)
        {
            //case 1:
            //    transform.Translate(Vector3.down * movespeed * Time.deltaTime);
            //    break;
            //case 2:
            //    transform.Translate(Vector3.up * movespeed * Time.deltaTime);
            //    break;
            case 1:
                transform.Translate(Vector3.right * movespeed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.left * movespeed * Time.deltaTime);
                break;
            
            default:
                break;
        }
        
    }

    //这是碰撞的方式，不是Trigger的方式
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.tag == "enemy")
        //{
        //    Death();
            
        //}

        if(collision.collider.tag == "wall")
        {
            Death();
        }

        if (collision.collider.tag == "block")
        {
            Death();
        }

        if (collision.collider.tag == "block_sui")
        {
            Death();
            collision.collider.GetComponent<Block_Sui>().hp -= 10f;
            if(collision.collider.GetComponent<Block_Sui>().hp <= 0)
            {
                Destroy(collision.collider.gameObject);
                player.SendMessage("OpenZhanShen");
            }
        }
    }

    void Death()
    {
        Instantiate(tearBoomPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    //这是Trigger方式，不是碰撞方式
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bat")
        {
            Death();
            collision.GetComponentInChildren<EnemyBat>().hp -= attValue;
            if (collision.GetComponentInChildren<EnemyBat>().hp < 0)
            {
                Debug.Log("attack bat 0");
                collision.GetComponent<BoxCollider2D>().enabled = false;
                //Destroy(collision.gameObject);
                collision.transform.GetComponent<Animator>().Play("batDeath");
                PlayerTest2.killMonster++;
                Debug.Log("杀掉的怪物数目:" + PlayerTest2.killMonster);
            }

            //如果是蝙蝠的话
            //if (collision.name == "bat")
            //{
                
                
            //}

            

            //Destroy(collision.gameObject);
            //Destroy(gameObject);

        }

        //如果是蝙蝠的话
        if (collision.tag == "munaiyi")
        {
            Debug.Log("attack mummy");
            collision.GetComponentInChildren<EnemyMuNaiYi>().hp -= attValue;
            if (collision.GetComponentInChildren<EnemyMuNaiYi>().hp < 0)
            {
                Debug.Log("attack mumy 0");

                Instantiate(mnyD_obj, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
                PlayerTest2.killMonster++;
                //collision.transform.GetComponent<Animator>().Play("MuNaiYiDeath");
                Debug.Log("杀掉的怪物数目:" + PlayerTest2.killMonster);
            }
        }
    }*/
}
