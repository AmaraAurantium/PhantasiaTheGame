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
		EventsManager.instance.taskEvents.onTaskClaimed += TaskClaimed;
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskHidden -= TaskHidden;
		EventsManager.instance.taskEvents.onTaskCompleted -= TaskCompleted;
		EventsManager.instance.taskEvents.onTaskUncompleted -= TaskUncompleted;
		EventsManager.instance.taskEvents.onTaskClaimed -= TaskClaimed;
	}

	private void TaskHidden(string id)
	{
		//Debug.Log("Hide task: " + id);
	}

	private void TaskCompleted(string id)
	{
		TaskObject currentTask = GetTaskByID(id);
		currentTask.completetask();
		//Debug.Log("Complete task: " + id);
	}

	private void TaskUncompleted(string id)
	{
		TaskObject currentTask = GetTaskByID(id);
		currentTask.uncompletetask();
		//Debug.Log("Uncomplete task: " + id);
	}

	private void TaskClaimed(string id)
	{
		//Debug.Log("Claim task: " + id);
	}

	public void AddTask(string name, float time, string descrip, bool tasktype)
	{
		var newTask = new TaskObject(name, time, descrip, tasktype);
		taskList.Add(newTask);
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
