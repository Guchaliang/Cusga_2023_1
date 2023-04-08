using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField] private bool isEnter;
    private NPCTalkContant theContant;

    [SerializeField] private bool hasName;

    private void OnEnable()
    {
        InitLines();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    private void Update()
    {
        if (isEnter && Input.GetKeyUp(KeyCode.Space)&&!DialogueManager.Instance.dialogueBox.activeInHierarchy&&DialogueManager.Instance.canTalk)
        {
            StartCoroutine(DialogueManager.Instance.ShowDialogue(theContant._contant,hasName));
        }
    }
    
    //TODO 文件初始化文本
    private void InitLines()
    {
        string path = "Dialogue/NPC" + DialogueManager.Instance.talkTimes.ToString();
        theContant = Instantiate(Resources.Load(path)) as NPCTalkContant;
    }
}
