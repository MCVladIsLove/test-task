using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HideOnInventoryOpened : MonoBehaviour
{
    [Inject] private PauseOnOpenInventory _pauser;

    private void Start()
    {
        _pauser.OnPause += () => gameObject.SetActive(false);
        _pauser.OnPauseDisabled += () => gameObject.SetActive(true);
    }

}
