using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class TaskButton : MonoBehaviour, ISelectHandler
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI titletext;
    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private Toggle taskcompletetoggle;
    public Button button {get; private set;}
    private UnityAction onSelectAction;
    private TaskObject designatedTask = null;

    private void OnEnable()
    {
        EventsManager.instance.taskEvents.onTaskStateChanged += TaskStateChanged;
    }

    private void OnDisable()
    {
        EventsManager.instance.taskEvents.onTaskStateChanged -= TaskStateChanged;
    }

    private void TaskStateChanged(TaskObject task)
    {
        if(designatedTask == task)
        {
            taskcompletetoggle.isOn = checkState(task);
        }
    }

    public void ToggleValueChanged()
    {
        if (designatedTask == null)
        {
            Debug.LogWarning("Current task is empty");
            return;
        }

        if (taskcompletetoggle.isOn)
        {
            designatedTask.completetask();
            EventsManager.instance.taskEvents.TaskCompleted(designatedTask.title);
            EventsManager.instance.taskEvents.TaskStateChanged(designatedTask);
            Debug.Log("taskbutton log: " + designatedTask + "is now " + designatedTask.state);
        }
        else
        {
            designatedTask.uncompletetask();
            EventsManager.instance.taskEvents.TaskUncompleted(designatedTask.title);
            EventsManager.instance.taskEvents.TaskStateChanged(designatedTask);
            Debug.Log("taskbutton log: " + designatedTask + "is now " + designatedTask.state);
        }
    }

    //since this may be diabled when we instanciate it, we would need to manually instantiate everything
    public void UserInitialize(TaskObject task, UnityAction selectAction)
    {
        designatedTask = task;
        taskcompletetoggle.isOn = checkState(task);
        this.button = this.GetComponent<Button>();
        this.titletext.text = task.title;
        this.timetext.text = task.getEstimateTimeAsString() + "Hours";
        this.onSelectAction = selectAction;
    }

    public void SystemInitialize(TaskObject task, UnityAction selectAction)
    {
        designatedTask = task;
        taskcompletetoggle.isOn = checkState(task);
        this.button = this.GetComponent<Button>();
        this.titletext.text = task.title;
        this.timetext.text = "Ara's special! <3";
        this.onSelectAction = selectAction;
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelectAction();
    }

    private bool checkState(TaskObject task)
    {
        if (task.state == TaskState.COMPLETED || task.state == TaskState.CLAIMED)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
