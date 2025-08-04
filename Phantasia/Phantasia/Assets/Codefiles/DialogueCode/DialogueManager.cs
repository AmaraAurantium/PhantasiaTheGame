using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink Story")]
    [SerializeField] private TextAsset inkJson;
    private Story story;
    private int currentChoiceIndex = -1;

    private bool dialoguePlaying = false;

    private InkExternalFunctions inkExternalFunctions;
    private InkDialogueVariables inkDialogueVariables;

    private void Awake()
    {
        story = new Story(inkJson.text);
        inkExternalFunctions = new InkExternalFunctions();
        inkExternalFunctions.Bind(story);
        inkDialogueVariables = new InkDialogueVariables(story);
    }

    private void OnDestroy()
    {
        inkExternalFunctions.unBind(story);
    }

    private void OnEnable()
    {
        if (EventsManager.instance == null) return;
        EventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        EventsManager.instance.araInteraction.onScreenClicked += SubmitPressed;
        EventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        EventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable += UpdateInkDialogueVariable;
        EventsManager.instance.coinEvents.onGameStateChange += gameStateChange;


    }

    private void OnDisable()
    {
        EventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        EventsManager.instance.araInteraction.onScreenClicked -= SubmitPressed;
        EventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        EventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable -= UpdateInkDialogueVariable;
        EventsManager.instance.coinEvents.onGameStateChange -= gameStateChange;
    }

    private void gameStateChange(GameState state)
    {
        EventsManager.instance.dialogueEvents.UpdateInkDialogueVariable(
           "GameState",
           new StringValue(state.ToString())
       );
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        inkDialogueVariables.UpdateVariableState(name, value);
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

        // start listening for variables
        inkDialogueVariables.SyncVariablesAndStartListening(story);

        // kick off the story
        ContinueOrExitStory();
        return true;
    }

    private void ContinueOrExitStory()
    {
        //make a choice if applicable
        if(story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            //reset choice index for next time
            currentChoiceIndex = -1;
        }
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            //handle the case where there's an empty line of dialogue
            //by continuing until we get a line with content
            while(IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            //handle the case where that last line of dialogue is blank
            //empty choice, external function, etc...)
            if(IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                EventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
            }
        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        //Debug.Log("Exiting Dialogue");

        dialoguePlaying = false;

        EventsManager.instance.dialogueEvents.DialogueFinished();

        // stop listening for dialogue variables
        inkDialogueVariables.StopListening(story);

        //reset story state
        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
}
