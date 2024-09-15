using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedState: IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }
    private ChestStateMachine stateMachine;

    public UnlockedState(ChestStateMachine stateMachine,ChestStates chestState)
    {
        this.stateMachine = stateMachine;
        currentChestState = chestState;
    }

    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockedChestSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetTimerValue(0);
        Owner.chestView.SetChestPrice("0000","0000");
        Owner.chestView.SetChestType(Owner.chestData.ChestType);
        Owner.chestView.UpdateSlot();
    }
    public void OnButtonPressed()
    {
        stateMachine.ChangeState(ChestStates.COLLECTED);

    }

    public void OnStateEnter()
    {
        CheckInChests();
        InitializeData();
        Debug.Log("Unlocked State Reached");
        GameService.Instance.SoundManager.PlaySound(Sound.UNLOCKED);
    }

    private void CheckInChests()
    {
        if (GameService.Instance.ChestService.IsQueueEmpty()==false && GameService.Instance.ChestService.GetStateFromQueue().Owner==Owner)
        {
            GameService.Instance.ChestService.RemoveTopFromQueue();
        }

        GameService.Instance.ChestService.TransitionStatetoUnlocking();
    }

    public void OnStateExit()
    {
        //throw new NotImplementedException();
    }

    public void Update()
    {
        
        //throw new NotImplementedException();
    }
}
