using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingState : State<Maker>
{
    public override void OnEnter()
    {
        _context._currentGuest.Servinged(_context._orderFoodId);
        _context._stateMachine.ChangeState<IdleState>();
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
    }
}
