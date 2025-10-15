using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    private void Awake()
    {
        Kitchen[] kitchens = FindObjectsByType<Kitchen>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitKitchen(kitchens);
        Table[] tables = FindObjectsByType<Table>(FindObjectsSortMode.None);
        Managers.Instance.GetUserinfo().InitTable(tables);
    }
}
