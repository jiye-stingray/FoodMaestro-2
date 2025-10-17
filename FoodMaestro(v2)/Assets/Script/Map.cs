using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int _stageIndex;
    public PolyNavMap _polyMap;

    public MapItemData _mapItemData;

    public void Init()
    {
        _mapItemData = Managers.Instance.GetUserinfo()._dicMapItemData[_stageIndex];
    }
}
