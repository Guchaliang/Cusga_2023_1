using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    //移动相关
    private Rigidbody2D rb;
    public bool canMove;
    
    //动画相关
    private Animator anim;
    [HideInInspector]public bool isDead;
    [HideInInspector]public bool isGetHit;

    [SerializeField] private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    
    void FixedUpdate()
    {
        if (canMove)
        {
            MoveMent();
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

        if (Input.GetAxis("Horizontal") > 0f)
            transform.localScale = new Vector3(1, 1, 1);
        else if(Input.GetAxis("Horizontal") < 0f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void SwithAnim()
    {
        anim.SetFloat("Speed",rb.velocity.sqrMagnitude);
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
