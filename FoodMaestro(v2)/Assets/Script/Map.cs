using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int _stageIndex;
    public PolyNavMap _polyMap;

    public MapItemData _mapItemData;

    [SerializeField] Transform _doorTrans;

    public Transform Door => _doorTrans;

    public void Init()
    {
        _mapItemData = Managers.Instance.GetUserinfo()._dicMapItemData[_stageIndex];
    }

 
}
