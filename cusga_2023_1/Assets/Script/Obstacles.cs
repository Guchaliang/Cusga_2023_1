using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<PolygonCollider2D> obstacles;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            obstacles.Add(transform.GetComponentInChildren<PolygonCollider2D>());
        }
    }

    public bool GetPosInCollider(Vector2 Pos)
    {
        foreach (PolygonCollider2D obstacle in obstacles)
        {
            if (obstacle.bounds.Contains(Pos))
                return true;
        }

        return false;
    }
}
