using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using UnityEngine;


public class TaskManager : MonoBehaviour
{
	[SerializeField] public List<TaskObject> taskList = new List<TaskObject>();

	public static TaskManager instance = null;

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		EventsManager.instance.taskEvents.onTaskHidden += TaskHidden;
		EventsManager.instance.taskEvents.onTaskCompleted += TaskCompleted;
		EventsManager.instance.taskEvents.onTaskUncompleted += TaskUncompleted;
		EventsManager.instance.taskEvents.onClaimRewards += ClaimCompleted;
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskHidden -= TaskHidden;
		EventsManager.instance.taskEvents.onTaskCompleted -= TaskCompleted;
		EventsManager.instance.taskEvents.onTaskUncompleted -= TaskUncompleted;
		EventsManager.instance.taskEvents.onClaimRewards -= ClaimCompleted;
	}

	private void TaskHidden(string id)
	{
		//Debug.Log("Hide task: " + id);
	}

	private void TaskCompleted(string id)
	{
		//TaskObject currentTask = GetTaskByID(id);
		//currentTask.completetask();
		//Debug.Log("Complete task: " + id);
	}

	private void TaskUncompleted(string id)
	{
		//TaskObject currentTask = GetTaskByID(id);
		//currentTask.uncompletetask();
		//Debug.Log("Uncomplete task: " + id);
	}

	public void AddTask(string name, float time, string descrip, bool tasktype)
	{
		var newTask = new TaskObject(name, time, descrip, tasktype);
		taskList.Add(newTask);
		EventsManager.instance.taskEvents.TaskListUpdate(taskList);
	}

	public void ClaimCompleted()
    {
		List<TaskObject> newtaskList = new List<TaskObject>();
		foreach (var task in taskList)
		{
			if (task.state == TaskState.HIDDEN || task.state == TaskState.PROGRESS)
            {
				newtaskList.Add(task);
			}
            else
            {
				EventsManager.instance.coinEvents.CoinAdded(task.getvalue());
				Debug.Log(task.title + " is worth " + task.getvalue() + "coins");
				if (!task.getIsUserTask())
				{
					task.hideTask();
					EventsManager.instance.taskEvents.TaskStateChanged(task);
					task.addoccurance();
					newtaskList.Add(task);
					//Debug.Log(task.title + " is added to newtasklist in state: " + task.state);
				}
			}
		}
		taskList = newtaskList;
		EventsManager.instance.taskEvents.TaskListUpdate(taskList);
	}

	private TaskObject GetTaskByID(string id)
	{
		foreach (var task in taskList)
		{
			if (id == task.title)
			{
				return task;
			}
		}
		Debug.LogError("ID not found in taskList: " + id);
		return null;
	}
}
