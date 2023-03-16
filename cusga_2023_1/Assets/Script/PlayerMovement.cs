using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;//速度
    public float maxSpeed;//最大速度
    new private Rigidbody2D rigidbody;
    private Animator animator;
    public float inputX, inputY;
    private float stopX, stopY;
    public  Vector2 oldvec;//老输入
    public  float olddrag,newdrag;
    void Start()
    {
        Application.targetFrameRate = 60;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        speed = rigidbody.velocity.magnitude;//得到当前速度
        if (input!=Vector2.zero)//如果这一帧有输入
         {
         rigidbody.drag = olddrag;//改变阻力
         if (speed <= maxSpeed)//速度小于最大速度一直加到最大
            rigidbody.AddForce(new Vector2(inputX*3,inputY*3));
        }
        else
        {
            rigidbody.drag = newdrag;
        }

        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);

    }
    
}
