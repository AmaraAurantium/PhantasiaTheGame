using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("EventsManager");
                _instance = go.AddComponent<EventsManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private static EventsManager _instance = null;

    public DialogueEvents dialogueEvents;
    public AraInteraction araInteraction;
    public TaskEvents taskEvents;
    public CoinEvents coinEvents;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
            Debug.LogWarning("Found more than one Events Manager in the scene.");
            return;
        }
        _instance = this;

        //initialize all events
        dialogueEvents = new DialogueEvents();
        taskEvents = new TaskEvents();
        coinEvents = new CoinEvents();
}

}
