using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IdleState : State<Maker>
{

    Userinfo userinfo => Managers.Instance.GetUserinfo();

    public override void OnEnter()
    {
        _context.StartCoroutine(WaitingCor());
    }


    public override void Update()
    {
    }
    public override void OnExit()
    {
    }

    IEnumerator WaitingCor()
    {

        while (true)
        {

            // 요리
            if (userinfo._orderDataList.Count > 0)
            {
                OrderData order = userinfo.ReturnFirstOrder();
                if (order == null) continue;

                _context.InitOrder(order);
                _context.InitType(EWalkType.ToCook);
                _context._stateMachine.ChangeState<WalkState>();
                yield break;

            }

            // 손님
            if (userinfo._waitingGuestList.Count > 0)
            {
                _context._currentGuest = userinfo.ReturnFirstGuest();

                // 손님이 없는 상황에서 (다른 종업원이 받아갔을 수 도 있음)
                if (_context._currentGuest == null) continue;

                _context.InitType(EWalkType.ToOrder);
                _context._stateMachine.ChangeState<WalkState>();
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}

