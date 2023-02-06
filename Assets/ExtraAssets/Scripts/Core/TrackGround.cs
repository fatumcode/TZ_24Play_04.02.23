using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGround : MonoBehaviour
{
    [SerializeField] Transform _start;
    [SerializeField] Transform _end;

    public Vector3 GetStartPosition() { return _start.localPosition; }
    public Vector3 GetEndPosition() { return _end.position; }
}
