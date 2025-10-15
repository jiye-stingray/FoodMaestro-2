using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userinfo
{

    private Dictionary<int, Kitchen> _kitchens = new Dictionary<int, Kitchen>();
    private Dictionary<int, Table> _tables = new Dictionary<int, Table>();

    public void InitKitchen(Kitchen[] kitchens) 
    { 
        _kitchens.Clear();

        foreach (Kitchen k in kitchens)
        {
            _kitchens[k._foodId] = k;
        }

    }

    public void InitTable(Table[] tables)
    {
        _tables.Clear();
        foreach(Table table in tables)
        {
            _tables[table._id] = table;
        }

    }

}
