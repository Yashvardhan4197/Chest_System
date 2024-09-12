using System;
using TMPro;

public class ChestController
{
    public ChestView chestView;
    public ChestScriptableObject chestData;
    private ChestStateMachine chestStateMachine;
    private TimeSpan chestTimeSpan;
    public ChestController(ChestView chestView,ChestScriptableObject chestData)
    {
        this.chestView = chestView;
        this.chestData = chestData;
        chestView.SetController(this);
        chestStateMachine =new ChestStateMachine(this);
        chestStateMachine.ChangeState(ChestStates.LOCKED);
        //InitializeData();
    }

    public void SetTimer(TextMeshProUGUI timerUI, float timerTime)
    {
        chestTimeSpan=TimeSpan.FromSeconds(timerTime);
        timerUI.text = string.Format("{0:D2}:{1:D2}:{2:D2}", chestTimeSpan.Hours, chestTimeSpan.Minutes, chestTimeSpan.Seconds);
    }

    public void Update()
    {
        chestStateMachine.Update();
    }

    public void OnChestButtonPressed()
    {
        chestStateMachine.currentState.OnButtonPressed();
    }
}
