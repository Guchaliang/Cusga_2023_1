using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEnter;
    [TextArea(1,3)]public string[] lines;

    [SerializeField] private bool hasName;
    private void OnEnable()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    private void Update()
    {
        if (isEnter && Input.GetKeyUp(KeyCode.Space)&&!DialogueManager.Instance.dialogueBox.activeInHierarchy)
        {
            StartCoroutine(DialogueManager.Instance.ShowDialogue(lines,hasName));
        }
    }
    
    //TODO 文件初始化文本
    private void InitLines(int times)
    {
        
    }
}
