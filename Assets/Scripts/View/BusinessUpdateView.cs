using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BusinessUpdateView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _profitMultiplier;
    [SerializeField] TextMeshProUGUI _cost;
    [SerializeField] Button _update;
    public Action BuyUpdate;

    public void Init(BusinessUpdateModel businessUpdateModel)
    {
        _name.text = $"{businessUpdateModel.Name}";
        _profitMultiplier.text = $"Доход: +{businessUpdateModel.ProfitMultiplier}%";
        _cost.text = $"Цена: {businessUpdateModel.Cost}$";
        _update.onClick.AddListener(() => {
            BuyUpdate?.Invoke();
            _update.interactable = false;
        });
        ButtonInteracteble(false);
    }

    public void ButtonInteracteble(bool isInteractable)
    {
        _update.interactable = isInteractable;
    }
}
