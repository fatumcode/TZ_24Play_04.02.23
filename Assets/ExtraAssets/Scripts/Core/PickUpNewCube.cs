using TMPro;
using UnityEngine;

public class PickUpNewCube : MonoBehaviour
{
    StackCubes _cubes;
    [SerializeField] CollectText _text;
    void Awake()
    {
        _cubes = StackCubes.singleton;
        _text = CollectText.singleton;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CubeStack")
        {
            if(_cubes.GetCountCubes() < 7)
            {
                _cubes.AddNewCube();
                _cubes.GetComponentInChildren<Animator>().SetTrigger("Jump");
                _text.ShowText(_cubes.GetUpperCube().transform.position);
                Destroy(gameObject);
            }
        }
    }
}
