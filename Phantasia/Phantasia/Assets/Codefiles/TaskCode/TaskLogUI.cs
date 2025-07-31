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
		refreshScrollingList();
	}

	private void OnEnable()
	{
		if (firstSelectedButton)
		{
			firstSelectedButton.Select();
		}
		EventsManager.instance.taskEvents.onTaskStateChanged += TaskStateChanged;
		EventsManager.instance.taskEvents.onTaskListUpdate += TaskListUpdate;

		refreshScrollingList();
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskStateChanged -= TaskStateChanged;
		EventsManager.instance.taskEvents.onTaskListUpdate += TaskListUpdate;
	}

	private void TaskListUpdate(List<TaskObject> taskList)
	{
		refreshScrollingList();
	}

	private void TaskStateChanged(TaskObject task)
	{
		//Debug.Log("TaskLogUI TaskStateChanged " + task.title + " " + task.state);
		//add button to scrolling list if not already added
		if (currentSelectedTask == task)
		{
			setTaskLogInfo(task);
		}
	}

	private void refreshScrollingList()
	{
		taskScrollingList.CleanTaskList();
		foreach (var taskInfo in TaskManager.instance.taskList)
		{
			TaskButton taskButton = taskScrollingList.CreateButtonIfNotExists(taskInfo, () =>
			{
				setTaskLogInfo(taskInfo);
			});
			//hide hidden system tasks
			// initialize the first selected button if not already so that it's always the top button
			if (firstSelectedButton == null)
			{
				firstSelectedButton = taskButton.button;
			}
		}

		if (firstSelectedButton != null)
		{
			firstSelectedButton.Select();
		}
	}

	private void setTaskLogInfo(TaskObject task)
	{
		//set the contents of the task into
		currentSelectedTask = task;
		taskTitle.text = task.title;
		taskTitle.readOnly = true;
		taskDescription.text = task.getDescription();

		if (currentSelectedTask.state == TaskState.COMPLETED)
		{
			doneToggle.isOn = true;

			if (!task.getIsUserTask())
			{
				taskTime.text = "Ara's special! <3";
				taskTime.readOnly = true;
				taskDescription.readOnly = true;
			}
			else
			{
				taskTime.text = task.getEstimateTimeAsString() + " hr(s)";
				taskTime.readOnly = false;
				taskDescription.readOnly = false;
			}
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
				taskTime.text = task.getEstimateTimeAsString() + " hr(s)";
				taskTime.readOnly = false;
				taskDescription.readOnly = false;
			}
		}
	}

	public void toggleValueChanged()
	{
		if (currentSelectedTask == null)
		{
			Debug.LogWarning("Current task is empty");
			return;
		}

		if (doneToggle.isOn)
		{
			currentSelectedTask.completetask();
			//EventsManager.instance.taskEvents.TaskCompleted(currentSelectedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
		}
		else
		{
			currentSelectedTask.uncompletetask();
			//EventsManager.instance.taskEvents.TaskUncompleted(currentSelectedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
		}
	}

	public void timeContentChanged()
	{
		string trimmedText = taskTime.text;
		if (taskTime.text.EndsWith(" hr(s)"))
		{
			trimmedText = trimmedText.Substring(0, trimmedText.Length - 6);
			//Debug.Log("trimmed text: " + trimmedText);
		}
		if (float.TryParse(trimmedText, out float time))
		{
			currentSelectedTask.changetime(time);
			EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
		}
	}


	public void descriptionContentChanged()
	{
		currentSelectedTask.changeDescription(taskDescription.text);
		EventsManager.instance.taskEvents.TaskStateChanged(currentSelectedTask);
	}
}
