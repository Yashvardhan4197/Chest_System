using System;
using TMPro;

public class ChestController
{
    public ChestView chestView;
    public ChestScriptableObject chestData;
    public ChestStateMachine chestStateMachine;
    private TimeSpan chestTimeSpan;
    private int GemPrice;

    private static bool InQueue = true;
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
        chestStateMachine?.Update();
    }

    public void OnChestButtonPressed()
    {
        chestStateMachine.currentState.OnButtonPressed();
    }

    public string CalculateGemPrice(float timer)
    {
        float temp =timer / 10;
        int price=0;
        if (timer % 10 <= 5)
        {
            price = (int)temp;
        }
        else
        {
            price = (int)temp+1;
        }
        GemPrice= price;
        return price.ToString();
    }

    public void SetCanOpen(bool canOpen)
    {
        InQueue = canOpen;
    }

    public bool GetCanOpen() => InQueue;

    public int GetGemCurrentPrice()=>GemPrice;

    public void DestroyController()
    {
        chestStateMachine = null;
        chestView.SetController(null);
    }
}
