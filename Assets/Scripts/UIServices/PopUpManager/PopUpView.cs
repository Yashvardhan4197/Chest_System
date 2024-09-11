
using UnityEngine;
using UnityEngine.UI;

public class PopUpView : MonoBehaviour
{
    private PopUpController popUpController;
    [SerializeField] CanvasGroup ChestAlertPopUp;
    [SerializeField] Button ChestFullAlertCloseButton;

    private void Start()
    {
        ChestFullAlertCloseButton.onClick.AddListener(ChestFullAlertButtonPressed);
    }

    private void ChestFullAlertButtonPressed()
    {
        popUpController.CloseChestFullAlertPopUp();
    }

    public void SetController(PopUpController popUpController)
    {
        this.popUpController = popUpController;
    }

    public CanvasGroup GetChestFullAlertPopUp() => ChestAlertPopUp;
}
