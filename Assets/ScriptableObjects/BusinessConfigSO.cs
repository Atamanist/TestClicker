using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BussinesConfigTemplate", menuName = "ScriptableObjects/BussinesConfigScriptableObject", order = 2)]
public class BusinessConfigSO : ScriptableObject
{
    public BusinessSO[] BussinessForScene;
}
