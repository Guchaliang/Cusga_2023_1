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
            if (Input.GetKeyUp(KeyCode.Space))
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
                        dialogueBox.SetActive(false);
                        //TODO 人物可以移动
                    }
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[currentLines];
                    isScrolling = false;
                }
            }
        }
    }

    public IEnumerator ShowDialogue(string[] _newLines,bool _hasName)
    {
        dialogueLines = _newLines;
        currentLines = 0;
        CheckName();

        //TODO 人物禁止移动
        yield return null;
        StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);
        
        nameText.gameObject.SetActive(_hasName);
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
