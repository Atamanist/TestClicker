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
        _money.text = $"Баланс: {value}$";
    }

    public void UpdateValue(float value)
    {
        _money.text = $"Баланс: {value}$";
    }
}
