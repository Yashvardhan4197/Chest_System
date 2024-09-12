using System;
using TMPro;

public class ChestController
{
    public ChestView chestView;
    private ChestScriptableObject chestData;
    private TimeSpan chestTimeSpan;
    public ChestController(ChestView chestView,ChestScriptableObject chestData)
    {
        this.chestView = chestView;
        this.chestData = chestData;
        InitializeData();
    }

    private void InitializeData()
    {
        chestView.SetController(this);
        chestView.SetChestImage(chestData.ChestSprite);
        chestView.SetChestName(chestData.ChestName);
        chestView.SetTimerValue(chestData.TimerValue);
        chestView.chestType = chestData.ChestType;
        chestView.UpdateSlot();
    }


    public void SetTimer(TextMeshProUGUI timerUI, float timerTime)
    {
        chestTimeSpan=TimeSpan.FromSeconds(timerTime);
        timerUI.text = string.Format("{0:D2}:{1:D2}:{2:D2}", chestTimeSpan.Hours, chestTimeSpan.Minutes, chestTimeSpan.Seconds);
    }
}
