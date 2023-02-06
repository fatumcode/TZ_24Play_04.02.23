using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject _player;

    Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    void LateUpdate()
    {
        var position = _transform.position;
        position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z - 8f);
        _transform.position = position;
    }
}
