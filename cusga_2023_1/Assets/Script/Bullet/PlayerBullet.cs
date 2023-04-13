using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private Vector2 awakePos;
    public float distance;

    private void FixedUpdate()
    {
        if(this.gameObject.activeSelf)
            GetActiveDistance();
    }

    public void SetAwakePos(Vector2 Pos)
    {
        awakePos = Pos;
    }

    public void GetActiveDistance()
    {
        if (((Vector2)this.transform.position -  awakePos).magnitude >= distance)
            this.gameObject.SetActive(false);
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyOrBoss"))
        {
            other.gameObject.GetComponent<CharacterInfo>().TakeDamage(1, other.gameObject.GetComponent<CharacterInfo>());
            other.gameObject.GetComponent<BossFSM_1>().GetHit(1);
            this.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Ground")||other.CompareTag("Patrol"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
