
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    private ChestController chestController=null;
    private ChestTypes chestType;
    [SerializeField] CanvasGroup chestObjectCanvasGroup;
    [SerializeField] Image chestImage;
    [SerializeField] TextMeshProUGUI chestName;
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] TextMeshProUGUI chestCoinPrice;
    [SerializeField] TextMeshProUGUI chestGemPrice;
    [SerializeField] GameObject InQueueImg;
    [SerializeField] Button ChestButton;
    
    private void Start()
    {
        ResetSlot();
        ChestButton.onClick.AddListener(ChestButtonPressed);
    }

    private void ChestButtonPressed()
    {
        chestController?.OnChestButtonPressed();
    }

    private void Update()
    {
        chestController?.Update();
    }

    public void ResetSlot()
    {
        chestController = null;
        chestType = ChestTypes.None;
        chestObjectCanvasGroup.alpha = 0;
    }

    public void SetController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void UpdateSlot()
    {
        chestObjectCanvasGroup.alpha = 1;
    }

    public void SetChestImage(Sprite chestImage)=>this.chestImage.sprite = chestImage;

    public void SetChestName(string chestName)=>this.chestName.text= chestName;

    public void SetChestPrice(string coinPrice, string gemPrice)
    {
        chestCoinPrice.text = coinPrice;
        chestGemPrice.text = gemPrice;
    }

    public void SetTimerValue(float timerValue)
    {
        chestController?.SetTimer(timerUI, timerValue);
    }

    public void SetInQueueText(bool set)=>InQueueImg.SetActive(set);

    public void SetChestType(ChestTypes chestType)=>this.chestType = chestType;

    public ChestTypes GetChestType() => chestType;

}
