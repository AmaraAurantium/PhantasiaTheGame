using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UserManager : MonoBehaviour, IDataPersistance
{
    [Header("Components")]
    [SerializeField] private GameObject PrefrencesUIPanel;

    public int coins;
    public string username;
    public GameState state { get; private set; }
    private bool startedDay;

    private int wakeTimeHr;
    private int wakeTimeMin;
    private int sleepTimeHr;
    private int sleepTimeMin;

    private DateTime currentTime = DateTime.Now;

    private static UserManager _instance = null;

    public static UserManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("UserManager");
                _instance = go.AddComponent<UserManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public void loadData(SaveData data)
    {
        this.coins = data.coinCount;
        this.startedDay = data.startedDay;

        this.username = data.username;

        this.state = data.gameState;

        this.wakeTimeHr = data.wakeTimeHr;
        this.wakeTimeMin = data.wakeTimeMin;
        this.sleepTimeHr = data.sleepTimeHr;
        this.sleepTimeMin = data.sleepTimeMin;
    }

    public void saveData(ref SaveData data)
    {
        data.coinCount = this.coins;
        data.startedDay = this.startedDay;

        data.username = this.username;

        data.gameState = this.state;

        data.wakeTimeHr = this.wakeTimeHr;
        data.wakeTimeMin = this.wakeTimeMin;
        data.sleepTimeHr = this.sleepTimeHr;
        data.sleepTimeMin = this.sleepTimeMin;
    }

    private void Start()
    {
        PrefrencesUIPanel.SetActive(false);
        updateGameState();
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
        EventsManager.instance.coinEvents.GameStateChange(state);
    }

    private void Update()
    {
        updateGameState();
    }

    private void OnEnable()
    {
        EventsManager.instance.coinEvents.onCoinAdded += coinAdded;
        EventsManager.instance.coinEvents.onCoinSpent += coinSpent;
    }

    private void OnDisable()
    {
        EventsManager.instance.coinEvents.onCoinAdded -= coinAdded;
        EventsManager.instance.coinEvents.onCoinSpent -= coinSpent;
    }

    private void coinAdded(int amount)
    {
        coins += amount;
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
    }

    private void coinSpent(int amount)
    {
        coins -= amount;
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
    }

    public int getCoinCount()
    {
        return coins;
    }

    public void setPrefrences(string username, int wakeTimeHr, int wakeTimeMin, int sleepTimeHr, int sleepTimeMin)
    {
        this.username = username;
        this.wakeTimeHr = wakeTimeHr;
        this.wakeTimeMin = wakeTimeMin;
        this.sleepTimeHr = sleepTimeHr;
        this.sleepTimeMin = sleepTimeMin;
    }

    //gamestate set statements
    public void setStateMorning()
    {
        state = GameState.MORNING;
    }

    public void setStateDay()
    {
        state = GameState.DAY;
    }

    public void setStateNight()
    {
        state = GameState.NIGHT;
    }

    //startday set statements
    public void startDay()
    {
        startedDay = true;

    }

    public void resetStartDay()
    {
        startedDay = false;
    }

    public void openPrefrences()
    {
        PrefrencesUIPanel.SetActive(true);
    }

    public GameState updateGameState()
    {
        GameState newState = GameState.INTRO;

        if(state != GameState.INTRO)
        {
            if (currentTime.Hour < wakeTimeHr || currentTime.Hour > sleepTimeHr)
            {
                newState = GameState.NIGHT;
            }
            else if(currentTime.Hour > wakeTimeHr && currentTime.Hour < sleepTimeHr)
            {
                if (startedDay)
                {
                    newState = GameState.DAY;
                }
                else
                {
                    newState = GameState.MORNING;
                }
            }
            else if(currentTime.Hour == wakeTimeHr)
            {
                if (currentTime.Minute < wakeTimeMin)
                {
                    newState = GameState.NIGHT;
                }
                else
                {
                    if (startedDay)
                    {
                        newState = GameState.DAY;
                    }
                    else
                    {
                        newState = GameState.MORNING;
                    }
                }
            }
            else
            {
                if (currentTime.Minute < sleepTimeMin)
                {
                    if (startedDay)
                    {
                        newState = GameState.DAY;
                    }
                    else
                    {
                        newState = GameState.MORNING;
                    }
                }
                else
                {
                    newState = GameState.NIGHT;
                }
            }
        }

        if(state != newState)
        {
            if (newState == GameState.MORNING)
            {
                setStateMorning();
            }
            else if (newState == GameState.DAY)
            {
                setStateDay();
            }
            else if (newState == GameState.NIGHT)
            {
                setStateNight();
            }

            EventsManager.instance.coinEvents.GameStateChange(newState);
        }

        return state;
    }
}
