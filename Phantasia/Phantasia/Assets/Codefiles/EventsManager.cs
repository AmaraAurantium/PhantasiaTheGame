using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance { get; private set; }

    public DialogueEvents dialogueEvents;
    public AraInteraction araInteraction;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Events Manager in the scene.");
        }
        instance = this;

        //initialize all events
        araInteraction = new AraInteraction();
        dialogueEvents = new DialogueEvents();
    }

}
