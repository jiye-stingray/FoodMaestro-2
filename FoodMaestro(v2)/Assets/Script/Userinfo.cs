using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Userinfo
{
    public int _currentStageIndex;

    public Dictionary<int, MapItemData> _dicMapItemData = new Dictionary<int, MapItemData>();

    private Dictionary<string, Kitchen> _dicKitchens = new Dictionary<string, Kitchen>();
    private Dictionary<int, Table> _dicTables = new Dictionary<int, Table>();

    public List<Guest> _waitingGuestList = new List<Guest>();
    public List<OrderData> _orderDataList = new List<OrderData>();

    public Dictionary<int, OrderData> _dicOrderData = new Dictionary<int, OrderData>();
    public Dictionary<string, FoodItemData> _dicFoodItemData = new Dictionary<string, FoodItemData>();

    public List<int> _unlockFoodLevelList = new List<int>();


    public void InitMapItemData()
    {
        for (int i = 0; i < Managers.Instance.GetDBManager()._stageCount; i++)
        {
            MapItemData mapItemData = new MapItemData()
            {
                _stageId = i,
                _areaLevel = 1      // 초기화
            };
            _dicMapItemData.Add(mapItemData._stageId, mapItemData);
        }
    }

    #region Kitchen

    public void InitKitchen(Kitchen[] kitchens)
    {
        _dicKitchens.Clear();

        foreach (Kitchen k in kitchens)
        {
            _dicKitchens[$"{k._stageId}_{k._foodId}"] = k;
        }

    }

    public Kitchen GetKitchen(int foodId)
    {
        return _dicKitchens[$"{_currentStageIndex}_{foodId}"];
    }

    #endregion

    public void InitTable(Table[] tables)
    {
        _dicTables.Clear();
        foreach (Table table in tables)
        {
            _dicTables[table._id] = table;
        }

    }

    public bool CheckNullTable()
    {
        return _dicTables.Values.Any(t => t._guest == null);
    }

    #region Guest

    public void CreateGuest()
    {
        Table table = _dicTables.FirstOrDefault(t => t.Value._guest == null).Value;
        Guest guest = Managers.Instance.GetResourceObjectManager().Instantiate("Prefabs/Guest").GetComponent<Guest>();
        if (guest == null) { Debug.LogError("null prefab"); }
        guest.Init();
        table.SetGuest(guest);
    }

    public void AddGuestList(Guest guest)
    {
        _waitingGuestList.Add(guest);
    }

    public Guest ReturnFirstGuest()
    {
        if (_waitingGuestList.Count <= 0) return null;

        Guest g = _waitingGuestList.First();
        _waitingGuestList.RemoveAt(0);
        return g;
    }

    #endregion


    #region Order
    public void AddOrder(List<OrderData> orders)
    {
        _orderDataList.AddRange(orders);
    }



    public OrderData ReturnFirstOrder()
    {
        if (_orderDataList.Count <= 0) return null;

        // 요리 가능한 (주방이 비어있는) 주문 먼저 반환
        OrderData order = _orderDataList.Where(o => _dicKitchens[$"{_currentStageIndex}_{o._foodId}"]._makers.Any(m => m == null)).FirstOrDefault();  
        if(order != null)
            _orderDataList.Remove(order);
        return order;
    }

    #endregion

    public void InitFoodItemData()
    {
        foreach (FoodData data in Managers.Instance.GetDBManager().GetFoodDB().Values)
        {
            FoodItemData foodItemData = new FoodItemData()
            {
                _id = data._id,
                _stageId = data._stageID,
                _isOpen = false
            };
            _dicFoodItemData.Add($"{foodItemData._stageId}_{foodItemData._id}", foodItemData);
        }

        _dicFoodItemData["0_0"]._isOpen = true;
    }

    public FoodItemData GetRandomOrderFood()
    {

        var ableFoodList = _dicFoodItemData.Where(pair => pair.Value._isOpen && pair.Value._id <= _dicMapItemData[_currentStageIndex]._areaLevel).ToList();
        return ableFoodList[Random.Range(0, ableFoodList.Count)].Value;

    }


}
