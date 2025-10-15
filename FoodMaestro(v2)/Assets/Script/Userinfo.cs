using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userinfo
{

    private Dictionary<int, Kitchen> _kitchens = new Dictionary<int, Kitchen>();

    public void InitKitchen(Kitchen[] kitchens) 
    { 
        _kitchens.Clear();

        foreach (Kitchen k in kitchens)
        {
            _kitchens[k._id] = k;
        }

        Debug.Log(_kitchens.Count);
    }

}
