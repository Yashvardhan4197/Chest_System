using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectedState: IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }
    private ChestStateMachine stateMachine;
    private int coinReward=0;
    private int gemReward=0;

    public CollectedState(ChestStateMachine stateMachine, ChestStates chestState)
    {
        this.stateMachine = stateMachine;
        currentChestState = chestState;
    }

    public void OnButtonPressed()
    {
        
        //throw new NotImplementedException();
    }

    private void DestroyOwner()
    {
        Owner.chestView.ResetSlot();
        GameService.Instance.chestService.ReturnChests().Remove(Owner);
        Owner.DestroyController();
    }

    private void AddReward()
    {
        CalculateReward();
        SetReward();
        UpdatePopUp();
    }

    private void UpdatePopUp()
    {
        GameService.Instance.UIService.GetPopUpController().SetRewardPopUpText(coinReward, gemReward);
        GameService.Instance.UIService.GetPopUpController().OpenRewardPopUp();
    }

    private void SetReward()
    {
        int currentCoinAmount = GameService.Instance.UIService.GetCurrencyController().CoinAmount;
        int currentGemAmount = GameService.Instance.UIService.GetCurrencyController().GemAmount;
        GameService.Instance.UIService.GetCurrencyController().SetCoinAmount(currentCoinAmount + coinReward);
        GameService.Instance.UIService.GetCurrencyController().SetGemAmount(currentGemAmount + gemReward);
    }

    private void CalculateReward()
    {
        ChestTypes currentChestType = Owner.chestData.ChestType;
        switch (currentChestType)
        {
            case ChestTypes.COMMON:
                {
                    coinReward = CalculateInRange(100, 200);
                    gemReward = CalculateInRange(10, 20);
                    break;
                }
            case ChestTypes.RARE:
                {
                    coinReward = CalculateInRange(300, 500);
                    gemReward = CalculateInRange(20, 40);
                    break;
                }
            case ChestTypes.EPIC:
                {
                    coinReward = CalculateInRange(600, 800);
                    gemReward = CalculateInRange(45, 60);
                    break;
                }
            case ChestTypes.LEGENDARY:
                {
                    coinReward = CalculateInRange(1000, 1200);
                    gemReward = CalculateInRange(80, 100);
                    break;
                }
        }
    }

    private int CalculateInRange(int v1, int v2)
    {
        int ans=UnityEngine.Random.Range(v1, v2);
        return ans;
    }

    public void OnStateEnter()
    {
        Debug.Log("Reached collectedState");
        AddReward();
        DestroyOwner();
        //throw new NotImplementedException();
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
