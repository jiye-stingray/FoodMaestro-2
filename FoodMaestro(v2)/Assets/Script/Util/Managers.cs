using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    private Userinfo _userinfo = new Userinfo();
    private MapManager _mapManager = new MapManager();
    private DBManager _dbManager = new DBManager();
    private ResourceObjectManager _resourceObjectManager = new ResourceObjectManager();
    private CameraManager _cameraManager = new CameraManager();

    public Userinfo GetUserinfo()
    {
        return _userinfo;
    }

    public MapManager GetMapManager()
    {
        return _mapManager;
    }

    public DBManager GetDBManager()
    {
        return _dbManager;
    }

    public ResourceObjectManager GetResourceObjectManager()
    {
        return _resourceObjectManager;
    }

    public CameraManager GetCameraManager()
    {
        return _cameraManager;
    }
}
