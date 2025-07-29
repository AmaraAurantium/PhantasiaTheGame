using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewTaskUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private GameObject contentParent;
	[SerializeField] private Button confirmButton;
	[SerializeField] private Button cancelButton;
	[SerializeField] private TextMeshProUGUI warning;
	[SerializeField] private TMP_InputField taskTitle;
	[SerializeField] private TMP_InputField taskTime;
	[SerializeField] private TMP_InputField taskDescription;


	private void Awake()
	{
		// starting with clear panel
		ResetPanel();
	}

	public void confirmNewTask()
    {
		string title = taskTitle.text;
		string description = taskDescription.text;
		float time = 0f;
		if (float.TryParse(taskTime.text, out time))
        {
			//Debug.Log("attempt to create new task with \nname: " + title
			//	+ "\nestimated time: " + time + "\ndescription: " + description);
            TaskManager.instance.AddTask(title, time, description, true);
			contentParent.SetActive(false);
			ResetPanel();
		}
        else
        {
			warning.enabled = true;
        }
	}

	public void cancelNewTask()
    {
		ResetPanel();
    }

	private void ResetPanel()
	{
		contentParent.SetActive(false);
		taskTitle.text = "New Task Name";
		taskTime.text = "Estimated time (Unit: Hours)";
		taskDescription.text = "Feel free to put in any details regarding your task :3";
		warning.enabled = false;
	}

}
