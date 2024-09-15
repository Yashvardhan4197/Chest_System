
using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestService
{
    private Dictionary<ChestTypes, ChestScriptableObject> chestData=new Dictionary<ChestTypes, ChestScriptableObject>();
    private List<ChestView> ChestsSlots=new List<ChestView>();
    private List<ChestController> EarnedChests=new List<ChestController>();
    private Queue<IState>QueueForChest=new Queue<IState>();
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
            if (ChestsSlots[i].GetChestType() == ChestTypes.None)
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


    public List<ChestController> ReturnChests() => EarnedChests;
    public void AddToQueue(ChestController chestController)
    {
        QueueForChest.Enqueue(chestController.chestStateMachine.currentState);
        foreach(ChestController controller in ReturnChests())
        {
            if (controller.chestStateMachine.currentState.currentChestState == ChestStates.UNLOCKING)
            {
                return;
            }
        }
        QueueForChest.Peek().Owner.chestStateMachine.ChangeState(ChestStates.UNLOCKING);
    }

    public void TransitionStatetoUnlocking()
    {
        if(QueueForChest.Count > 0&& QueueForChest.Peek().currentChestState == ChestStates.UNLOCKING)
        {
            return;
        }
        while(QueueForChest.Count > 0&&QueueForChest.Peek().currentChestState!=ChestStates.UNLOCKINGQUEUE&& QueueForChest.Peek().currentChestState != ChestStates.UNLOCKING)
        {
            QueueForChest.Dequeue();
        }
        if(QueueForChest.Count ==0)
        {
            return;
        }
        QueueForChest.Peek().Owner.chestStateMachine.ChangeState(ChestStates.UNLOCKING);
    }

    public IState GetStateFromQueue()
    {

        return QueueForChest.Peek();
    }

    public bool IsQueueEmpty()
    {
        if(QueueForChest.Count == 0) return true;
        return false;
    }

    public void RemoveTopFromQueue()
    {
        if (IsQueueEmpty())
        {
            return;
        }
        QueueForChest.Dequeue();
        if (IsQueueEmpty()==false)
        {
            if (QueueForChest.Peek().Owner.chestStateMachine == null)
            {
                QueueForChest.Dequeue();
                return;
            }
            if (QueueForChest.Peek().Owner.chestStateMachine.currentState.currentChestState == ChestStates.UNLOCKED)
            {
                QueueForChest.Dequeue();
                return;
            }
            QueueForChest.Peek().Owner.chestStateMachine.ChangeState(ChestStates.UNLOCKING);
        }
    }
}
