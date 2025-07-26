using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskEvents
{
    public event Action onTaskCompleted;
    public void TaskCompleted()
    {
        if (onTaskCompleted != null)
        {
            onTaskCompleted();
        }
    }

    public event Action onTaskUncompleted;
    public void TaskUncompleted()
    {
        if (onTaskUncompleted != null)
        {
            onTaskUncompleted();
        }
    }

    public event Action onTaskHidden;
    public void TaskHidden()
    {
        if (onTaskHidden != null)
        {
            onTaskHidden();
        }
    }

    public event Action onTaskClaimed;
    public void TaskClaimed()
    {
        if (onTaskClaimed != null)
        {
            onTaskClaimed();
        }
    }
}
