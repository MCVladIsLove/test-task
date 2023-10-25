using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttackButton : MonoBehaviour
{
    [Inject] private PauseOnOpenInventory _pauser;

    public Button Btn { get; private set; }

    private void Awake()
    {
        Btn = GetComponent<Button>();
    }
}
