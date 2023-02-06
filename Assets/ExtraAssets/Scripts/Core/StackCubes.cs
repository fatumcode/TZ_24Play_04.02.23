using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class StackCubes : MonoBehaviour
{
    public static StackCubes singleton { get; private set; }

    [SerializeField] GameObject _cube;
    [SerializeField] GameObject _upperCube;
    [SerializeField] GameObject _stickMan;
    
    IObjectPool<GameObject> _cubesPool;

    int _countCubes = 1;

    void Awake()
    {
        singleton = this;
        _cubesPool = new ObjectPool<GameObject>(CreateCube, OnGet, onRelease);
    }

    GameObject CreateCube()
    {
        GameObject _newCube = Instantiate(_cube); 
        return _newCube;
    }    

    void OnGet(GameObject _cube)
    {
        _stickMan.transform.position = new Vector3(transform.position.x, _upperCube.transform.position.y + 2.05f, transform.position.z);
        _cube.transform.localPosition = new Vector3(gameObject.transform.position.x, _upperCube.transform.position.y + 1.05f, gameObject.transform.position.z);
        _cube.SetActive(true);
        _cube.transform.parent = gameObject.transform;
        _upperCube = _cube;
    }

    void onRelease(GameObject _cube)
    {
        StartCoroutine(cubeDisable(_cube));
    }

    public void AddNewCube()
    {
        _countCubes++;
        _cubesPool.Get();
    }

    public void WallCollision(GameObject _cube)
    {
        _countCubes--;
        _cubesPool.Release(_cube);
    }

    IEnumerator cubeDisable(GameObject _cube)
    {
        yield return new WaitForSeconds(1f);
        _cube.SetActive(false);
    }

    public int GetCountCubes()
    {
        return _countCubes;
    }

    public GameObject GetUpperCube()
    {
        return _upperCube;
    }
}
