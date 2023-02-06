using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCubePlacer : MonoBehaviour
{
    [SerializeField] GameObject _pickUpCube;

    float[] _posX = new float[3];

    void Awake()
    {
        _posX[0] = -1f;
        _posX[1] = 0;
        _posX[2] = 1f;
    }

    public void PlacePickUpCube(TrackGround cubePlace, float distance)
    {
        int _randomXPos = Random.Range(0, 2);
        GameObject newCube = Instantiate(original: _pickUpCube);
        newCube.transform.position = new Vector3(_posX[_randomXPos], 0.5f, cubePlace.GetEndPosition().z - distance);
        newCube.transform.SetParent(cubePlace.gameObject.transform);
    }
}
