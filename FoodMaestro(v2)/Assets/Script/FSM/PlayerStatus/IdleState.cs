using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IdleState : State<Player>
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
/*            if(true)
            {

            }*/

            // 손님
            if(userinfo._guestList.Count > 0)
            {
                _context._currentGuest = userinfo.ReturnFirstGuest();

                if(_context._currentGuest == null)          // 손님이 없는 상황에서 (다른 종업원이 받아갔을 수 도 있음)
                {
                    _context._stateMachine.ChangeState<IdleState>();
                    yield break;
                }

                _context.InitType(EWalkType.ToOrder);
                _context._stateMachine.ChangeState<WalkState>();
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}

