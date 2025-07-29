using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TaskObject
{
    public string title;
    public TaskState state { get; private set; }
    [SerializeField] private bool isUserTask;
    [SerializeField] private string description;
    [SerializeField] private float estimateTime;
    private int timesCompleted;//only applicable for system tasks
    private int coin;

    //constructor
    public TaskObject(string name, float time, string descrip, bool tasktype)
    {
        //estimated time is in hours
        //1 hour of work = 10 points
        title = name;
        state = TaskState.PROGRESS;
        estimateTime = time;
        description = descrip;
        coin = calculateCoin(time);
        timesCompleted = 0;
        isUserTask = tasktype;
        //system tasks are false, user tasks are true
    }

    //get functions
    public float getEstimateTimeAsFloat()
    {
        return estimateTime;
    }
    public string getEstimateTimeAsString()
    {
        return estimateTime + "";
    }
    public string getDescription()
    {
        return description;
    }
    public int getvalue()
    {
        return coin;
    }
    public int getTimesCompleted()
    {
        return timesCompleted;
    }
    public bool getIsUserTask()
    {
        return isUserTask;
    }


    //Hide system tasks
    public void hideTask()
    {
        state = TaskState.HIDDEN;
    }

    //complete task
    public void completetask()
    {
        state = TaskState.COMPLETED;
    }

    //uncomplete task
    public void uncompletetask()
    {
        state = TaskState.PROGRESS;
    }

    //change time 
    public void changetime(float newtime)
    {
        estimateTime = newtime;
        coin = calculateCoin(newtime);
    }

    // change task name
    public void changeName(string newname)
    {
        title = newname;
    }

    // change task description
    public void changeDescription(string newdescrip)
    {
        description = newdescrip;
    }

    public void addoccurance()
    {
        timesCompleted++;
    }

    private int calculateCoin(float time)
    {
        int coin;
        if (time < 1.0f)
        {
            coin = 10;
        }
        else
        {
            coin = (int)(estimateTime * 10);
        }
        return coin;
    }
}