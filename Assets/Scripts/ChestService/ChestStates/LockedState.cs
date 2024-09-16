
public class LockedState : IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }


    public LockedState(ChestStates chestState)
    {
        currentChestState = chestState;
    }

    public void OnStateEnter()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        Owner.SetChestImage(Owner.chestData.LockedChestSprite);
        Owner.SetChestName(Owner.chestData.ChestName);
        Owner.SetTimerValue(Owner.chestData.TimerValue);
        Owner.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(),Owner.CalculateGemPrice(Owner.chestData.TimerValue));
        Owner.SetChestType(Owner.chestData.ChestType);
        Owner.UpdateSlot();
    }

    public void OnStateExit()
    {
        //throw new NotImplementedException();
    }

    public void Update()
    {
        //throw new NotImplementedException();
    }

    public void OnButtonPressed()
    {
            GameService.Instance.UIService.GetPopUpController().OpenChestUnlockPopUp();
            GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
    }
}
