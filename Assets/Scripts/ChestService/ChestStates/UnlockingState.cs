
using System;
using UnityEngine;

public class UnlockingState: IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine stateMachine;
    public ChestStates currentChestState { get; set; }
    private float timer;
    private bool timerRunning=true;
    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockingChestSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.chestType = Owner.chestData.ChestType;
        Owner.chestView.UpdateSlot();
        timer=Owner.chestData.TimerValue;
    }

    public UnlockingState(ChestStateMachine stateMachine,ChestStates chestState)
    {
        this.stateMachine = stateMachine;
        currentChestState = chestState;
    }

    public void OnButtonPressed()
    {
        GameService.Instance.UIService.GetPopUpController().OpenChestUnlockingPopUp();
        GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
    }

    public void OnStateEnter()
    {
        InitializeData();
        Owner.SetCanOpen(false);
        timerRunning =true;
    }

    public void OnStateExit()
    {
        //throw new NotImplementedException();
    }

    public void Update()
    {
        if (timerRunning)
        {
            if (timer > 0)
            {
                StartTimer();
            }
            else
            {
                stateMachine.ChangeState(ChestStates.UNLOCKED);
            }
        }
        //throw new NotImplementedException();
    }

    private void StartTimer()
    {
        timer -= Time.deltaTime;
        Owner.chestView.SetTimerValue(timer);
        Owner.chestView.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(), Owner.CalculateGemPrice(timer));
    }
}
