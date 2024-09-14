
public class UnlockingQueueState : IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }

    private ChestStateMachine stateMachine;
    private float timer;
    public UnlockingQueueState(ChestStateMachine stateMachine, ChestStates currentChestState)
    {
        this.stateMachine = stateMachine;
        this.currentChestState = currentChestState;
    }

    public void OnButtonPressed()
    {
        GameService.Instance.UIService.GetPopUpController().OpenChestUnlockingPopUp();
        GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
    }

    public void OnStateEnter()
    {
        InitializeData();
        Owner.chestView.SetInQueueText(true);
    }

    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockingQueueSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(), Owner.GetGemCurrentPrice().ToString());
        Owner.chestView.chestType = Owner.chestData.ChestType;
        Owner.UpdateCurrentTime();
        Owner.chestView.UpdateSlot();
    }

    public void OnStateExit()
    {
        Owner.chestView.SetInQueueText(false);
    }

    public void Update()
    {
    }
}
