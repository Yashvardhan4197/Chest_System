
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestService
{
    private ChestController chestController;
    private Dictionary<ChestTypes, ChestScriptableObject> chestData=new Dictionary<ChestTypes, ChestScriptableObject>();
    private List<ChestView> ChestsSlots=new List<ChestView>();
    private List<ChestController> EarnedChests=new List<ChestController>();

    public ChestService(List<ChestScriptableObject> chestSOList, int chestSlots, GameObject chestSlotPrefab, RectTransform ChestSlotParent)
    {
        SetChestData(chestSOList);
        SetChestSlots(chestSlotPrefab,chestSlots,ChestSlotParent);
    }

    private void SetChestData(List<ChestScriptableObject>chestSOList) 
    {
        for(int i=0;i<chestSOList.Count;i++)
        {
            chestData.Add(chestSOList[i].ChestType, chestSOList[i]);
        }
    }

    private void SetChestSlots(GameObject chestSlotPrefab,int chestSlots,RectTransform ChestSlotParent)
    {
        for(int i=0;i<chestSlots;i++)
        {
            GameObject newChestSlot= GameObject.Instantiate(chestSlotPrefab);
            newChestSlot.transform.SetParent(ChestSlotParent.transform);
            ChestsSlots.Add(newChestSlot.GetComponent<ChestView>());
        }
    }

    private ChestTypes GetRandomChestType()
    {
        int randIndex=UnityEngine.Random.Range(1,Enum.GetNames(typeof(ChestTypes)).Length);
        ChestTypes randomChest = (ChestTypes)randIndex;
        return randomChest;
    }

    public void SpawnChest()
    {
        int emptySlotIndex = -1;
        for (int i = 0; i < ChestsSlots.Count; i++)
        {
            if (ChestsSlots[i].chestType == ChestTypes.None)
            {
                emptySlotIndex = i;
                break;
            }
        }
        if (emptySlotIndex != -1)
        {
            ChestView currentChestView = ChestsSlots[emptySlotIndex];
            ChestController newChestController = new ChestController(currentChestView, chestData[GetRandomChestType()]);
            EarnedChests.Add(newChestController);
        }
    }

    public ChestController GetChestController()=>chestController;

    public List<ChestController> ReturnChests() => EarnedChests;


}
