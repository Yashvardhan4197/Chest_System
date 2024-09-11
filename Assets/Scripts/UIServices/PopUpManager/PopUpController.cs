
using UnityEngine;

public class PopUpController
{
    private PopUpView popUpView;
    public PopUpController(PopUpView popUpView)
    {
        this.popUpView = popUpView;
        popUpView.SetController(this);
        //CloseChestFullAlertPopUp();
    }

    public void CloseChestFullAlertPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestFullAlertPopUp();
        popUp.alpha = 0;
        popUp.blocksRaycasts = false;
        popUp.interactable = true;
    }
    public void OpenChestFullAlertPopUp()
    {
        CanvasGroup popUp = popUpView.GetChestFullAlertPopUp();
        popUp.alpha = 1;
        popUp.blocksRaycasts = true;
        popUp.interactable = true;
    }
}
