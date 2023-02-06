using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player singleton { get; private set; }

    [SerializeField] float _speed = 3f;
    [SerializeField] GameObject _bones;
    [SerializeField] ParticleSystem _warpVFX;
    bool _isAlive = false;

    void Awake()
    {
        singleton = this;
    }

    void Update()
    {
        if (_isAlive)
        {
            gameObject.transform.Translate(0, 0, Time.deltaTime * _speed);
        }
    }

    public void Death()
    {
        _isAlive = false;
        var _body = _bones.transform.parent;
        _bones.SetActive(true);
        _body.GetComponent<BoxCollider>().enabled = false;
        GetComponentInChildren<Animator>().enabled = false;
        _warpVFX.Stop();

    }

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }


}
