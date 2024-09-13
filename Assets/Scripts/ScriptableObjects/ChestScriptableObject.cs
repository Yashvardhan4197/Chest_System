
using UnityEngine;

[CreateAssetMenu(fileName ="newChest",menuName ="Chests")]
public class ChestScriptableObject : ScriptableObject
{
    public ChestTypes ChestType;
    public string ChestName;
    public Sprite LockedChestSprite;
    public Sprite UnlockingChestSprite;
    public Sprite UnlockedChestSprite;
    public int TimerValue;
    public int ChestCoinPrice;
}
