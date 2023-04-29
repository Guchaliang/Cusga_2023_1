using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class PlayerTest : MonoBehaviour
{
    //移动相关
    private Rigidbody2D rb;
    public Vector2 moveDirection;
    public bool canAct;
    public CharacterInfo playerInfo;
    
    //子弹相关
    private Vector2 atkDirection;
    public GameObject bullet;
    private float timer;
    
    //技能相关
    public float skillSpeed;
    private float skilltimer;

    //动画相关
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [HideInInspector] public bool isAttacked;
    [HideInInspector] public bool isSkilled;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isGetHit;

    //原始尺寸
    public Vector3 initScale;

    
    [SerializeField] 
    public float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initScale = GetComponent<Transform>().localScale;
        canAct = true;
    }

    
    void Update()
    {
        if (canAct)
        {
            if (!isSkilled)
            {
                MoveMent();
                if (!isAttacked)
                    MoveFlipTo();
                SwitchAttackAnim();
                SkillAnim();
            }
        }
        
        SwithAnim();
    }

    public void MoveMent()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
        
        if (moveDirection.magnitude > 1f)
            moveDirection = moveDirection.normalized;
        rb.velocity = moveDirection * ( 0.5f + 0.5f * moveSpeed )* 1.7f;
    }

    public void MoveFlipTo()
    {
        if (moveDirection.x > 0f)
            transform.localScale = new Vector3(1, 1, 1);
        else if(moveDirection .x< 0f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    internal void VelocitySetZero()
    {
        rb.velocity = Vector2.zero;
    }

    private void SwithAnim()
    {
        anim.SetFloat("Speed",rb.velocity.sqrMagnitude);
    }

    public void Attack()
    {
        PlayerBullet obj = PoolManager.Release(bullet, this.transform.position).GetComponent<PlayerBullet>();
        obj.SetAwakePos(this.transform.position);
        obj.damage = playerInfo.damage;
        obj.SetDirection(atkDirection);
        obj.SetSpeed(5);
    }

    public void EndAtkH()
    {
        isAttacked = false;
    }

    public void SetSpeed(float value) 
    {
        moveSpeed = value;
    }

    public void SkillAnim()
    {
        if (skilltimer != 0)
        {
            skilltimer -= Time.deltaTime;
            if (skilltimer <= 0f)
                skilltimer = 0f;
        }

        if (skilltimer == 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetTrigger("Skill");
                isSkilled = true;
                skilltimer = playerInfo.skillCollDown;
                rb.velocity = moveDirection * skillSpeed;
            }
        }
    }

    public void EndSkill()
    {
        isSkilled = false;
    }

    public void PlayerGetHit()
    {
        UIManager.Instance.BiggerAndReturn(this.gameObject, initScale);
        IEnumerator hit = HitColor();
        StartCoroutine(hit);
        CameraControll.Instance.CallShake();
    }

    IEnumerator HitColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
    public void SwitchAttackAnim()
    {
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
                timer = 0;
        }

        if (timer == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                atkDirection = Vector2.up;
                anim.SetTrigger("AttackUp");
                timer = playerInfo.coolDown;
                isAttacked = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                atkDirection = Vector2.down;
                anim.SetTrigger("AttackDown");
                timer = playerInfo.coolDown;
                isAttacked = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                atkDirection = Vector2.left;
                anim.SetTrigger("AttackH");
                timer = playerInfo.coolDown;
                isAttacked = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
                atkDirection = Vector2.right;
                anim.SetTrigger("AttackH");
                timer = playerInfo.coolDown;
                isAttacked = true;
            }
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
