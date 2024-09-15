using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnView : MonoBehaviour
{
    [SerializeField] Button SpawnChestButton;
    private SpawnController spawnController;

    private void Start()
    {
        SpawnChestButton.onClick.AddListener(SpawnChest);
    }

    private void SpawnChest()
    {
        spawnController.OnSpawnChestButtonClick();
        
    }

    public void SetController(SpawnController spawnController)=>this.spawnController=spawnController;
}
