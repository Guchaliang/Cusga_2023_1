using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e0005 : MonoBehaviour
{
    public CharacterData_So templeteData;
    public float dashLengthchange;
    public float dashLengthchangeMax;
    public void f0005()
    {
        if (templeteData.dashLength < dashLengthchangeMax - dashLengthchange)
            templeteData.dashLength += dashLengthchange;
        else
            templeteData.dashLength = dashLengthchangeMax;
        Debug.Log(templeteData.dodgeId);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            f0005();

        }
    }
}
