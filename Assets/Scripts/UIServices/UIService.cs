
public class UIService
{
    //Controllers
    private CurrencyController currencyController;
    private SpawnController spawnController;
    private PopUpController popUpController;

    public UIService(CurrencyView currencyView,SpawnView spawnView,PopUpView popUpView,int startingCoinAmount,int startingGemAmount)
    {
        currencyController=new CurrencyController(currencyView,startingCoinAmount,startingGemAmount);
        spawnController = new SpawnController(spawnView);
        popUpController=new PopUpController(popUpView);
    }

    public CurrencyController GetCurrencyController() => currencyController;

    public SpawnController GetSpawnController() => spawnController;

    public PopUpController GetPopUpController() => popUpController;
}

