using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BussinesController : MonoBehaviour
{
    [SerializeField] private BusinessConfigSO _businessConfigSO;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private BusinessView _businessView;
    [SerializeField] private WalletView _walletView;

    private BusinessModel[] _businessModels;
    private List<BusinessView> _businessViews = new List<BusinessView>();
    private WalletModel _walletModel = new WalletModel();

    public void Start()
    {
        Init();
        CreateBusiness();
    }

    public void Update()
    {
        for (int i = 0; i < _businessViews.Count; i++)
        {
            if (_businessModels[i].Time >= _businessModels[i].ProfitTimer)
            {
                _businessModels[i].ClearTime();
                _walletModel.Money += _businessModels[i].Profit;
                _walletView.UpdateValue(_walletModel.Money);
            }

            _businessModels[i].UpdateProfitSlide(Time.deltaTime);

            _businessViews[i].UpdateValue(_businessModels[i]);
        }
    }

    public void Init()
    {
        _businessModels = new BusinessModel[_businessConfigSO.BussinessForScene.Length];
        for (int i = 0; i < _businessModels.Length; i++)
        {
            _businessModels[i] = new BusinessModel(_businessConfigSO.BussinessForScene[i]);
        }
    }

    public void CreateBusiness()
    {
        foreach (BusinessModel model in _businessModels)
        {
            var business = Instantiate(_businessView, _rectTransform);
            business.Init(model);
            business.BuyLvl = model.UpdateLevel;
            _businessViews.Add(business);
        }
    }


}
