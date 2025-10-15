using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public int _id;
    public int _foodId;

    public bool isOpen;

    public Vector2 _position => gameObject.transform.position;
}
