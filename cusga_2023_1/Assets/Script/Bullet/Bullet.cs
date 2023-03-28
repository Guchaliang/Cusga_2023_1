using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private Vector2 direction;
    public float damage;

    private Animator animator;

    

    private void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.Play("Bullet");
    }

    public void SetDirection(Vector2 direct)
    {
        this.direction = direct;
    }

    public void SetSpeed(float sp)
    {
        rb.velocity = direction * speed;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterInfo>()
                .TakeDamage(damage, other.gameObject.GetComponent<CharacterInfo>());
            Debug.Log(other.gameObject.GetComponent<CharacterInfo>().Defence);
            Debug.Log(other.gameObject.GetComponent<CharacterInfo>().CurrentHealth);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }

}
