using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PolyNavAgent _agent;

    public void Awake()
    {
        _agent = GetComponent<PolyNavAgent>();
    }

}
