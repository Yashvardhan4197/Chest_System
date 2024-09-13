using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedState: IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine stateMachine;

    public UnlockedState(ChestStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockedChestSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetTimerValue(0);
        Owner.chestView.SetChestPrice("0000","0000");
        Owner.chestView.chestType = Owner.chestData.ChestType;
        Owner.chestView.UpdateSlot();
    }
    public void OnButtonPressed()
    {
        stateMachine.ChangeState(ChestStates.COLLECTED);
    }

    public void OnStateEnter()
    {
        Owner.SetCanOpen(true);
        InitializeData();
        Debug.Log("Unlocked State Reached");
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
