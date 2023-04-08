using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0005 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dashLengthchange;
    public float dashLengthchangeMax;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (templeteData.dashLength < dashLengthchangeMax-dashLengthchange)
                templeteData.dashLength += dashLengthchange;
            else
                templeteData.dashLength = dashLengthchangeMax;
            Debug.Log(templeteData.dodgeId);

        }
    }
}
