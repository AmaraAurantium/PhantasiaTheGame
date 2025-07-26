using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private Dictionary<string, TaskObject> taskList;

    private void Awake()
    {
        taskList = CreateTaskList();
    }

    private void OnEnable()
    {
        EventsManager.instance.taskEvents.onTaskHidden += TaskHidden;
        EventsManager.instance.taskEvents.onTaskCompleted += TaskCompleted;
        EventsManager.instance.taskEvents.onTaskUncompleted += TaskUncompleted;
        EventsManager.instance.taskEvents.onTaskClaimed += TaskClaimed;
    }

    private void OnDisable()
    {
        EventsManager.instance.taskEvents.onTaskHidden -= TaskHidden;
        EventsManager.instance.taskEvents.onTaskCompleted -= TaskCompleted;
        EventsManager.instance.taskEvents.onTaskUncompleted -= TaskUncompleted;
        EventsManager.instance.taskEvents.onTaskClaimed -= TaskClaimed;
    }

    private void Start()
    {
        //broadcast the initial state of all tasks on startup
        foreach (TaskObject task in taskList.Values)
        {
            EventsManager.instance.taskEvents.TaskStateChanged(task);
        }
    }
    private void TaskHidden(string id)
    {
        Debug.Log("Hide task: " + id);
    }

    private void TaskCompleted(string id)
    {
        Debug.Log("Complete task: " + id);
    }

    private void TaskUncompleted(string id)
    {
        Debug.Log("Uncomplete task: " + id);
    }

    private void TaskClaimed(string id)
    {
        Debug.Log("Claim task: " + id);
    }

    private Dictionary<string, TaskObject> CreateTaskList()
    {
        //system task instantiation
        TaskObject[] systemtaskList = new TaskObject[]
        {
            new TaskObject("Stay Hydrated!", 0f, "Get a sip of water! (And if you want to, take a picture of your cup/mug/bottle and upload it on X under #aurantiYUM)", false),
            new TaskObject("Touch Grass :3", 0f, "I challenge you to find a pretty leaf! It has to be prettier than the two I got on my head! #aurantiYUM ", false),
            new TaskObject("Cloudy Day", 0f, "Imagine if you could bite into a cloud sized cotton-candy...YUMMMM...Have you seen a funny looking cloud lately? I wanna see! #aurantiYUM", false),
            new TaskObject("Mogu Mogu", 0f, "Good food always brightens up a bad day! Make sure to have a hearty meal today! #aurantiYUM", false),
            new TaskObject("Treasure?", 0f, "pstttt! I've heard that top shelves often contain rare treasures from the past! Check out your top shelf!", false),
            new TaskObject("Doodle /(._._)", 0f, "Hey! Can I ask you something? If it's alright with you, can you draw me real quick? I'll pose for you! #aurantiYUM", false)

        };

        //create the tasklist
        Dictionary<string, TaskObject> idToTaskList = new Dictionary<string, TaskObject>();
        foreach (TaskObject taskObject in systemtaskList)
        {
            idToTaskList.Add(taskObject.title, taskObject);
        }

        return idToTaskList;
    }

    private TaskObject GetTaskByID(string id)
    {
        TaskObject task = taskList[id];
        if (task == null)
        {
            Debug.LogError("ID not found in taskList: " + id);
        }
        return task;
    }
}
