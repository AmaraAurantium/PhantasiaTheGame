using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind (Story story)
    {
        story.BindExternalFunction("ClaimCompleted" , () => ClaimCompleted());
    }

    public void unBind(Story story)
    {
        story.UnbindExternalFunction("ClaimCompleted");
    }

    private void ClaimCompleted()
    {
        EventsManager.instance.taskEvents.ClaimRewards();
    }
}
