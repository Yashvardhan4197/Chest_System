
public class UnlockingQueueState : IState
{
    public ChestController Owner { get; set; }
    public ChestStates currentChestState { get; set; }

    public UnlockingQueueState(ChestStates currentChestState)
    {
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
        Owner.SetInQueueText(true);
        GameService.Instance.SoundManager.PlaySound(Sound.UNLOCKING_QUEUE);
    }

    private void InitializeData()
    {
        Owner.SetChestImage(Owner.chestData.UnlockingQueueSprite);
        Owner.SetChestName(Owner.chestData.ChestName);
        Owner.SetChestPrice(Owner.chestData.ChestCoinPrice.ToString(), Owner.GetGemCurrentPrice().ToString());
        Owner.SetChestType(Owner.chestData.ChestType);
        Owner.UpdateCurrentTime();
        Owner.UpdateSlot();
    }

    public void OnStateExit()
    {
        Owner.SetInQueueText(false);
    }

    public void Update()
    {
    }
}
