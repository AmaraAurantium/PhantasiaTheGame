using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskLogUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private GameObject contentParent;
	[SerializeField] private TaskScrollingList taskScrollingList;
	[SerializeField] private Toggle doneToggle;
	[SerializeField] private TMP_InputField taskTitle;
	[SerializeField] private TMP_InputField taskTime;
	[SerializeField] private TMP_InputField taskDescription;

	private TaskObject currentSelectedTask = null;

	private Button firstSelectedButton;

	void Start()
	{
		foreach (var taskInfo in TaskManager.instance.taskList)
		{
			TaskButton taskButton = taskScrollingList.CreateButtonIfNotExists(taskInfo, () =>
			{
				SetTaskLogInfo(taskInfo);
			});
			// initialize the first selected button if not already so that it's always the top button
			if (firstSelectedButton == null)
			{
				firstSelectedButton = taskButton.button;
				firstSelectedButton.Select();
			}
		}
	}
	private void OnEnable()
	{
		if (firstSelectedButton)
		{
			firstSelectedButton.Select();
		}
		EventsManager.instance.taskEvents.onTaskStateChanged += TaskStateChanged;
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskStateChanged -= TaskStateChanged;
	}

	private void TaskStateChanged(TaskObject task)
	{
		Debug.Log("TaskLogUI TaskStateChanged " + task.title + " " + task.state);
		//add button to scrolling list if not already added
		if (currentSelectedTask == task)
		{
			SetTaskLogInfo(task);
		}
	}
	private void SetTaskLogInfo(TaskObject task)
	{
		//set the contents of the task into
		currentSelectedTask = task;
		taskTitle.text = task.title;
		taskTitle.readOnly = true;
		taskDescription.text = task.getDescription();

		if (currentSelectedTask.state == TaskState.COMPLETED || currentSelectedTask.state == TaskState.CLAIMED)
		{
			doneToggle.isOn = true;
		}
		else
		{
			doneToggle.isOn = false;

			if (!task.getIsUserTask())
			{
				taskTime.text = "Ara's special! <3";
				taskTime.readOnly = true;
				taskDescription.readOnly = true;
			}
			else
			{
				taskTime.text = task.getEstimateTimeAsString() + "Hours";
			}
		}
	}

	public void ToggleValueChanged()
	{
		if (currentSelectedTask == null)
		{
			Debug.LogWarning("Current task is empty");
			return;
		}

		if (doneToggle.isOn)
		{
			currentSelectedTask.completetask();
			EventsManager.instance.taskEvents.TaskCompleted(currentSelectedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
		}
		else
		{
			currentSelectedTask.uncompletetask();
			EventsManager.instance.taskEvents.TaskUncompleted(currentSelectedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
		}
	}
}
