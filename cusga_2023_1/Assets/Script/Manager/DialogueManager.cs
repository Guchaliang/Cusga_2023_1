using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dialogueBox;
    public Text dialogueText, nameText;
    [HideInInspector]public bool canTalk = true;
    
    [HideInInspector]public int talkTimes;

    [TextArea(1, 3)] public string[] dialogueLines;
    [SerializeField] private int currentLines;

    private bool isScrolling;
    [SerializeField] private float textSpeed;
    
    private void Start()
    {
        dialogueText.text = dialogueLines[currentLines];
    }

    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isScrolling)
                {
                    currentLines++;
                    if (currentLines < dialogueLines.Length)
                    {
                        CheckName();
                        StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        GameManager.Instance.player.canAct = true;
                        dialogueBox.SetActive(false);
                        StartCoroutine(SetNextTimeCanActive());
                    }
                }
            }
        }
    }

    public IEnumerator ShowDialogue(string[] _newLines,bool _hasName)
    {
        dialogueLines = _newLines;
        currentLines = 0;
        CheckName();

        GameManager.Instance.player.canAct = false;
        GameManager.Instance.player.VelocitySetZero();
        
        yield return null;
        StartCoroutine(ScrollingText());
        canTalk = false;
        dialogueBox.SetActive(true);
        
        nameText.gameObject.SetActive(_hasName);
    }

    IEnumerator SetNextTimeCanActive()
    {
        yield return new WaitForSeconds(0.5f);
        canTalk = true;
    }

    public void CheckName()
    {
        if (dialogueLines[currentLines].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLines].Replace("n-","");   
            currentLines++;
        }
    }

    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";

        foreach (char letter in dialogueLines[currentLines].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isScrolling = false;
    }
}
