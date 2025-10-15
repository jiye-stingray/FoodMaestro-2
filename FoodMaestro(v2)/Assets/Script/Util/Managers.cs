using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    private Userinfo _userinfo = new Userinfo();

    private MapManager _mapManager = new MapManager();

    private ResourceObjectManager _resourceObjectManager = new ResourceObjectManager();

    public Userinfo GetUserinfo()
    {
        return _userinfo;
    }

    public MapManager GetMapManager()
    {
        return _mapManager;
    }

    public ResourceObjectManager GetResourceObjectManager()
    {
        return _resourceObjectManager;
    }
}
