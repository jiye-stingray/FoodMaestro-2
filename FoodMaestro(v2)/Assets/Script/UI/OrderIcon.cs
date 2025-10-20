using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderIcon : MonoBehaviour
{
    [SerializeField] Image _icon;
    [SerializeField] TMP_Text _valueTxt;

    Userinfo userinfo => Managers.Instance.GetUserinfo();

    public void Init(int foodId, int count)
    {
        gameObject.SetActive(true);

        FoodData data = Managers.Instance.GetDBManager().GetFooddata($"{userinfo._currentStageIndex}_{foodId}");
        _icon.sprite = data._sprite;
        _valueTxt.text = count.ToString();
    }
}
