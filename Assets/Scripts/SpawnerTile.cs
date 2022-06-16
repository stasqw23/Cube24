using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTile : MonoBehaviour
{
    [SerializeField] private GameObject[] _tileList;
    [SerializeField] private Transform _parentTile;
 
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "tile")
        {
            SpawnTile();
        }
    }
    void SpawnTile()
    {
        var number = Random.Range(0, _tileList.Length);
        Instantiate(_tileList[number], transform.position, transform.rotation, _parentTile);

    }
}
