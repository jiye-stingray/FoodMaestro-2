using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FoodItemData 
{
    public int _id;
    public int _stageId;
    public FoodData data => Managers.Instance.GetDBManager().GetFooddata($"{_stageId}_{_id}");

    public bool _isOpen;

    public float _realTime => data._time - _reductionTime; // 실제 요리 제작 시간 
    public float _reductionTime;        // 감소될 시간
}
