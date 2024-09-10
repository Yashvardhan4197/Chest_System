using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    //Views
    [SerializeField] CurrencyView currencyView;

    //Services
    public UIService UIService;
    public ChestService chestService;
    private void Start()
    {
        UIService=new UIService(currencyView);
    }
}
