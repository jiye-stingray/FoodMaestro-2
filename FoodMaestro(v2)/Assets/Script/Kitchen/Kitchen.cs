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
    [SerializeField] UIKitchen _ui;
    public Maker[] _makers;

    public Vector2 _position => gameObject.transform.position;

    public int level = 0;

    public void Awake()
    {
        _makers = new Maker[_cookwareObj.Length];     // 사용자 자리 확보
        _ui.SetFoodData(Managers.Instance.GetDBManager().GetFooddata($"{_stageId}_{_foodId}"));
        _ui.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        var cam = Camera.main;
        if (cam == null)
            return;

        var ray = cam.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        if (hit.collider == null)
            return;

        // 콜라이더가 자식에 붙어있는 경우도 고려
        var kitchen = hit.collider.GetComponent<Kitchen>() ?? hit.collider.GetComponentInParent<Kitchen>();
        if (kitchen != this)
            return;

        if (_ui != null)
        {
            bool nextActive = !_ui.gameObject.activeSelf;
            _ui.gameObject.SetActive(nextActive);
        }
    }
    public void SetMaker(Maker maker)
    {
        Array.FindIndex(_makers, m => m == null);
    }

}
