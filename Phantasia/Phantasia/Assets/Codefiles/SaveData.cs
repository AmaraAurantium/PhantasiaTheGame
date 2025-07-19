using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveData
{
    public int totalcarpel;
    public bool[] decorunlocked;
    public ArrayList tasklist;
    public int[] sysnum;
    //ara settings so that they are unique
    public int araoutwardness;

    public SaveData()
    {
        totalcarpel = 0;
        decorunlocked = new bool[35];
        sysnum = new int[3];
        tasklist = new ArrayList();
        tasklist.Add(new TaskObject(0f, "Have something to drink!", false));
        tasklist.Add(new TaskObject(0f, "Stretch~~", false));
        tasklist.Add(new TaskObject(0f, "Go for a walk", false));
        tasklist.Add(new TaskObject(0f, "Have an orange!(any fruit, really)", false));
        tasklist.Add(new TaskObject(0f, "Listen to ur fav song", false));
        tasklist.Add(new TaskObject(0f, "Have a hearty meal :3", false));
        tasklist.Add(new TaskObject(0f, "Read at least a chapter of any book", false));
        tasklist.Add(new TaskObject(0f, "Doodle /(._._)", false));
        tasklist.Add(new TaskObject(0f, "Observe 3 passerby", false));
        tasklist.Add(new TaskObject(0f, "Take a picture of a funny looking tree or cloud", false));
        //araoutwardness = Random.Range(0,10);
    }
}
