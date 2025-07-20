using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Awake()
    {
        contentParent.SetActive(false);
        // starting with clear panel
        ResetPanel();
    }

    private void OnEnable()
    {
        EventsManager.instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        EventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        EventsManager.instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        EventsManager.instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        EventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        EventsManager.instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);
        // reset everthing for next use
        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine)
    {
        dialogueText.text = dialogueLine;
    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
