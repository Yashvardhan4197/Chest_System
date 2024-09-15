
using UnityEngine;
using TMPro;
public class CurrencyView : MonoBehaviour
{
    private CurrencyController currencyController;
    [SerializeField] TextMeshProUGUI coinAmountText;
    [SerializeField] TextMeshProUGUI gemAmountText;
    [SerializeField] int startingCoinAmount;
    [SerializeField] int startingGemAmount;

    public void UpdateCoinAmountText(int coinAmount)
    {
        coinAmountText.text = coinAmount.ToString();
    }

    public void UpdateGemAmountText(int gemAmount)
    {
        gemAmountText.text = gemAmount.ToString();
    }

    public void SetController(CurrencyController currencyController)=>this.currencyController = currencyController;

    public void SetStartingData()
    {
        currencyController.SetCoinAmount(startingCoinAmount);
        currencyController.SetGemAmount(startingGemAmount);
    }
}
