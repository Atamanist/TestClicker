using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessModel
{
    public string Name { private set; get; }
    public float ProfitTimer { private set; get; }
    public int BaseCost { private set; get; }
    public int Cost { private set; get; }
    public int BaseProfit { private set; get; }
    public float Profit { private set; get; }
    public float ProfitSlideValue { private set; get; }
    public int LevelValue { private set; get; }
    public BusinessUpdateModel[] BusssinesUpdates { private set; get; }
    public float Time { private set; get; }

    public BusinessModel(BusinessSO businessSO)
    {
        Name = businessSO.Name;
        ProfitTimer = businessSO.ProfitTimer;
        BaseCost = businessSO.BaseCost;
        BaseProfit = businessSO.BaseProfit;
        LevelValue = businessSO.BaseLvl;
        BusssinesUpdates = new BusinessUpdateModel[businessSO.BusssinesUpdates.Length];
        for (int i = 0; i < BusssinesUpdates.Length; i++)
        {
            BusssinesUpdates[i] = new BusinessUpdateModel(businessSO.BusssinesUpdates[i]);
        }

        UpdateProfit();
        Cost = (LevelValue + 1) * BaseCost;
    }

    public void UpdateFromData(BusinessData businessData)
    {
        LevelValue = businessData.LevelValue;
        Time = businessData.Time;
        for (int i = 0; i < BusssinesUpdates.Length&&i<businessData.BusssinesUpdates.Length; i++)
        {
            if (businessData.BusssinesUpdates[i].IsBuyed)
            {
                BusssinesUpdates[i].BuyUpdate();
            }
        }
        UpdateProfit();
        Cost = (LevelValue + 1) * BaseCost;
    }

    public void UpdateLevel()
    {
        LevelValue++;
        Cost = (LevelValue + 1) * BaseCost;
        UpdateProfit();
    }

    private void UpdateProfit()
    {
        Profit = LevelValue * BaseProfit * (1 + ProfitMultiplayer());
    }

    public void UpdateTime(float time)
    {
        Time += time;
        ProfitSlideValue = (100 / ProfitTimer) * Time;
    }

    public void ClearTime()
    {
        Time = 0;
    }

    private float ProfitMultiplayer()
    {
        float i = 0;
        foreach (BusinessUpdateModel BusinessUpdate in BusssinesUpdates)
        {
            if (BusinessUpdate.IsBuyed)
                i = +(float) BusinessUpdate.ProfitMultiplier / (float) 100;
        }

        return i;
    }

    public void BuyUpdate(int i)
    {
        BusssinesUpdates[i].BuyUpdate();
        UpdateProfit();
    }
}