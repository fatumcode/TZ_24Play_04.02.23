using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    ShakeCamera _camera;
    Player _player;
    StackCubes _stackCubes;

    bool _onCollision = false;

    void Start()
    {
        _player = Player.singleton;
        _camera = ShakeCamera.singleton;
        _stackCubes = StackCubes.singleton;
    }

    void OnTriggerEnter(Collider _other)
    {
        if (_onCollision) return;

        if (_other.gameObject == _stackCubes.GetUpperCube())
        {
            Collision();
            _player.Death();
            return;
        }

        if (_other.gameObject.CompareTag("CubeStack"))
        {
            Collision();
            StayInColumn _cube = _other.GetComponent<StayInColumn>();
            if (!_cube.IsReleased())
            {
                _cube.SetReleased();
                _other.gameObject.transform.SetParent(null);
                if (_player.IsAlive)
                    _player.GetComponent<StackCubes>().WallCollision(_other.gameObject);
            }

        }
    }

    void Collision()
    {
        _onCollision = true;
        StartCoroutine(_camera.Shake());
        Handheld.Vibrate();
    }
}
