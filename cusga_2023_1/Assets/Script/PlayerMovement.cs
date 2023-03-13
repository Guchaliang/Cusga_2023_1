using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;//速度
    public float inertia;//惯性参数
    public float addSpeed;//速度增加参数
    public float maxSpeed;//最大速度
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private float inputX, inputY;
    private float stopX, stopY;
    Vector2 oldInput; 

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        if(input.magnitude!=0)
        {
            oldInput = input;
        }
        if (input.magnitude!=0)
            if (speed <= maxSpeed)
            {
                speed += addSpeed*Time.deltaTime;
                rigidbody.velocity = input * speed;
            }
            else
                rigidbody.velocity = input * maxSpeed;
        else
            if (speed >= 0)
        {
            Debug.Log(oldInput);
            speed -= (1/inertia)*10*Time.deltaTime;
            rigidbody.velocity = oldInput * speed;
        }
            if(speed < 0)
        {
            speed = 0;
            rigidbody.velocity = oldInput * speed;
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
