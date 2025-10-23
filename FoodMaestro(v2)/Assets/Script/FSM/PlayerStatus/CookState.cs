using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookState : State<Maker>
{
    FoodItemData _foodItemData;
    float timer = 0f;
    Userinfo userinfo => Managers.Instance.GetUserinfo();

    public override void OnEnter()
    {
        _context._timerImg.gameObject.SetActive(true);

        _foodItemData = userinfo.GetFoodItemData($"{userinfo._currentStageIndex}_{_context._orderFoodId}");

        _context.StartCoroutine(CookCor());
    }

    public override void OnExit()
    {
        _context._timerImg.gameObject.SetActive(false);
    }

    public override void Update()
    {

    }

    IEnumerator CookCor()
    {
        timer = 0f;
        while (timer < _foodItemData._realTime)
        {
            timer += Time.deltaTime;
            _context._timerImg.fillAmount = (timer / _foodItemData._realTime);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);
        _context.InitType(EWalkType.ToServing);
        _context._stateMachine.ChangeState<WalkState>();
    }
}
