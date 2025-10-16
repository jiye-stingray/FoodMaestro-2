using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Userinfo
{
    public int _stageIndex;

    private Dictionary<int, Kitchen> _dicKitchens = new Dictionary<int, Kitchen>();
    private Dictionary<int, Table> _dicTables = new Dictionary<int, Table>();

    public List<Guest> _waitingGuestList = new List<Guest>();          
    public List<OrderData> _orderDataList = new List<OrderData>();

    public void InitKitchen(Kitchen[] kitchens) 
    { 
        _dicKitchens.Clear();

        foreach (Kitchen k in kitchens)
        {
            _dicKitchens[k._foodId] = k;
        }

    }

    public void InitTable(Table[] tables)
    {
        _dicTables.Clear();
        foreach(Table table in tables)
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
        if(guest == null) { Debug.LogError("null prefab"); }
        guest.Init();
        table.SetGuest(guest);
    }

    public void AddGuestList(Guest guest)
    {
        _waitingGuestList.Add(guest);
    }

    public Guest ReturnFirstGuest()
    {
        if( _waitingGuestList.Count <= 0 ) return null;

        Guest g = _waitingGuestList.First();
        _waitingGuestList.RemoveAt(0);
        return g;
    }

    #endregion



    public void AddOrder(List<OrderData> orders)
    {
        _orderDataList.AddRange(orders);
    }



    public OrderData ReturnFirstOrder()
    {
        if(_orderDataList.Count <= 0 ) return null;

        OrderData order = _orderDataList.First();
        _orderDataList.RemoveAt(0);
        return order;
    }
}
