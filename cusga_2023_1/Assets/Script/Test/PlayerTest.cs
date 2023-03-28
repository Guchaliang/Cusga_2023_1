using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerTest : MonoBehaviour
{
    //移动相关
    private Rigidbody2D rb;
    public bool canAct;
    
    //动画相关
    private Animator anim;
    [HideInInspector] public bool isAttacked;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isGetHit;

    [SerializeField] private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canAct = true;
    }

    
    void FixedUpdate()
    {
        if (canAct)
        {
            MoveMent();
            if (!isAttacked)
            {
                MoveFlipTo();
                SwitchAttackAnim();
            }
        }
        
        SwithAnim();
    }

    public void MoveMent()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
        
        if (direction.magnitude > 1)
            direction = direction.normalized;
        rb.velocity = direction * ( 0.5f + 0.5f * moveSpeed )* 1.7f;
    }

    public void MoveFlipTo()
    {
        if (Input.GetAxis("Horizontal") > 0f)
            transform.localScale = new Vector3(1, 1, 1);
        else if(Input.GetAxis("Horizontal") < 0f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void SwithAnim()
    {
        anim.SetFloat("Speed",rb.velocity.sqrMagnitude);
        anim.SetBool("AttackH",isAttacked);
    }

    public void Attack(Vector2 direction)
    {
        
    }

    public void TestAtk()
    {
        isAttacked = false;
    }

    public void SwitchAttackAnim()
    {
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
        }
        else */if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isAttacked = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            isAttacked = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Patrol"))
        {
            if (other.gameObject.name == "Up")
            {
                RoomManager.Instance.MoveToNextRoom(Vector2.up);
            }
            else if(other.gameObject.name == "Down")
            {
                RoomManager.Instance.MoveToNextRoom(Vector2.down);
            }
            else if(other.gameObject.name == "Left")
            {
                RoomManager.Instance.MoveToNextRoom(Vector2.left);
            }
            else if(other.gameObject.name == "Right")
            {
                RoomManager.Instance.MoveToNextRoom(Vector2.right);
            }
        }
    }
}
