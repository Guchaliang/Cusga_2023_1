using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
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

    public void SetSpeed(Vector2 direction)
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
