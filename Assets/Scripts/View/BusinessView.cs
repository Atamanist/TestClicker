using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

public class BusinessView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _profit;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] Button _updateLvl;
    [SerializeField] TextMeshProUGUI _updateLvlText;
    [SerializeField] Slider _profitSlider;
    [SerializeField] RectTransform _rectUpdateContent;
    [SerializeField] BusinessUpdateView _bussinesUpdatePrefab;
    public List<BusinessUpdateView> BusinessUpdateViews = new List<BusinessUpdateView>();
    public Action BuyLvl;
    public Action<int> BuyUpdateIndex;

    public void Init(BusinessModel businessModel)
    {
        _name.text = $"{businessModel.Name}";
        _profit.text = $"Доход\n{businessModel.Profit}$";
        _level.text = $"LVL\n{businessModel.LevelValue}";
        _updateLvlText.text = $"LVL UP\nЦена: {businessModel.Cost}$";
        _updateLvl.onClick.AddListener(() => { BuyLvl?.Invoke(); });
        _profitSlider.value = businessModel.ProfitSlideValue;

        for (int i = 0; i < businessModel.BusssinesUpdates.Length; i++)
        {
            var business = Instantiate(_bussinesUpdatePrefab, _rectUpdateContent);
            business.Init(businessModel.BusssinesUpdates[i],i);
            BusinessUpdateViews.Add(business);
        }
    }

    public void UpdateValue(BusinessModel businessModel)
    {
        _name.text = $"{businessModel.Name}";
        _profit.text = $"Доход\n{businessModel.Profit}$";
        _level.text = $"LVL\n{businessModel.LevelValue}";
        _updateLvlText.text = $"LVL UP\nЦена: {businessModel.Cost}$";
        _profitSlider.value = businessModel.ProfitSlideValue;
    }

    public void ButtonInteractable(bool isInteractable)
    {
        _updateLvl.interactable = isInteractable;
    }
}