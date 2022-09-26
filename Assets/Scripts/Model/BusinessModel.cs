using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessModel
{
    public string Name { private set; get; }
    public float ProfitTimer { private set; get; }
    public int BaseCost { private set; get; }
    public int BaseProfit { private set; get; }
    public int Profit { private set; get; }

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
        BusssinesUpdates = new BusinessUpdateModel[businessSO.BusssinesUpdates.Length];
        for (int i = 0; i < BusssinesUpdates.Length; i++)
        {
            BusssinesUpdates[i] = new BusinessUpdateModel(businessSO.BusssinesUpdates[i]);
        }

        Profit = BaseProfit;
    }

    public void UpdateLevel()
    {
        LevelValue++;
        Profit = LevelValue * BaseProfit;
    }

    public void UpdateProfitSlide(float time)
    {
        Time += time;
        ProfitSlideValue = (100 / ProfitTimer)*Time;
    }

    public void ClearTime()
    {
        Time = 0;
    }


    public void BuyUpdate()
    {

    }

}
