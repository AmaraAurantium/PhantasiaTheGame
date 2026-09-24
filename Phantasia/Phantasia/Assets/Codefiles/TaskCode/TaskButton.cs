using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class TaskButton : MonoBehaviour, ISelectHandler
{
	[Header("Components")]
	[SerializeField] private TextMeshProUGUI titletext;
	[SerializeField] private TextMeshProUGUI timetext;
	[SerializeField] private Toggle taskcompletetoggle;
	public Button button { get; private set; }
	private UnityAction onSelectAction;
	private TaskObject designatedTask = null;

	private void OnEnable()
	{
		EventsManager.instance.taskEvents.onTaskStateChanged += TaskStateChanged;
	}

	private void OnDisable()
	{
		EventsManager.instance.taskEvents.onTaskStateChanged -= TaskStateChanged;
	}

	private void TaskStateChanged(TaskObject task)
	{
		if (designatedTask == task)
		{
			taskcompletetoggle.isOn = checkState(task);
			if (task.getIsUserTask())
			{
				timetext.text = task.getEstimateTimeAsString() + " hr(s)";
			}
		}
	}

	public void ToggleValueChanged()
	{
		if (designatedTask == null)
		{
			Debug.LogWarning("Current task is empty");
			return;
		}

		if (taskcompletetoggle.isOn)
		{
			designatedTask.completetask();
			EventsManager.instance.taskEvents.TaskCompleted(designatedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(designatedTask);
			//Debug.Log("taskbutton log: " + designatedTask.title + "is now " + designatedTask.state);
		}
		else
		{
			designatedTask.uncompletetask();
			EventsManager.instance.taskEvents.TaskUncompleted(designatedTask.title);
			EventsManager.instance.taskEvents.TaskStateChanged(designatedTask);
			//Debug.Log("taskbutton log: " + designatedTask.title + "is now " + designatedTask.state);
		}
	}

	//since this may be diabled when we instanciate it, we would need to manually instantiate everything
	public void UserInitialize(TaskObject task, UnityAction selectAction)
	{
		designatedTask = task;
		Refresh();
		this.timetext.text = task.getEstimateTimeAsString() + " hr(s)";
		SetSelectAction(selectAction);
	}

	public void SetSelectAction(UnityAction selectAction)
	{
		this.onSelectAction = selectAction;
	}

	public void Refresh()
	{
		if (designatedTask != null)
		{
			taskcompletetoggle.isOn = checkState(designatedTask);
			this.button = this.GetComponent<Button>();
			this.titletext.text = designatedTask.title;
		}
	}

	public void SystemInitialize(TaskObject task, UnityAction selectAction)
	{
		designatedTask = task;
		Refresh();
		this.timetext.text = "Ara's special! <3";
		SetSelectAction(selectAction);
	}

	public void OnSelect(BaseEventData eventData)
	{
		onSelectAction();
	}

	private bool checkState(TaskObject task)
	{
		if (task.GetState() == TaskState.COMPLETED)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
