using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Dialogue;
using _Game.Scripts.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Popup dialogueBox;
    public Dialogue dialogueConfig;
    public TextMeshProUGUI text;
    public TextMeshProUGUI nextText;

    private int currentTextPos = 0;
    private bool hasNext => dialogueConfig.dialogues.Count > currentTextPos || text.textInfo.pageCount > text.pageToDisplay;
    public void Awake()
    {
        dialogueBox.OnShowComplete.AddListener(delegate
        {
            KeyboardInput.Instance.BlockInteractions();
            currentTextPos = 0;
            NextText();    
        });
        
        dialogueBox.OnHideComplete.AddListener(delegate
        {
            KeyboardInput.Instance.ReleaseInteractions();
        });
    }

    public void Show()
    {
        ZUIManager.Instance.OpenPopup(dialogueBox);
    }

    public void Next()
    {
        ChangePage();
                
        if(!hasNext)
            CloseDialogue();
    }

    private void NextText()
    {
        text.SetText(dialogueConfig.dialogues[currentTextPos].message);
        text.pageToDisplay = 1;
        
        currentTextPos++;
        nextText.gameObject.SetActive(hasNext);
    }

    private void ChangePage()
    {
        if (text.textInfo.pageCount <= text.pageToDisplay)
        {
            NextText();
            return;
        }

        text.pageToDisplay++;
        nextText.gameObject.SetActive(hasNext);
    }
    

    public void CloseDialogue()
    {
        ZUIManager.Instance.ClosePopup(dialogueBox);
    }
}
