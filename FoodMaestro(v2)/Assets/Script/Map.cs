using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int _stageIndex;
    public PolyNavMap _polyMap;

    private void Awake()
    {
        _polyMap = GetComponent<PolyNavMap>();
    }
}
