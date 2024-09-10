
public class UIService
{
    //Controllers
    private CurrencyController currencyController;
    public UIService(CurrencyView currencyView)
    {
        currencyController=new CurrencyController(currencyView);
    }

    public CurrencyController GetCurrencyController() => currencyController;
}

