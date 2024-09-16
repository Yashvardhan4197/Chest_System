
using UnityEngine;
using TMPro;
public class CurrencyView : MonoBehaviour
{
    private CurrencyController currencyController;
    [SerializeField] TextMeshProUGUI coinAmountText;
    [SerializeField] TextMeshProUGUI gemAmountText;

    public void UpdateCoinAmountText(int coinAmount)
    {
        coinAmountText.text = coinAmount.ToString();
    }

    public void UpdateGemAmountText(int gemAmount)
    {
        gemAmountText.text = gemAmount.ToString();
    }

    public void SetController(CurrencyController currencyController)=>this.currencyController = currencyController;

}
