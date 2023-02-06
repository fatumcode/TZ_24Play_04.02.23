using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundPlacer : MonoBehaviour
{
    [SerializeField] TrackGround _ground;
    [SerializeField] TrackGround _firstGround;
    [SerializeField] int _duration = 5;

    List<TrackGround> _groundList = new List<TrackGround>();

    void Awake()
    {
        _groundList.Add(_firstGround);
    }

    public TrackGround CreateGround()
    {
        TrackGround _newGround = Instantiate(_ground);
        _newGround.transform.position = _groundList[_groundList.Count - 1].GetEndPosition() * 2 ;
        _newGround.transform.DOMove(_groundList[_groundList.Count - 1].GetEndPosition() , _duration);
        _groundList.Add(_newGround);

        if (_groundList.Count > 5)
        {
            Destroy(_groundList[0].gameObject);
            _groundList.RemoveAt(0);
        }
        return _groundList[_groundList.Count - 1];
    }
}
