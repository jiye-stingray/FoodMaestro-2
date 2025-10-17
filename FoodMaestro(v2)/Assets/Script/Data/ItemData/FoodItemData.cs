using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FoodItemData 
{
    public int _id;
    public int _stageId;
    public FoodData data => Managers.Instance.GetDBManager().GetFooddata($"{data._stageID}_{data._id}");

    public bool _isOpen;

    
}
