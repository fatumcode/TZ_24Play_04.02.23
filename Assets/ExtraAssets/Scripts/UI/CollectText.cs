using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectText : MonoBehaviour
{
    public static CollectText singleton { get; private set; }

    void Awake()
    {
        singleton = this;
    }
    public void ShowText(Vector3 position)
    {
        transform.position = position + new Vector3(1f, 3f, 0);
    }
}
