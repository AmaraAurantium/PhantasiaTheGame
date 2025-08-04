using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind (Story story)
    {
        story.BindExternalFunction("ClaimCompleted" , () => ClaimCompleted());
        story.BindExternalFunction("StartDay", () => StartDay());
        story.BindExternalFunction("StartGame", () => StartGame());
        story.BindExternalFunction("OpenPrefrences", () => OpenPrefrences());
    }

    public void unBind(Story story)
    {
        story.UnbindExternalFunction("ClaimCompleted");
        story.UnbindExternalFunction("StartDay");
        story.UnbindExternalFunction("StartGame");
        story.UnbindExternalFunction("OpenPrefrences");
    }

    private void ClaimCompleted()
    {
        EventsManager.instance.taskEvents.ClaimRewards();
    }

    private void StartDay()
    {
        UserManager.instance.startDay();
        UserManager.instance.setStateDay();
        EventsManager.instance.coinEvents.GameStateChange(GameState.DAY);
    }

    private void StartGame()
    {
        UserManager.instance.setStateMorning();
        GameState state = UserManager.instance.updateGameState();
        EventsManager.instance.coinEvents.GameStateChange(state);
    }

    private void OpenPrefrences()
    {
        UserManager.instance.openPrefrences();
    }
}
