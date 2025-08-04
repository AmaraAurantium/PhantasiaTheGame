using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrefrencesUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private GameObject contentParent;
	[SerializeField] private Button confirmButton;

	[SerializeField] private GameObject warningCP;
	[SerializeField] private TextMeshProUGUI warningText;

	[SerializeField] private TMP_InputField usernameINP;
	[SerializeField] private TMP_InputField wakeTimeHrINP;
	[SerializeField] private TMP_InputField wakeTimeMinINP;
	[SerializeField] private TMP_InputField sleepTimeHrINP;
	[SerializeField] private TMP_InputField sleepTimeMinINP;

	private void Awake()
	{
		// starting with clear panel
		ResetPanel();
	}

	public void confirmPrefrences()
	{
		string username = usernameINP.text;
		int wakeTimeHr = int.Parse(wakeTimeHrINP.text);
		int wakeTimeMin = int.Parse(wakeTimeMinINP.text);
		int sleepTimeHr = int.Parse(sleepTimeHrINP.text);
		int sleepTimeMin = int.Parse(sleepTimeMinINP.text);

		if (wakeTimeHr > sleepTimeHr || (wakeTimeHr == sleepTimeHr && wakeTimeMin > sleepTimeMin))
		{
			warningText.text = "*sigh* As much as we all would love to, no, you can't sleep before you wake up.";
			warningCP.SetActive(true);
		}
		else if (wakeTimeHr > 23 || wakeTimeMin > 59 || sleepTimeHr > 23 || sleepTimeMin > 59)
        {
			warningText.text = "Correct me if I'm wrong, but I'm pretty sure that's not a valid time";
			warningCP.SetActive(true);
		}
		else
		{
			UserManager.instance.setPrefrences(username, wakeTimeHr, wakeTimeMin, sleepTimeHr, sleepTimeMin);
			contentParent.SetActive(false);
			ResetPanel();
		}
	}

	private void ResetPanel()
	{
		contentParent.SetActive(false);

		usernameINP.text = "";
		wakeTimeHrINP.text = "";
		wakeTimeMinINP.text = "";
		sleepTimeHrINP.text = "";
		sleepTimeMinINP.text = "";

		warningCP.SetActive(false);
	}

}
