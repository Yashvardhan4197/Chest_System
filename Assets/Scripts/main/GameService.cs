using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{

    //Data
    [SerializeField] List<ChestScriptableObject> chestTypeData;
    [SerializeField] GameObject chestSlotPrefab;
    [SerializeField] RectTransform chestSlotParent;
    [SerializeField] int chestSlots = 1;

    //Views
    [SerializeField] CurrencyView currencyView;

    //Services
    public UIService UIService;
    public ChestService chestService;
    private void Start()
    {
        UIService=new UIService(currencyView);
        chestService = new ChestService(chestTypeData,chestSlots,chestSlotPrefab,chestSlotParent);
    }
}
