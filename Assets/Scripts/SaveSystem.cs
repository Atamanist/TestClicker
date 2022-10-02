using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem 
{
    public void SaveFile(BusinessModel[] businessModels,float money)
    {
        string path = Path.Combine(Application.persistentDataPath,"SaveData");

        GameData gameData = new GameData(businessModels,money);
        
        string json=JsonUtility.ToJson(gameData);

        using (FileStream stream=new FileStream(path,FileMode.Create))
        {
            using (StreamWriter writer=new StreamWriter(stream) )
            {
                writer.Write(json);
            }
        }
    }

    public bool CheckSaveFile()
    {
        string path = Path.Combine(Application.persistentDataPath,"SaveData");

        return File.Exists(path);
    }
    
    public GameData LoadFile()
    {
        string path = Path.Combine(Application.persistentDataPath,"SaveData");

        string data = "";
        using (FileStream stream=new FileStream(path,FileMode.Open))
        {
            using (StreamReader reader=new StreamReader(stream) )
            {
                data = reader.ReadToEnd();
            }
        }

        GameData gameData = JsonUtility.FromJson<GameData>(data);
        return gameData;
    }
}
[Serializable]
public class GameData
{
    public float Money;
    public BusinessData[] BusinessDatas;

    public GameData(BusinessModel[] businessModels, float money)
    {
        Money = money;
        BusinessDatas = new BusinessData[businessModels.Length];
        for (int i = 0; i < BusinessDatas.Length; i++)
        {
            BusinessDatas[i] = new BusinessData(businessModels[i]);
        }
    }
}

[Serializable]
public class BusinessData
{
    public int LevelValue;
    public float Time;
    public BusinessUpdateData[] BusssinesUpdates;

    public BusinessData(BusinessModel businessModel)
    {
        LevelValue = businessModel.LevelValue;
        Time = businessModel.Time;
        BusssinesUpdates = new BusinessUpdateData[businessModel.BusssinesUpdates.Length];
        for (int i = 0; i < BusssinesUpdates.Length; i++)
        {
            BusssinesUpdates[i] = new  BusinessUpdateData(businessModel.BusssinesUpdates[i].IsBuyed);
        }
    }
}

[Serializable]
public class BusinessUpdateData
{
    public bool IsBuyed;

    public BusinessUpdateData(bool isBuyed)
    {
        IsBuyed = isBuyed;
    }
}
