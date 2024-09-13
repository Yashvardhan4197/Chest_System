
using System.Collections.Generic;

public class ChestStateMachine
{
    private ChestController owner;
    private Dictionary<ChestStates, IState> States = new Dictionary<ChestStates, IState>();
    public IState currentState;
    public ChestStateMachine(ChestController owner)
    {
        this.owner = owner;
        CreateStates();
        SetOwner();

    }

    public void CreateStates()
    {
        States.Add(ChestStates.LOCKED,new LockedState(this));
        States.Add(ChestStates.UNLOCKING,new UnlockingState(this));
        States.Add(ChestStates.UNLOCKED,new UnlockedState(this));
        States.Add(ChestStates.COLLECTED,new CollectedState());
    }

    private void SetOwner()
    {
        foreach(ChestStates item in States.Keys)
        {
            States[item].Owner = owner;
        }
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(ChestStates newState)
    {
        currentState?.OnStateExit();
        currentState = States[newState];
        currentState?.OnStateEnter();
    }

}
