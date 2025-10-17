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
}
