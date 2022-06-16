using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCubes : MonoBehaviour
{
    [SerializeField] GameObject _yellowCube;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CubeCollector")
        {
            var addCubeScript = other.GetComponent<AddCube>();
            addCubeScript.CreateCube(_yellowCube);
            addCubeScript.SpawnCollectText(transform.parent);
            Destroy(gameObject);
        }
    }
}
