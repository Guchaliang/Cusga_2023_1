using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
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
}
