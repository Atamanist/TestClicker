using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessUpdateModel
{
    public string Name { private set; get; }
    public int Cost { private set; get; }
    public int ProfitMultiplier { private set; get; }
    public bool IsBuyed { private set; get; }

    public BusinessUpdateModel(BusinessUpdate businessUpdate)
    {
        Name = businessUpdate.Name;
        Cost = businessUpdate.Cost;
        ProfitMultiplier = businessUpdate.ProfitMultiplier;
    }

    public void BuyUpdate()
    {
        IsBuyed = true;
    }

}
