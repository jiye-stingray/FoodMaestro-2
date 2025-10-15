using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int _id;
    public Vector2 _position => gameObject.transform.position;

    public Guest _guest;        

    public void SetGuest(Guest guest)
    {
        _guest = guest;
        // table로 이동
        _guest.MoveTo(_position);
    }
}
