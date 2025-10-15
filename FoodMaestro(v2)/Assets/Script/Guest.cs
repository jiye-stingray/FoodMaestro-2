using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    bool isOrdered = false; // 주문 했는가?
    PolyNavAgent _agent;

    Userinfo userinfo => Managers.Instance.GetUserinfo();



    public void Init()
    {
        _agent = GetComponent<PolyNavAgent>();
        _agent.map = Managers.Instance.GetMapManager()._dicMaps[userinfo._stageIndex]._polyMap;
        _agent.OnDestinationReached += SitAtTable;

    }


    public void MoveTo(Vector2 position)
    {
        _agent.SetDestination(position);
    }

    public void SitAtTable()
    {
        if (isOrdered) return;

        userinfo.AddGuestList(this);
    }
}
