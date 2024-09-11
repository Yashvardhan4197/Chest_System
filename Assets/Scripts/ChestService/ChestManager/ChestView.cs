using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour
{
    private bool isFilled;
    private ChestController chestController=null;
    [SerializeField] CanvasGroup ChestObjectCanvasGroup;

    private void Start()
    {
        SetSlot();
    }

    private void SetSlot()
    {
        if (chestController == null)
        {
            isFilled = false;
            ChestObjectCanvasGroup.alpha = 0;
        }
    }
}
