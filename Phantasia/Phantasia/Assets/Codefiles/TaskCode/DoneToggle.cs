using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneToggle : MonoBehaviour
{
    private Toggle doneToggle;
    private TaskObject currentTask;
    private void Awake()
    {
        //get the toggle game object;
        doneToggle = GetComponent<Toggle>();

        //Add listener for when the state of the Toggle changes, to take action
        doneToggle.onValueChanged.AddListener((bool isOn) => {
            ToggleValueChanged(isOn);
        });
    }

    private void OnEnable()
    {
        EventsManager.instance.taskEvents.onPanelContentUpdate += PanelContentUpdate;
    }

    private void OnDisable()
    {
        EventsManager.instance.taskEvents.onPanelContentUpdate -= PanelContentUpdate;
    }

    private void PanelContentUpdate(TaskObject task)
    {
        currentTask = task;
        if (currentTask.state == TaskState.COMPLETED || currentTask.state == TaskState.CLAIMED)
        {
            doneToggle.isOn = true;
        }
        else
        {
            doneToggle.isOn = false;
        }
        
    }

    void ToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            if (currentTask == null)
            {
                Debug.LogWarning("Current task is empty");
            }
            else
            {
                currentTask.completetask();
                EventsManager.instance.taskEvents.TaskCompleted(currentTask.title);
                EventsManager.instance.taskEvents.TaskStateChanged(currentTask);
            }
        }
        else
        {
            if (currentTask == null)
            {
                Debug.LogWarning("Current task is empty");
            }
            else
            {
                EventsManager.instance.taskEvents.TaskUncompleted(currentTask.title);
                EventsManager.instance.taskEvents.TaskStateChanged(currentTask);
            }
        }
    }
}
