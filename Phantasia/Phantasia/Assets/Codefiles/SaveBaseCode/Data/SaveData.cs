using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int coinCount;
    public GameState gameState;
    public List<TaskObject> taskList;
    public List<ShopObject> shopList;

    public SaveData()
    {
        this.coinCount = 0;
        this.gameState = GameState.INTRO;
        this.taskList = new List<TaskObject>
        {
            new TaskObject("Stay Hydrated!", 0f, "Get a sip of water! (And if you want to, take a picture of your cup/mug/bottle and upload it on X under #aurantiYUM)", false),
            new TaskObject("Touch Grass :3", 0f, "I challenge you to find a pretty leaf! It has to be prettier than the two I got on my head! #aurantiYUM ", false),
            new TaskObject("Cloudy Day", 0f, "Imagine if you could bite into a cloud sized cotton-candy...YUMMMM...Have you seen a funny looking cloud lately? I wanna see! #aurantiYUM", false),
            new TaskObject("Mogu Mogu", 0f, "Good food always brightens up a bad day! Make sure to have a hearty meal today! #aurantiYUM", false),
            new TaskObject("Treasure?", 0f, "pstttt! I've heard that top shelves often contain rare treasures from the past! Check out your top shelf!", false),

            new TaskObject("Doodle /(._._)", 0f, "Hey! Can I ask you something? If it's alright with you, can you draw me real quick? I'll pose for you! #aurantiYUM", false)
        };
        this.shopList = new List<ShopObject>
        {
            new ShopObject("Party Balloons", true, 10, "Balloons. Perfect for celebrating a new friendship, don't you think?", new int[]{0}, 0, 5, 0),
            new ShopObject("Orange", true, 25, "An orange shaped decor for your orange friend!", new int[]{1}, 1, 5, 0),
            new ShopObject("Apple", true, 25, "The symbol for a healthy habit. Why not get it as a decoration?", new int[]{2}, 2, 5, 0),
            new ShopObject("Frame", true, 40, "Set of three pictures of your beloved friend", new int[]{3,4,5,6}, 3, 5, 0),
            new ShopObject("Star Deco", true, 50, "Don't you find the walls a little empty?", new int[]{7}, 4, 6, 1),

            new ShopObject("Computer", true, 200, "Pwease don't let your friend live in the stone age..? Technology!", new int[]{8,9,10,11}, 5, 6, 1),
            new ShopObject("Plushie Set A", true, 30, "Plushies to mark your achievements. Great work!", new int[]{12,13}, 6, 6, 1),
            new ShopObject("Plushie Set B", true, 50, "A must-have for a comfy room.", new int[]{14,15}, 7, 6, 1),
            new ShopObject("Cup", true, 30, "Stay hydrated. All of you.", new int[]{16}, 8, 5, 0),
            new ShopObject("'Miss Deborah' Birdie", true, 170, "'Bee for the busy'...but a birdie? Why not.", new int[]{17}, 9, 5, 0),

            new ShopObject("Books Set A", true, 50, "Get Educated, will ya?", new int[]{18}, 10, 6, 1),
            new ShopObject("Books Set B", true, 50, "That shelf looks a little bit empty, don't you think?", new int[]{19}, 11, 8, 3),
            new ShopObject("Paint", false, 400, "Magic paint. paints all the walls, flooring, shelves, and more!", new int[]{20,21,22,23,24}, 12, 9, 4),
            new ShopObject("Desk & Chair", false, 100, "Colorful looking working enviroments are a must have for a good study mood!", new int[]{25,26}, 13, 5, 0),
            new ShopObject("Stairs & Door", false, 100, "Very important that the stairs and doors are actualy discernible.", new int[]{27,28,29,30}, 14, 7, 2),

            new ShopObject("Sofa", true, 200, "Compfy resting spot for the hardworking ppl out there!", new int[]{31,32,33}, 15, 7, 2),
            new ShopObject("Bedside Desk & Carpet", false, 80, "Colorful and cozy carpets!", new int[]{34,35,36}, 16, 5, 0),
            new ShopObject("Bed", false, 100, "Need I say more. a mimir", new int[]{37,38,39,40}, 17, 5, 0)
        };
    }
}
