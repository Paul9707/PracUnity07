using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRope : MonoBehaviour
{
   
    public void OnPositionChanged(Vector2 value)
    {
        Vector2 pos = transform.localPosition;
        pos.y = value.y * 100;
        transform.localPosition = pos;
    }
}
