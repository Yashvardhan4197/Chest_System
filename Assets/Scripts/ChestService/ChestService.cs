using System.Collections;
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

    public void Spawn

    public ChestController GetChestController()=>chestController;
}
