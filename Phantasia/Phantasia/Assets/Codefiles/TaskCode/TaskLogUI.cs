using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskLogUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TaskScrollingList taskScrollingList;
    [SerializeField] private Toggle doneToggle;
    [SerializeField] private TMP_InputField taskTitle;
    [SerializeField] private TMP_InputField taskTime;
    [SerializeField] private TMP_InputField taskDescription;

    private Button firstSelectedButton;

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
        //add button to scrolling list if not already added
        TaskButton taskButton = taskScrollingList.CreateButtonIfNotExists(task, () =>
        {
            SetTaskLogInfo(task);
        });
        // initialize the first selected button if not already so that it's always the top button
        if (firstSelectedButton == null)
        {
            firstSelectedButton = taskButton.button;
            firstSelectedButton.Select();

        }
    }
    private void SetTaskLogInfo(TaskObject task)
    {
        //set the contents of the task into
        taskTitle.text = task.title;
        taskTitle.readOnly = true;
        taskDescription.text = task.getDescription();

        if (task.state == TaskState.COMPLETED || task.state == TaskState.CLAIMED)
        {
            doneToggle.isOn = true;
        }
        else
        {
            doneToggle.isOn = false;
        }

        if (!task.getIsUserTask())
        {
            taskTime.text = "Ara's special! <3";
            taskTime.readOnly = true;
            taskDescription.readOnly = true;
        }
        else
        {
            taskTime.text = task.getEstimateTimeAsString() + "Hours";
        }
    }
}
