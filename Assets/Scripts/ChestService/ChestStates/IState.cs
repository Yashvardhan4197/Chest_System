using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IState
{
    public ChestController Owner { get; set; }
    public void OnStateEnter();
    public void OnStateExit();
    public void Update();

    public void OnButtonPressed();
}
