using System;
using System.Collections.Generic;

public class TaskEvents
{
	public event Action onClaimRewards;
	public void ClaimRewards()
	{
		if (onClaimRewards != null)
		{
			onClaimRewards();
		}
	}

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

	public event Action<TaskObject> onTaskStateChanged;
	public void TaskStateChanged(TaskObject task)
	{
		if (onTaskStateChanged != null)
		{
			onTaskStateChanged(task);
		}
	}

	public event Action<TaskObject> onPanelContentUpdate;
	public void PanelContentUpdate(TaskObject task)
	{
		if (onPanelContentUpdate != null)
		{
			onPanelContentUpdate(task);
		}
	}

	public event Action<List<TaskObject>> onTaskListUpdate;
	public void TaskListUpdate(List<TaskObject> taskList)
	{
		if (onTaskListUpdate != null)
		{
			onTaskListUpdate(taskList);
		}
	}
}
