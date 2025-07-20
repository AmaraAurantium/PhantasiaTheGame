using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueEvents
{
    public event Func<string, bool> onEnterDialogue;

    public bool EnterDialogue(string knotName)
    {
        if (onEnterDialogue != null)
        {
            return onEnterDialogue(knotName);
        }
        return false;
    }

    public event Action onDialogueStarted;
    public void DialogueStarted()
    {
        if(onDialogueStarted != null)
        {
            onDialogueStarted();
        }
    }

    public event Action onDialogueFinished;
    public void DialogueFinished()
    {
        if (onDialogueFinished != null)
        {
            onDialogueFinished();
        }
    }

    public event Action<string> onDisplayDialogue;
    public void DisplayDialogue(string dialogueLine)
    {
        if (onDisplayDialogue != null)
        {
            onDisplayDialogue(dialogueLine);
        }
    }
}
