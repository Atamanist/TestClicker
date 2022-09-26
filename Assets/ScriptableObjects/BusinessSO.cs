using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BussinesTemplate", menuName = "ScriptableObjects/BussinesScriptableObject", order = 1)]
public class BusinessSO : ScriptableObject
{
    public string Name;
    public int ProfitTimer;
    public int BaseCost;
    public int BaseProfit;
    public BusinessUpdate[] BusssinesUpdates;
}

[Serializable]
public class BusinessUpdate
{
    public string Name;
    public int Cost;
    public int ProfitMultiplier;
}