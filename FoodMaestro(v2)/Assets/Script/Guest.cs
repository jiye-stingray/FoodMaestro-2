using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    bool isOrdered = false; // 주문 했는가?
    PolyNavAgent _agent;

    Userinfo userinfo => Managers.Instance.GetUserinfo();

   List<OrderData> _orderList = new List<OrderData>();      // 주문 목록

    public void Init()
    {
        _agent = GetComponent<PolyNavAgent>();
        _agent.map = Managers.Instance.GetMapManager()._dicMaps[userinfo._currentStageIndex]._polyMap;
        _agent.OnDestinationReached += DestinationReached;

        isOrdered = false;
        _orderList.Clear();
    }

    public void Order()
    {
        // order 생성
        int count = Random.Range(1, 3);     // 주문 갯수
        for (int i = 0; i < count; i++)
        {
            OrderData orderData = new OrderData()
            {
                // 해금된 요리 id 주기
                _foodId = Managers.Instance.GetUserinfo().GetRandomOrderFood()._id,
                _orderdGuest = this,
            };
            _orderList.Add(orderData);
        }

        userinfo.AddOrder(_orderList);
        
        isOrdered = true;
    }

    public void MoveTo(Vector2 position)
    {
        _agent.SetDestination(position);
    }

    public void DestinationReached()
    {
        if (isOrdered) return;

        userinfo.AddGuestList(this);
    }
}
