using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    public GameObject tasksys;
    public GameObject edittaskinterface;

    public SaveData data;

    private void Awake()
    {
        data = SaveSystem.load();
    }


    public void organize(int num1, int num2, int num3)
    {
        data.sysnum[0] = num1;
        data.sysnum[1] = num2;
        data.sysnum[2] = num3;

        for (int i = 0; i < data.tasklist.Count; i++)
        {
        }
    }

    public void tally()
    {
        TaskObject task;
        for (int i = 0; i < data.tasklist.Count; i++)
        {
            task = (TaskObject)data.tasklist[i];
            if (task.getstate() == true)
            {
                if (task.gettype() == true)
                {
                    data.totalcarpel += task.getvalue();
                    //remove completed user tasks but not system tasks
                    data.tasklist.RemoveAt(i);
                    i--;
                }
                else
                {
                    task.addoccurance();
                    data.tasklist[i] = task;
                }
            }
        }
        SaveSystem.save(data);
    }
    // Start is called before the first frame update
    void Start()
    {
        tasksys.SetActive(false);
        edittaskinterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}


//generate three nonrepeating numbers
//cannot run during instantation
/*int num1, num2, num3, temp;
num1 = Random.Range(0, 10);
temp = Random.Range(0, 10);
while (temp == num1)
{
    if (temp == 9)
    {
        temp = 0;
    }
    else
    {
        temp++;
    }
}
num2 = temp;
temp = Random.Range(0, 10);
while (temp == num1 || temp == num2)
{
    if (temp == 9)
    {
        temp = 0;
    }
    else
    {
        temp++;
    }
}
num3 = temp;*/