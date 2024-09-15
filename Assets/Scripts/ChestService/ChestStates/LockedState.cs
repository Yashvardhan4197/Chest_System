
public class LockedState : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine stateMachine;
    public ChestStates currentChestState { get; set; }


    public LockedState(ChestStateMachine chestStateMachine,ChestStates chestState)
    {
        stateMachine = chestStateMachine;
        currentChestState = chestState;
    }

    public void OnStateEnter()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.LockedChestSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetTimerValue(Owner.chestData.TimerValue);
        Owner.chestView.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(),Owner.CalculateGemPrice(Owner.chestData.TimerValue));
        Owner.chestView.SetChestType(Owner.chestData.ChestType);
        Owner.chestView.UpdateSlot();
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
