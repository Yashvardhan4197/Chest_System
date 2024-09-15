
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
        currencyView.SetController(this);
        currencyView.SetStartingData();
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
