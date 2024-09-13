using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LockedState : IState
{
    public ChestController Owner { get; set; }
    private ChestStateMachine stateMachine;

    public LockedState(ChestStateMachine chestStateMachine)
    {
        stateMachine = chestStateMachine;
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
        Owner.chestView.chestType = Owner.chestData.ChestType;
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
        if (Owner.GetCanOpen())
        {
            GameService.Instance.UIService.GetPopUpController().OpenChestUnlockPopUp();
            GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
        }
        //stateMachine.ChangeState(ChestStates.UNLOCKING);
    }
}
