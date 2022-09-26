using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WalletView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _money;

    public void Init(int value)
    {
        _money.text = $"������: {value}$";
    }

    public void UpdateValue(int value)
    {
        _money.text = $"������: {value}$";
    }
}
