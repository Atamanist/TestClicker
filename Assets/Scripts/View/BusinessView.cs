using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BusinessView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _profit;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] Button _updateLvl;
    [SerializeField] Slider _profitSlider;
    [SerializeField] RectTransform _rectUpdateContent;
    [SerializeField] BusinessUpdateView _bussinesUpdatePrefab;
    private List<BusinessUpdateView> _businessUpdateViews=new List<BusinessUpdateView>();
    public Action BuyLvl;

    public void Init(BusinessModel businessModel)
    {
        _name.text = $"{businessModel.Name}";
        _profit.text = $"Доход\n{businessModel.Profit}$";
        _level.text = $"LVL\n{businessModel.LevelValue}";
        _updateLvl.onClick.AddListener(() => {
            BuyLvl?.Invoke();
        });
        _profitSlider.value = businessModel.ProfitSlideValue;
        foreach(BusinessUpdateModel businessUpdateModel in businessModel.BusssinesUpdates)
        {
            var business = Instantiate(_bussinesUpdatePrefab, _rectUpdateContent);
            business.Init(businessUpdateModel);
            _businessUpdateViews.Add(business);
        }
    }

    public void UpdateValue(BusinessModel businessModel)
    {
        _name.text = $"{businessModel.Name}";
        _profit.text = $"Доход\n{businessModel.Profit}$";
        _level.text = $"LVL\n{businessModel.LevelValue}";
        _profitSlider.value=businessModel.ProfitSlideValue;
    }

}
