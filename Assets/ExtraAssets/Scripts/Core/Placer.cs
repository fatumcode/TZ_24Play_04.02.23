using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
    public static Placer singleton { get; private set; }

    GroundPlacer _groundPlacer;
    WallPlacer _wallPlacer;
    PickUpCubePlacer _pickUpCubePlacer;

    void Awake()
    {
        singleton = this;

        _groundPlacer = GetComponent<GroundPlacer>();
        _wallPlacer = GetComponent<WallPlacer>();
        _pickUpCubePlacer = GetComponent<PickUpCubePlacer>();
    }
    
    void Start()
    {
        for (int i = 0; i < 1; i ++)
        {
            SpawnObjects();
        }
    }

    public void SpawnObjects()
    {
        TrackGround _ground = _groundPlacer.CreateGround();
        _wallPlacer.CreateWall(_ground);
        CreatePickUpCubes(_ground);
    }

    void CreatePickUpCubes(TrackGround ground)
    {
        int _countPickCubes = Random.Range(3, 5);

        float _distance = 0;

        for (int i = 0; i < _countPickCubes; i++)
        {
            _distance += 5;
            _pickUpCubePlacer.PlacePickUpCube(ground, _distance);
        }
    }

}
