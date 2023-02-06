using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] Canvas _startCanvas;
    [SerializeField] Canvas _failCanvas;
    [SerializeField] ParticleSystem _warpVFX;

    Player _player;

    bool _gameStarted = false;

    void Awake()
    {
        _player = Player.singleton;
        _startCanvas.enabled = true;
        _failCanvas.enabled = false;

        
    }

    void Update()
    {
        if (!_gameStarted)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _gameStarted = true;
                _player.IsAlive = true;
                _startCanvas.enabled = false;

                var emission = _warpVFX.emission;
                emission.enabled = true;
            }
        }
        else if (_player.IsAlive  == false)
        {
            _failCanvas.enabled = true;
        }
    }

    public bool GameStarted()
    {
        return _gameStarted;
    }




}
