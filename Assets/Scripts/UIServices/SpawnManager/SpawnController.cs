using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController
{
    private SpawnView spawnView;

    public SpawnController(SpawnView spawnView)
    {
        this.spawnView = spawnView;
        spawnView.SetController(this);
    }
    public void OnSpawnChestButtonClick()
    {
        if (GameService.Instance.chestService.ReturnChests().Count < GameService.Instance.ChestSlots)
        {
            GameService.Instance.chestService.SpawnChest();
        }
        else
        {
            GameService.Instance.UIService.GetPopUpController().OpenChestFullAlertPopUp();
        }
    }
}
