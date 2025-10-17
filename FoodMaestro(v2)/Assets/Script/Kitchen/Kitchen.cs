using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public int _stageId; 
    public int _foodId;

    public bool _isOpen;

    [SerializeField] GameObject[] _cookwareObj;
    public Maker[] _makers;

    public Vector2 _position => gameObject.transform.position;

    public int level = 0;

    public void Awake()
    {
        _makers = new Maker[_cookwareObj.Length];     // 사용자 자리 확보
    }

    public void SetMaker(Maker maker)
    {
        Array.FindIndex(_makers, m => m == null);
    }
}
