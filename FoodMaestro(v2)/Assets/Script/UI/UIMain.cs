using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class UIMain : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldText;

    private void Awake()
    {
        Managers.Instance.GetUserinfo().Gold
        .Subscribe(gold =>
        {
            _goldText.text = $"GOLD:{ gold}";
        })
        .AddTo(this);
    }
}
