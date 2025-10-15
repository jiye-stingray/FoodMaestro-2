using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Dictionary<int, Map> _dicMaps = new Dictionary<int, Map>();
    public void LoadMap()
    {
        _dicMaps.Clear();

        // 나중에 맵 동적 생성
        Map[] maps = FindObjectsOfType<Map>();

        foreach (var map in maps) 
        {
            _dicMaps[map._stageIndex] = map;
        }

    }
}
