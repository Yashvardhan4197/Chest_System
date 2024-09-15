using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{

    //Data
    [SerializeField] List<ChestScriptableObject> chestTypeData;
    [SerializeField] GameObject chestSlotPrefab;
    [SerializeField] RectTransform chestSlotParent;
    [SerializeField] int chestSlots;
    [SerializeField] AudioSource audioSource;
    [SerializeField] SoundTypes[] soundTypes;
    public int ChestSlots { get { return chestSlots; } }

    //Views
    [SerializeField] CurrencyView currencyView;
    [SerializeField] SpawnView spawnView;
    [SerializeField] PopUpView popUpView;
    [SerializeField] CommandView commandView;
    //Services
    public UIService UIService { get; private set; }
    public ChestService ChestService { get; private set; }
    public SoundManager SoundManager { get; private set; }
    public CommandController commandService { get; private set; }

    private void Start()
    {
        UIService=new UIService(currencyView,spawnView,popUpView);
        ChestService = new ChestService(chestTypeData,chestSlots,chestSlotPrefab,chestSlotParent);
        commandService = new CommandController(commandView);
        SoundManager = new SoundManager(audioSource, soundTypes);
    }
}
