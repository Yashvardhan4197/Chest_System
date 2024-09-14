
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpView : MonoBehaviour
{
    private PopUpController popUpController;
    [SerializeField] CanvasGroup ChestAlertPopUp;
    [SerializeField] Button ChestFullAlertCloseButton;

    [SerializeField] CanvasGroup ChestUnlockPopUp;
    [SerializeField] Button OpenWithCoinsButton;
    [SerializeField] Button OpenWithGemsButton;
    [SerializeField] Button CloseChestUnlockButton;

    [SerializeField] CanvasGroup ChestUnlockingPopUp;
    [SerializeField] Button InstantGemButton;
    [SerializeField] Button CloseUnlockingPopUp;

    [SerializeField] CanvasGroup RewardPopUp;
    [SerializeField] TextMeshProUGUI RewardPopUpText;
    [SerializeField] Button CloseRewardPopUp;

    private void Start()
    {
        ChestFullAlertCloseButton.onClick.AddListener(ChestFullAlertButtonPressed);

        OpenWithCoinsButton.onClick.AddListener(OnCoinButtonClicked);
        OpenWithGemsButton.onClick.AddListener(OnGemsButtonClicked);
        CloseChestUnlockButton.onClick.AddListener(CloseChestUnlockSection);

        InstantGemButton.onClick.AddListener(OnGemsButtonClicked);
        CloseUnlockingPopUp.onClick.AddListener(CloseChestUnlockingSection);

        CloseRewardPopUp.onClick.AddListener(CloseRewardPopUpSection);

    }

    private void AddToPopUpList()
    {
        popUpController.AddPopUps(RewardPopUp);
        popUpController.AddPopUps(ChestUnlockingPopUp);
        popUpController.AddPopUps(ChestUnlockPopUp);
        popUpController.AddPopUps(ChestAlertPopUp);
    }

    private void CloseRewardPopUpSection()
    {
        popUpController.CloseRewardPopUp();
    }

    private void CloseChestUnlockingSection()
    {
        popUpController.CloseChestUnlockingPopUp();
    }

    private void OnGemsButtonClicked()
    {
        popUpController.OnGemsButtonClicked();
    }

    private void CloseChestUnlockSection()
    {
        popUpController.CloseChestUnlockPopUp();
    }

    private void OnCoinButtonClicked()
    {
        popUpController.OnCoinsButtonClicked();
    }

    private void ChestFullAlertButtonPressed()
    {
        popUpController.CloseChestFullAlertPopUp();
    }

    public void SetController(PopUpController popUpController)
    {
        this.popUpController = popUpController;
        AddToPopUpList();
    }   


    public CanvasGroup GetChestFullAlertPopUp() => ChestAlertPopUp;

    public CanvasGroup GetChestUnlockSectionPopUp() => ChestUnlockPopUp;

    public CanvasGroup GetChestUnlockingPopUp() => ChestUnlockingPopUp; 

    public CanvasGroup GetRewardPopUp() => RewardPopUp;

    public TextMeshProUGUI getRewardPopUpText() => RewardPopUpText;
}
