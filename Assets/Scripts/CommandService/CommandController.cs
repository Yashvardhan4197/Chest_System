using System.Collections.Generic;

public class CommandController
{
    private Stack<IState> states;
    private CommandView commandView;
    public CommandController(CommandView commandView)
    {
        states = new Stack<IState>();
        this.commandView = commandView;
        commandView.SetCommandService(this);
    }


    public void InvokeState(IState newState)
    {
        states.Push(newState);
        newState.Owner.chestStateMachine.ChangeState(ChestStates.UNLOCKED);
    }

    public void Undo()
    {
        if(states.Count > 0)
        {
            IState topState= states.Pop();
            while(states.Count>0&& topState.Owner.chestStateMachine == null)
            {
                topState=states.Pop();
            }
            if (topState.Owner.chestStateMachine!=null)//topState.Owner.chestStateMachine.currentState.currentChestState != ChestStates.COLLECTED)
            {
                int currentGemAmount = GameService.Instance.UIService.GetCurrencyController().GemAmount;
                currentGemAmount += topState.Owner.GetGemCurrentPrice();
                GameService.Instance.UIService.GetCurrencyController().SetGemAmount(currentGemAmount);
                topState.Owner.chestStateMachine.ChangeState(topState.currentChestState);
            }
        }
    }

}
