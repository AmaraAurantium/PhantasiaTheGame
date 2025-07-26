using System;

public class TaskEvents
{
    public event Action<string> onTaskCompleted;
    public void TaskCompleted(string id)
    {
        if (onTaskCompleted != null)
        {
            onTaskCompleted(id);
        }
    }

    public event Action<string> onTaskUncompleted;
    public void TaskUncompleted(string id)
    {
        if (onTaskUncompleted != null)
        {
            onTaskUncompleted(id);
        }
    }

    public event Action<string> onTaskHidden;
    public void TaskHidden(string id)
    {
        if (onTaskHidden != null)
        {
            onTaskHidden(id);
        }
    }

    public event Action<string> onTaskClaimed;
    public void TaskClaimed(string id)
    {
        if (onTaskClaimed != null)
        {
            onTaskClaimed(id);
        }
    }

    public event Action<TaskObject> onTaskStateChanged;
    public void TaskStateChanged(TaskObject task)
    {
        if (onTaskStateChanged != null)
        {
            onTaskStateChanged(task);
        }
    }
}
