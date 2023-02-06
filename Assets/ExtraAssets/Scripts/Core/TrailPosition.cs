using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPosition : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
    }
}
