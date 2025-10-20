using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderState : State<Maker>
{
    public override void OnEnter()
    {
        _context.StartCoroutine(OrderCor());
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
    }

    IEnumerator OrderCor()
    {
        yield return new WaitForSeconds(0.5f);
        // 게스트 주문 받기
        _context._currentGuest.Order();

        _context._stateMachine.ChangeState<IdleState>();

        yield break;
    }
}
