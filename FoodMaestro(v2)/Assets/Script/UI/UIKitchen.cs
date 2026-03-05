using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIKitchen : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] TMP_Text _nameTxt;
    FoodData _foodData;
    public void SetFoodData(FoodData foodData)
    {
        _foodData = foodData;
        Refresh();
    }    

    public void Refresh()
    {
         _icon.sprite = _foodData._sprite;
        _nameTxt.text = _foodData._name;
    }
}
