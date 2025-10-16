using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderState : State<Player>
{
    public override void OnEnter()
    {
        // 게스트 주문 받기
        _context._currentGuest.Order();

        _context._stateMachine.ChangeState<IdleState>();
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
    }
}
