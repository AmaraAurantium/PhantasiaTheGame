using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TaskObject
{
    private bool state;
    private float est;
    private int carpel;
    public string taskname;
    private int occurance;
    private bool type;

    //constructor
    public TaskObject(float e, string n, bool t)
    {
        //estimated time is in hours
        //1 hour of work = 10 points
        state = false;
        est = e;
        carpel = (int)(e * 10);
        taskname = n;
        occurance = 0;
        type = t;
        //system tasks are false, user tasks are true
    }

    //get functions
    public bool getstate()
    {
        return state;
    }
    public float getest()
    {
        return est;
    }
    public int getvalue()
    {
        return carpel;
    }
    public int getoccurance()
    {
        return occurance;
    }
    public bool gettype()
    {
        return type;
    }


    //complete task
    public void completetask()
    {
        state = true;
    }
    //remove task if they realized they need more time
    public void uncompletetask()
    {
        state = false;
    }
    //change time needed to finish
    public void changetime(float newtime)
    {
        est = newtime;
        carpel = (int)(est * 10);
    }
    // change task name
    public void changename(string newname)
    {
        taskname = newname;
    }
    public void addoccurance()
    {
        occurance++;
    }
}