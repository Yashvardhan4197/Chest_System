
using UnityEngine;

[CreateAssetMenu(fileName ="newChest",menuName ="Chests")]
public class ChestScriptableObject : ScriptableObject
{
    public ChestTypes ChestType;
    public string ChestName;
    public Sprite ChestSprite;
    public int TimerValue;
}
