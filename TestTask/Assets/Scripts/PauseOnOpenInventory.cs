using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOnOpenInventory : MonoBehaviour
{
    public event Action OnPause;
    public event Action OnPauseDisabled;

    public void Pause()
    {
        Time.timeScale = 0;
        OnPause?.Invoke();
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        OnPauseDisabled?.Invoke();
    }

}
