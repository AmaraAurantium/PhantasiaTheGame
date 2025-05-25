using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class ShowTask : MonoBehaviour
{
    public TaskObject task;

    public GameObject solidcheck;
    public TextMeshProUGUI title;
    public TextMeshProUGUI time;
    public bool state;

    public void instantatetask()
    {
        title.SetText(task.taskname);
        state = task.getstate();
        if (task.gettype() == true)
        {
            time.SetText(task.getest() + "Hours");
        }
        else
        {
            time.SetText("<3");
        }
    }

    public void markcomplete()
    {
        solidcheck.SetActive(true);
        task.completetask();
    }

    public void markuncomplete()
    {
        solidcheck.SetActive(false);
        task.uncompletetask();
    }
}
