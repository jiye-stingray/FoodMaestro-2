using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    private Dictionary<string, FoodData> _dicFoodData = new Dictionary<string, FoodData>();

    public int _stageCount = 1;     

    public void DBLoad()
    {
        InitFoodData();
    }

    private void InitFoodData()
    {
        FoodData[] foodDatas = Managers.Instance.GetResourceObjectManager().LoadAll<FoodData>("ScriptableObject");
        foreach (var foodData in foodDatas)
        {
            _dicFoodData[$"{foodData._stageID}_{foodData._id}"] = foodData;
        }

    }

    public Dictionary<string, FoodData> GetFoodDB()
    {
        return _dicFoodData;
    }

    public FoodData GetFooddata(string id)
    {
        return _dicFoodData[id];
    }

}
