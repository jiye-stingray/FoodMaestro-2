using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    private Userinfo _userinfo = new Userinfo();

    public Userinfo GetUserinfo()
    {
        return _userinfo;
    }
}
