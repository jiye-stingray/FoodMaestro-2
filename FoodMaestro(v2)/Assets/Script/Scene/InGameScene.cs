using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    Userinfo userinfo => Managers.Instance.GetUserinfo();

    private void Awake()
    {

        Managers.Instance.GetDBManager().DBLoad();


    }

    public void Start()
    {
        Init();
        StartCoroutine(GuestCor());
    }

    public void Init()
    {
        Kitchen[] kitchens = FindObjectsByType<Kitchen>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitKitchen(kitchens);
        Table[] tables = FindObjectsByType<Table>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitTable(tables);

        Managers.Instance.GetUserinfo().InitFoodItemData();
        Managers.Instance.GetUserinfo().InitMapItemData();


        Managers.Instance.GetMapManager().LoadMap();
    }


    IEnumerator GuestCor()
    {
        yield return null;

        while (true)
        {
            // 빈 테이블 체크
            if(userinfo.CheckNullTable())
            {
                userinfo.CreateGuest();
            }

            yield return null;
        }
        
    }

    
}
