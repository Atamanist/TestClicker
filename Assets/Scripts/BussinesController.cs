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
    private SaveSystem _saveSystem = new SaveSystem();

    public void Start()
    {
        Init();
        if (_saveSystem.CheckSaveFile())
        {
            GameData gameData = _saveSystem.LoadFile();
            for (int i = 0; i < _businessModels.Length&& i < gameData.BusinessDatas.Length; i++)
            {
                _businessModels[i].UpdateFromData(gameData.BusinessDatas[i]);
            }
            _walletModel.Money = gameData.Money;
        }
        CreateBusiness();
    }

    public void Update()
    {
        GameTick();
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        if (_businessModels != null)
        {
            _saveSystem.SaveFile(_businessModels,_walletModel.Money);
        }
    }

    public void OnApplicationQuit()
    {
        if (_businessModels != null)
        {
            _saveSystem.SaveFile(_businessModels,_walletModel.Money);
        }
    }

    private void GameTick()
    {
        for (int i = 0; i < _businessViews.Count; i++)
        {
            CheckForProfit(i);
            CheckForBuy(i);
            if (_businessModels[i].LevelValue > 0)
            {
                _businessModels[i].UpdateTime(Time.deltaTime);
                _businessViews[i].UpdateValue(_businessModels[i]);
            }
        }
    }

    private void CheckForProfit(int i)
    {
        if (_businessModels[i].Time >= _businessModels[i].ProfitTimer)
        {
            _businessModels[i].ClearTime();
            _walletModel.Money += _businessModels[i].Profit;
            _walletView.UpdateValue(_walletModel.Money);
        }
    }

    private void CheckForBuy(int i)
    {
        _businessViews[i].ButtonInteractable(_walletModel.Money >= _businessModels[i].Cost);
        for (int j = 0; j < _businessViews[i].BusinessUpdateViews.Count; j++)
        {
            if (!_businessModels[i].BusssinesUpdates[j].IsBuyed)
            {
                _businessViews[i].BusinessUpdateViews[j]
                    .ButtonInteracteble(_walletModel.Money >= _businessModels[i].BusssinesUpdates[j].Cost);
            }
        }
    }

    public void Init()
    {
        _businessModels = new BusinessModel[_businessConfigSO.BussinessForScene.Length];
        for (int i = 0; i < _businessModels.Length; i++)
        {
            _businessModels[i] = new BusinessModel(_businessConfigSO.BussinessForScene[i]);
        }
        _walletModel.Money = 0;
    }

    public void CreateBusiness()
    {
        foreach (BusinessModel model in _businessModels)
        {
            var business = Instantiate(_businessView, _rectTransform);
            business.Init(model);
            business.BuyLvl =()=>
            {
                _walletModel.Money -=model.Cost;
                _walletView.UpdateValue(_walletModel.Money);
                model.UpdateLevel();
            };
            for (int i = 0; i < business.BusinessUpdateViews.Count; i++)
            {
                business.BusinessUpdateViews[i].BuyUpdate =(value)=>
                {
                    _walletModel.Money -= model.Cost;
                    _walletView.UpdateValue(_walletModel.Money);
                    model.BuyUpdate(value);
                };
            }
            _businessViews.Add(business);
        }
        _walletView.UpdateValue(_walletModel.Money);
    }
}