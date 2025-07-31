using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskScrollingList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [Header("Task Button Prefab")]
    [SerializeField] private GameObject taskButtonPrefab;

    private Dictionary<string, TaskButton> idToButtonMap = new Dictionary<string, TaskButton>();

    public void CleanTaskList()
    {
        foreach (var taskButtonInfo in idToButtonMap)
        {
            Destroy(taskButtonInfo.Value.gameObject);
        }

        idToButtonMap = new Dictionary<string, TaskButton>();
    }
    public TaskButton CreateButtonIfNotExists(TaskObject task, UnityAction selectAction)
    {
        TaskButton taskButton = null;
        //only create the button if we havent seen this id before
        if (!idToButtonMap.ContainsKey(task.title))
        {
            if(task.state == TaskState.PROGRESS || task.state == TaskState.COMPLETED)
            {
                taskButton = InstantiateTaskButton(task, selectAction);
            }
        }
        else
        {
            taskButton = idToButtonMap[task.title];
            taskButton.Refresh();
            taskButton.SetSelectAction(selectAction);
        }
        return taskButton;
    }

    private TaskButton InstantiateTaskButton(TaskObject task, UnityAction selectAction)
    {
        //create the button
        TaskButton taskButton = Instantiate(
            taskButtonPrefab,
            contentParent.transform).GetComponent<TaskButton>();
        //game object name in scene
        taskButton.gameObject.name = task.title + "_button";
        //initialize and set up function for when the button is selected
        if (task.getIsUserTask())
        {
            taskButton.UserInitialize(task, selectAction);
        }
        else
        {
            taskButton.SystemInitialize(task, selectAction);
        }
        idToButtonMap[task.title] = taskButton;
        return taskButton;
    }
}
