using PolyNav;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField] Canvas _worldCanvas;
    [SerializeField] GameObject _orderGo;
    [SerializeField] OrderIcon[] _orderIcon;

    bool isOrdered = false; // 주문 했는가?
    PolyNavAgent _agent;

    Userinfo userinfo => Managers.Instance.GetUserinfo();

   List<OrderData> _orderList = new List<OrderData>();      // 주문 목록

    public void Init()
    {
        _worldCanvas.worldCamera = Managers.Instance.GetCameraManager().UICam;

        _agent = GetComponent<PolyNavAgent>();
        _agent.map = Managers.Instance.GetMapManager()._dicMaps[userinfo._currentStageIndex]._polyMap;
        _agent.OnDestinationReached += DestinationReached;

        isOrdered = false;
        _orderList.Clear();

        UnableOrderIcon();
    }

    public void Order()
    {
        // order 생성
        int count = Random.Range(1, 3);     // 주문 갯수
        for (int i = 0; i < count; i++)
        {
            OrderData orderData = new OrderData()
            {
                // 해금된 요리 id 주기3
                _foodId = Managers.Instance.GetUserinfo().GetRandomOrderFood()._id,
                _orderdGuest = this,
            };
            _orderList.Add(orderData);
        }
        DrawOrderIcon();
        userinfo.AddOrder(_orderList);
        
        isOrdered = true;
    }

    private void DrawOrderIcon()
    {
        _orderGo.SetActive(true);

        var orderCount = _orderList.GroupBy(o => o._foodId).ToDictionary(d => d.Key,d=>d.Count());

        int index = 0;
        foreach (var item in orderCount)
        {
            _orderIcon[index].Init(item.Key, item.Value);
        }

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

    private void UnableOrderIcon()
    {

        for (int i = 0; i < _orderIcon.Length; i++)
        {
            _orderIcon[i].gameObject.SetActive(false);

        }
        _orderGo.SetActive(false);
    }
}
