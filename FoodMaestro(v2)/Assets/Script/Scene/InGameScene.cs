using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    Userinfo userinfo => Managers.Instance.GetUserinfo();

    private void Awake()
    {
        Kitchen[] kitchens = FindObjectsByType<Kitchen>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitKitchen(kitchens);
        Table[] tables = FindObjectsByType<Table>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitTable(tables);
    }

    public void Start()
    {
        Init();
        StartCoroutine(GuestCor());
    }

    public void Init()
    {
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
