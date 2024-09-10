using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService
{
    private ChestController chestController;
    public ChestService(ChestView chestView)
    {
        chestController= new ChestController(chestView);
    }

    public ChestController GetChestController()=>chestController;
}
