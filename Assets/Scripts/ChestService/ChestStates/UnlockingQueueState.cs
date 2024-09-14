
public class UnlockingQueueState : IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }

    private ChestStateMachine stateMachine;

    public UnlockingQueueState(ChestStateMachine stateMachine, ChestStates currentChestState)
    {
        this.stateMachine = stateMachine;
        this.currentChestState = currentChestState;
    }

    public void OnButtonPressed()
    {
        GameService.Instance.UIService.GetPopUpController().OpenChestUnlockPopUp();
        GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
    }

    public void OnStateEnter()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockingQueueSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetTimerValue(Owner.chestData.TimerValue);
        Owner.chestView.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(), Owner.CalculateGemPrice(Owner.chestData.TimerValue));
        Owner.chestView.chestType = Owner.chestData.ChestType;
        Owner.chestView.UpdateSlot();
    }

    public void OnStateExit()
    {
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        if (Owner.GetCanOpen())
        {
            Owner.SetCanOpen(false);
            stateMachine.ChangeState(ChestStates.UNLOCKING);
        }

        //throw new System.NotImplementedException();
    }
}
