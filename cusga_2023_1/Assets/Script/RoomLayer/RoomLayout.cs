using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RoomLayout")]
public class RoomLayout : ScriptableObject
{
    public List<Vector2> enemyGeneratePoints;
    public List<Vector2> itemGeneratePoints;
}
