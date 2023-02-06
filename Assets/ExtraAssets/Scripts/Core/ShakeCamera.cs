using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera singleton { get; private set; }

    [SerializeField] float _duration = 0.5f;
    [SerializeField] float _magnitude = 2f;

    Vector3 _originalPosition;
    float _elapsed = 0;

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        _originalPosition = transform.position;
    }

    public IEnumerator Shake()
    {
        if (_elapsed == 0)
            while (_elapsed < _duration)
            {
                float x = Random.Range(-1f, 1f) * _magnitude;
                float y = Random.Range(-1f, 1f) * _magnitude;

                transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
                _elapsed += Time.deltaTime;
                yield return null;
            }
        _elapsed = 0;
        transform.position = _originalPosition;
    }
}
