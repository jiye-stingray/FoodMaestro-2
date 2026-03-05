using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="FoodData")]
public class FoodData : ScriptableObject
{
    public int _id;
    public int _stageID;
    public string _name;
    public Sprite _sprite;
    public float _time;
    public int _price;  // 판매 가격 (손님이 음식 받을 때 플레이어에게 지급)
}
