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

    /*temp testing code
    private SaveData data;

    private void Awake()
    {
        data = SaveSystem.load();
    }
    private void Start()
    {
        ArrayList taskList = new ArrayList()
        {
            new TaskObject("Stay Hydrated!", 0f, "Get a sip of water! (And if you want to, take a picture of your cup/mug/bottle and upload it on X under #aurantiYUM)", false),
            new TaskObject("Touch Grass :3", 0f, "I challenge you to find a pretty leaf! It has to be prettier than the two I got on my head! #aurantiYUM ", false),
            new TaskObject("Cloudy Day", 0f, "Imagine if you could bite into a cloud sized cotton-candy...YUMMMM...Have you seen a funny looking cloud lately? I wanna see! #aurantiYUM", false),
            new TaskObject("Mogu Mogu", 0f, "Good food always brightens up a bad day! Make sure to have a hearty meal today! #aurantiYUM", false),
            new TaskObject("Treasure?", 0f, "pstttt! I've heard that top shelves often contain rare treasures from the past! Check out your top shelf!", false),
            new TaskObject("Doodle /(._._)", 0f, "Hey! Can I ask you something? If it's alright with you, can you draw me real quick? I'll pose for you! #aurantiYUM", false)
        };

        for (int i = 0; i<taskList.Count; i++)
        {
            TaskObject task = (TaskObject)taskList[i];
            TaskButton taskButton = CreateButtonIfNotExists(task, () =>
            {
                Debug.Log("Selected: " + task.title);
            });

            if (i == 0)
            {
                taskButton.button.Select();
            }
        }
    }*/

    public TaskButton CreateButtonIfNotExists(TaskObject task, UnityAction selectAction)
    {
        TaskButton taskButton = null;
        //only create the button if we havent seen this id before
        if (!idToButtonMap.ContainsKey(task.title))
        {
            taskButton = InstantiateTaskButton(task, selectAction);
        }
        else
        {
            taskButton = idToButtonMap[task.title];
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
            taskButton.UserInitialize(task.title, task.getEstimateTimeAsString(), selectAction);
        }
        else
        {
            taskButton.SystemInitialize(task.title, task.getEstimateTimeAsString(), selectAction);
        }
        idToButtonMap[task.title] = taskButton;
        return taskButton;
    }
}
