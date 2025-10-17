using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State<Player>
{
    Vector2 goalVec = Vector2.zero;
    public override void OnEnter()
    {
        goalVec = InitGoalVec();
        _context._agent.OnDestinationReached += Arrival;
    }

    public override void OnExit()
    {
        _context._agent.OnDestinationReached -= Arrival;

    }

    public override void Update()
    {
        _context._agent.SetDestination(goalVec);
    }

    private Vector2 InitGoalVec()
    {
        Vector2 goal = Vector2.zero;

        switch (_context._walkType)
        {
            case EWalkType.ToOrder:
                goal = _context._currentGuest.transform.position;
                break;
            case EWalkType.ToCook:
                goal = Managers.Instance.GetUserinfo().GetKitchen(_context._orderFoodId)._position;
                break;
            case EWalkType.ToServing:
                break;
            default:
                break;
        }

        goal += Vector2.down;       // offset
        return goal;
    }

    private void Arrival()
    {
        switch (_context._walkType)
        {
            case EWalkType.ToOrder:
                _context._stateMachine.ChangeState<OrderState>();
                break;
            case EWalkType.ToCook:
                break;
            case EWalkType.ToServing:
                break;
        }

    }
}
