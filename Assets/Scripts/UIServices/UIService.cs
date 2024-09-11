
public class UIService
{
    //Controllers
    private CurrencyController currencyController;
    private SpawnController spawnController;
    private PopUpController popUpController;
    public UIService(CurrencyView currencyView,SpawnView spawnView,PopUpView popUpView)
    {
        currencyController=new CurrencyController(currencyView);
        spawnController = new SpawnController(spawnView);
        popUpController=new PopUpController(popUpView);
    }

    public CurrencyController GetCurrencyController() => currencyController;

    public SpawnController GetSpawnController() => spawnController;

    public PopUpController GetPopUpController() => popUpController;
}

