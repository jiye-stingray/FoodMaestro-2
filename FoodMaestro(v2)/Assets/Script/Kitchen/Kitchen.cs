using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public int _stageId; 
    public int _foodId;

    public bool isOpen;

    public Vector2 _position => gameObject.transform.position;

    public int level = 1;


}
