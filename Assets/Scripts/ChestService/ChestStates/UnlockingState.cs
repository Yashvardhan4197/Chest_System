
using UnityEngine;

public class UnlockingState: IState
{
    private float timer;
    private bool timerRunning = true;
    private bool FirstTime = true;
    private float delaySound = 1;
    private float startSoundCount = 0;
    public ChestController Owner { get; set; }
    private ChestStateMachine stateMachine;
    public ChestStates currentChestState { get; set; }
    
    private void InitializeData()
    {
        Owner.chestView.SetChestImage(Owner.chestData.UnlockingChestSprite);
        Owner.chestView.SetChestName(Owner.chestData.ChestName);
        Owner.chestView.SetChestType(Owner.chestData.ChestType);
        Owner.chestView.UpdateSlot();
        if (FirstTime)
        {
            timer = Owner.chestData.TimerValue;
            FirstTime = false; 
        }
        
    }

    public UnlockingState(ChestStateMachine stateMachine,ChestStates chestState)
    {
        this.stateMachine = stateMachine;
        currentChestState = chestState;
        
    }

    public void OnButtonPressed()
    {
        GameService.Instance.UIService.GetPopUpController().OpenChestUnlockingPopUp();
        GameService.Instance.UIService.GetPopUpController().SetCurrentChestController(Owner);
    }

    public void OnStateEnter()
    {
        InitializeData();
        Owner.SetCanOpen(false);
        timerRunning =true;
        GameService.Instance.SoundManager.PlaySound(Sound.UNLOCKING_TIMER);

    }

    public void OnStateExit()
    {
        //throw new NotImplementedException();
    }

    public void Update()
    {
        if (timerRunning)
        {
            if (timer > 0)
            {
                StartTimer();
            }
            else
            {
                stateMachine.ChangeState(ChestStates.UNLOCKED);
            }
        }
        //throw new NotImplementedException();
    }

    private void StartTimer()
    {
        timer -= Time.deltaTime;
        Owner.SetCurrentTimer(timer);
        startSoundCount += Time.deltaTime;
        if (startSoundCount >= delaySound)
        {
            startSoundCount = 0;
            GameService.Instance.SoundManager.PlaySound(Sound.UNLOCKING_TIMER);
        }
    }

}
