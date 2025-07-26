using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class TaskButton : MonoBehaviour, ISelectHandler
{
    public Button button { get; private set; }
    private UnityAction onSelectAction;
    [SerializeField] private TextMeshProUGUI titletext;
    [SerializeField] private TextMeshProUGUI timetext;

    //since this may be diabled when we instanciate it, we would need to manually instantiate everything
    public void UserInitialize(string title, string time, UnityAction selectAction)
    {
        this.button = this.GetComponent<Button>();
        this.titletext.text = title;
        this.timetext.text = time + "Hours";
        this.onSelectAction = selectAction;
    }

    public void SystemInitialize(string title, string time, UnityAction selectAction)
    {
        this.button = this.GetComponent<Button>();
        this.titletext.text = title;
        this.timetext.text = "Ara's special! <3";
        this.onSelectAction = selectAction;
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelectAction();
    }
}
