using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AttackButton : MonoBehaviour
{
    public Button Btn { get; private set; }

    private void Awake()
    {
        Btn = GetComponent<Button>();
    }
}
