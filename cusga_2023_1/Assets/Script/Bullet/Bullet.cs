using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    [HideInInspector]public float damage;

    private Animator animator;
    
    private void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
        if(GetComponent<Animator>())
            animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(animator)
            animator.Play("Bullet");
    }

    public void SetDirection(Vector2 direct)
    {
        this.direction = direct;
        if (this.direction == Vector2.left)
            transform.rotation = new Quaternion(0, 0, 180, 0);
        else if(this.direction == Vector2.right)
            transform.rotation= Quaternion.identity;
        else if (this.direction == Vector2.up)
            transform.rotation = new Quaternion(0, 0, 90, 0);
        else if (this.direction == Vector2.down)
            transform.rotation = new Quaternion(0, 0, -90, 0);
    }

    public void SetSpeed(float sp)
    {
        rb.velocity = direction * sp;
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterInfo>()
                .TakeDamage(damage, other.gameObject.GetComponent<CharacterInfo>());
            //设置受击
            this.gameObject.SetActive(false);
        }else if (other.CompareTag("Ground")||other.CompareTag("Patrol"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
