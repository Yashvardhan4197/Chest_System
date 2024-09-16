using System;
using TMPro;
using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private TimeSpan chestTimeSpan;
    private int GemPrice;
    private float CurrentTime;
    private static bool InQueue = true;
    public ChestScriptableObject chestData;
    public ChestStateMachine chestStateMachine;
    
    public ChestController(ChestView chestView,ChestScriptableObject chestData)
    {
        this.chestView = chestView;
        this.chestData = chestData;
        chestView.SetController(this);
        chestStateMachine =new ChestStateMachine(this);
        chestStateMachine.ChangeState(ChestStates.LOCKED);
        CurrentTime = chestData.TimerValue;
    }

    public void SetTimer(TextMeshProUGUI timerUI, float timerTime)
    {
        chestTimeSpan=TimeSpan.FromSeconds(timerTime);
        timerUI.text = string.Format("{0:D2}:{1:D2}:{2:D2}", chestTimeSpan.Hours, chestTimeSpan.Minutes, chestTimeSpan.Seconds);
    }

    public void Update()
    {
        chestStateMachine?.Update();
    }

    public void OnChestButtonPressed()
    {
        chestStateMachine.currentState.OnButtonPressed();
    }

    public string CalculateGemPrice(float timer)
    {
        float temp =timer / 10;
        int price=0;
        if (timer % 10 <= 5)
        {
            price = (int)temp;
        }
        else
        {
            price = (int)temp+1;
        }
        GemPrice= price;
        return price.ToString();
    }

    public void SetCanOpen(bool canOpen)
    {
        InQueue = canOpen;
    }

    public bool GetCanOpen() => InQueue;

    public int GetGemCurrentPrice()=>GemPrice;

    public void DestroyController()
    {
        chestStateMachine = null;
        chestView.SetController(null);
    }

    public void SetCurrentTimer(float currentTime)
    {
        CurrentTime = currentTime;
        chestView.SetTimerValue(currentTime);
        chestView.SetChestPrice(chestData.ChestCoinPrice.ToString(),CalculateGemPrice(CurrentTime));
    }

    public void UpdateCurrentTime()=> chestView.SetTimerValue(CurrentTime);

    internal void SetChestImage(Sprite lockedChestSprite)
    {
        chestView.SetChestImage(lockedChestSprite);
    }

    internal void SetChestName(string chestName)
    {
        chestView.SetChestName(chestName);
    }

    internal void SetTimerValue(int timerValue)
    {
        chestView.SetTimerValue((int)timerValue);
    }

    internal void SetChestPrice(string v1, string v2)
    {
        chestView.SetChestPrice(v1, v2);
    }

    internal void SetChestType(ChestTypes chestType)
    {
        chestView.SetChestType(chestType);
    }

    internal void UpdateSlot()
    {
        chestView.UpdateSlot();
    }

    internal void ResetSlot()
    {
        chestView.ResetSlot();
    }

    internal void SetInQueueText(bool v)
    {
        chestView.SetInQueueText(v);
    }
}
