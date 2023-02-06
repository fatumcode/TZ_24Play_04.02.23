using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInColumn : MonoBehaviour
{
    bool isReleased = false;

    void OnEnable()
    {
        isReleased = false;
    }

    void Update()
    {
        if (!isReleased) transform.localPosition = new Vector3(0, transform.localPosition.y, 0);    
    }

    public void SetReleased()
    {
        isReleased = true;
    }

    public bool IsReleased()
    {
        return isReleased;
    }
}
