using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    private Camera _mainCam;
    public Camera MainCam
    {
        get 
        { 
            if(_mainCam == null)
            {
                _mainCam = Camera.main;
            }
            return _mainCam; 
        }
    }


    private Camera _uiCam;
    public Camera UICam
    {
        get
        {
            if (_uiCam == null)
            {
                _uiCam = GameObject.Find("UICamera").GetComponent<Camera>();
            }
            return _uiCam;
        }
    }
}
