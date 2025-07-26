using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    /*[Header("Components")]
    [SerializeField] private TaskItem taskItem;
    public Transform parentCanvasTransform;
    private SaveData data;

    private void Awake()
    {
        data = SaveSystem.load();
    }

    public void taskListReload()
    {
        foreach (TaskObject task in data.taskList)
        {
            GameObject newTaskUI = Instantiate(uiPrefab, parentCanvasTransform);
        }
    }


    public void tally()
    {
        TaskObject task;
        for (int i = 0; i < data.tasklist.Count; i++)
        {
            task = (TaskObject)data.tasklist[i];
            if (task.getstate() == true)
            {
                if (task.gettype() == true)
                {
                    data.totalcarpel += task.getvalue();
                    //remove completed user tasks but not system tasks
                    data.tasklist.RemoveAt(i);
                    i--;
                }
                else
                {
                    task.addoccurance();
                    data.tasklist[i] = task;
                }
            }
        }
        SaveSystem.save(data);
    }
    // Start is called before the first frame update
    void Start()
    {
        tasksys.SetActive(false);
        edittaskinterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }*/
}


