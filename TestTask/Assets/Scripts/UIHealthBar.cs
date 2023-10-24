using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private RectTransform _hpTransform;

    private void Awake()
    {
        _hpTransform = GetComponent<RectTransform>();
    }
    public void Refresh(float remaiedHpProcent)
    {
        _hpTransform.localScale = new Vector3(remaiedHpProcent, 1);
    }
}
