using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] _wall;

    public void CreateWall(TrackGround wallPlace)
    {
        int _wallIndex = Random.Range(0, _wall.Length);
        GameObject _newWall = Instantiate(_wall[_wallIndex]);
        _newWall.transform.position = wallPlace.GetEndPosition();
        _newWall.transform.SetParent(wallPlace.gameObject.transform);
    }
}
