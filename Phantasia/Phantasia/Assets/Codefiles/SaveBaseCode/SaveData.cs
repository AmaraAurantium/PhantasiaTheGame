using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveData
{
    public int coins;
    public bool[] decorUnlocked;
    public ArrayList taskList;
    public GameState gameState;

    public SaveData()
    {
        coins = 0;
        decorUnlocked = new bool[35];
        //gameState = GameState.INTRO;
        taskList = new ArrayList()
        {
            new TaskObject("Stay Hydrated!", 0f, "Get a sip of water! (And if you want to, take a picture of your cup/mug/bottle and upload it on X under #aurantiYUM)", false),
            new TaskObject("Touch Grass :3", 0f, "I challenge you to find a pretty leaf! It has to be prettier than the two I got on my head! #aurantiYUM ", false),
            new TaskObject("Cloudy Day", 0f, "Imagine if you could bite into a cloud sized cotton-candy...YUMMMM...Have you seen a funny looking cloud lately? I wanna see! #aurantiYUM", false),
            new TaskObject("Mogu Mogu", 0f, "Good food always brightens up a bad day! Make sure to have a hearty meal today! #aurantiYUM", false),
            new TaskObject("Treasure?", 0f, "pstttt! I've heard that top shelves often contain rare treasures from the past! Check out your top shelf!", false),
            new TaskObject("Doodle /(._._)", 0f, "Hey! Can I ask you something? If it's alright with you, can you draw me real quick? I'll pose for you! #aurantiYUM", false)
        };
    }
}
