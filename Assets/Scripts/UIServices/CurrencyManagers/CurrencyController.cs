
public class CurrencyController
{
    private CurrencyView currencyView;

    private int coinAmount;
    private int gemAmount;

    public int CoinAmount { get { return coinAmount; } }
    public int GemAmount { get { return gemAmount; } }
    public CurrencyController(CurrencyView currencyView)
    {
        this.currencyView = currencyView;
        SetCoinAmount(100);
        SetGemAmount(10);
    }

    public void SetCoinAmount(int coinAmount)
    {
        this.coinAmount = coinAmount;
        currencyView.UpdateCoinAmountText(coinAmount);
    }

    public void SetGemAmount(int gemAmount)
    {
        this.gemAmount = gemAmount;
        currencyView.UpdateGemAmountText(gemAmount);
    }



}
