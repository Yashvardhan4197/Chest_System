
using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;

public class PopUpController
{
    private PopUpView popUpView;
    private ChestController chestController;
    public PopUpController(PopUpView popUpView)
    {
        this.popUpView = popUpView;
        popUpView.SetController(this);
    }

    private void SetPopUpOpen(CanvasGroup popUp)
    {
        popUp.alpha = 1;
        popUp.blocksRaycasts = true;
        popUp.interactable = true;
    }

    private void SetPopUpClose(CanvasGroup popUp)
    {
        popUp.alpha = 0;
        popUp.blocksRaycasts = false;
        popUp.interactable = true;
    }

    public void CloseRewardPopUp()
    {
        CanvasGroup popUp = popUpView.GetRewardPopUp();
        SetPopUpClose(popUp);
    }

    public void OpenRewardPopUp()
    {
        CanvasGroup popUp = popUpView.GetRewardPopUp();
        SetPopUpOpen(popUp);
    }


    public void CloseChestFullAlertPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestFullAlertPopUp();
        SetPopUpClose(popUp);
    }
    public void OpenChestFullAlertPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestFullAlertPopUp();
        SetPopUpOpen(popUp);
    }

    public void OpenChestUnlockPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestUnlockSectionPopUp();
        SetPopUpOpen(popUp);
    }

    public void CloseChestUnlockPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestUnlockSectionPopUp();
        SetPopUpClose(popUp);
    }

    public void OpenChestUnlockingPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestUnlockingPopUp();
        SetPopUpOpen(popUp);
    }

    public void CloseChestUnlockingPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestUnlockingPopUp();
        SetPopUpClose(popUp);
    }

    public void SetCurrentChestController(ChestController chestController) => this.chestController = chestController;

    public void OnCoinsButtonClicked()
    {
        //do this after implementing coins in chestcontroller
        int currentCoinAmount = GameService.Instance.UIService.GetCurrencyController().CoinAmount;
        if (chestController.chestData.ChestCoinPrice<= currentCoinAmount)
        {
            currentCoinAmount -= chestController.chestData.ChestCoinPrice;
            GameService.Instance.UIService.GetCurrencyController().SetCoinAmount(currentCoinAmount);
            chestController.chestStateMachine.ChangeState(ChestStates.UNLOCKING);
            CloseChestUnlockPopUp();
        }
    }

    public void OnGemsButtonClicked()
    {
        int currentGemAmount= GameService.Instance.UIService.GetCurrencyController().GemAmount;
        if(chestController.GetGemCurrentPrice() <= currentGemAmount)
        {
            currentGemAmount-= chestController.GetGemCurrentPrice();
            GameService.Instance.UIService.GetCurrencyController().SetGemAmount(currentGemAmount);
            chestController.chestStateMachine.ChangeState(ChestStates.UNLOCKED);
            CloseChestUnlockingPopUp();
            CloseChestUnlockPopUp();

        }
    }

    public void SetRewardPopUpText(int coinAmount,int gemAmount)
    {
        TextMeshProUGUI rewardPopUpText=popUpView.getRewardPopUpText();
        rewardPopUpText.text = "You Found " + coinAmount + " coins " + gemAmount + " gems in the chest";
    }
}
