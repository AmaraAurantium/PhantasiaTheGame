using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using UnityEngine;


public class TaskManager : MonoBehaviour, IDataPersistance 
{
	[SerializeField] public List<TaskObject> taskList = new List<TaskObject>();
	int randomSystemTaskID;

	public static TaskManager instance = null;

	public void loadData(SaveData data)
	{
		this.taskList = data.taskList;
		this.randomSystemTaskID = data.randomSystemTaskID;
	}

	public void saveData(ref SaveData data)
	{
		data.taskList = this.taskList;
		data.randomSystemTaskID = this.randomSystemTaskID;
	}

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
		EventsManager.instance.taskEvents.onSetSystemTask += SetRandomSystemTask;
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskHidden -= TaskHidden;
		EventsManager.instance.taskEvents.onTaskCompleted -= TaskCompleted;
		EventsManager.instance.taskEvents.onTaskUncompleted -= TaskUncompleted;
		EventsManager.instance.taskEvents.onClaimRewards -= ClaimCompleted;
		EventsManager.instance.taskEvents.onSetSystemTask -= SetRandomSystemTask;
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
			if (task.GetState() == TaskState.HIDDEN || task.GetState() == TaskState.PROGRESS)
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
					Debug.Log(task.title + " is added to newtasklist in state: " + task.GetState());
				}
			}
		}
		taskList = newtaskList;
		EventsManager.instance.taskEvents.TaskListUpdate(taskList);
		UserManager.instance.resetStartDay();
	}
	public void SetRandomSystemTask()
    {
		System.Random rnd = new System.Random();
		randomSystemTaskID = rnd.Next(6);
		TaskObject DailySystemTask = taskList[randomSystemTaskID];
		DailySystemTask.uncompletetask();
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
