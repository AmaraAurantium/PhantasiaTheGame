using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTask : MonoBehaviour
{
    public GameObject taskprefab;
    public GameObject solidcheck;
    public TextMeshProUGUI title;
    public TextMeshProUGUI time;

    public GameObject warning;
    public GameObject window;

    public TMP_InputField newtaskname;
    public TMP_InputField newtasktime;
    public SaveData data;

    private void Awake()
    {
        data = SaveSystem.load();
    }

    public void confirmed()
    {
        decimal e = 0;
        bool checkvalid = decimal.TryParse(newtasktime.text, out e);
        if (checkvalid == true)
        {
            warning.SetActive(false);
            float t = (float)e;
            TaskObject task = new TaskObject(t, newtaskname.text, true);
            data.tasklist.Add(task);

            title.text = newtaskname.text;
            time.text = newtasktime.text + " Hours";
            solidcheck.SetActive(false);

            window.SetActive(false);

            SaveSystem.save(data);

        }
        else
        {
            warning.SetActive(true);
        }

    }
}
