using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] float _swipeSpeed = 2f;

    Player _player;
    Touch _touch;

    void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && _player.IsAlive)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    Mathf.Clamp((transform.position.x + _touch.deltaPosition.x * _swipeSpeed), -2f, 2f),
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}
