using PolyNav;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWalkType
{ 
    ToOrder,
    ToCook,
    ToServing

}

public class Player : MonoBehaviour
{
    public StateMachine<Player> _stateMachine;
    public PolyNavAgent _agent;

    public EWalkType _walkType;

    public int _orderFoodId;
    public Guest _currentGuest;

    public void Awake()
    {
        _agent = GetComponent<PolyNavAgent>();
    }

    public void Start()
    {
        Init();
    }

    private void Update()
    {
        if(_stateMachine != null)
            _stateMachine.Update();
    }

    private void Init()
    {
        _stateMachine = new StateMachine<Player>(this, new IdleState());
        _stateMachine.AddState(new WalkState());
        _stateMachine.AddState(new OrderState());
    }

    public void InitType(EWalkType walkType)
    {
        _walkType = walkType;
    }

    public void InitOrder(OrderData orderData)
    {
        // 음식 할당
        _orderFoodId = orderData._foodId;
        _currentGuest = orderData._orderdGuest;
    }

}
