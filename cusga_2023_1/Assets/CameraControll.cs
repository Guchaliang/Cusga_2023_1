using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public  class CameraControll : Singleton<CameraControll>
{
    float shake = 5;
    float setShake;
    Vector3 originalPos;
    void Start()
    {
        setShake = 20;
        originalPos = gameObject.transform.position;
    }
    IEnumerator CameraShake()
    {
        while (shake >= 0.5f)
        {
            transform.position = new Vector3(
            UnityEngine.Random.Range(0f, shake * 2f) - shake + originalPos.x,
            UnityEngine.Random.Range(0f, shake * 1f) - shake + originalPos.y,
            originalPos.z);
            shake = shake / 1.05f;
            yield return null;
        }
        shake = 0;
        transform.position = originalPos;
        yield return null;
    }
    public  void CallShake()
    {
        shake = setShake;
        StartCoroutine(CameraShake());
    }
}
