using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;
    private Story story;

    private bool dialoguePlaying = false;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void Start()
    {
        if (EventsManager.instance == null) return;
        EventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        EventsManager.instance.araInteraction.onScreenClicked += SubmitPressed;


    }

    private void Destroy()
    {
        EventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        EventsManager.instance.araInteraction.onScreenClicked -= SubmitPressed;

    }

    private void SubmitPressed()
    {
        // if dialogue isn't playing, we never want to reister input here
        if (!dialoguePlaying)
        {
            return;
        }

        ContinueOrExitStory();
    }

    private bool EnterDialogue(string knotname)
    {
        if (dialoguePlaying)
        {
            return false;
        }

        dialoguePlaying = true;

        //inform other parts of out system that we've started dialogue
        EventsManager.instance.dialogueEvents.DialogueStarted();

        if (!knotname.Equals(""))
        {
            story.ChoosePathString(knotname);
        }
        else
        {
            Debug.LogWarning("Knot name was empty string when entering dialogue");
        }

        ContinueOrExitStory();
        return true;
    }

    private void ContinueOrExitStory()
    {
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();
            //print to console for now
            Debug.Log(dialogueLine);
            EventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine);
        }
        else
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        //Debug.Log("Exiting Dialogue");

        dialoguePlaying = false;

        //reset story state
        story.ResetState();
    }

}
