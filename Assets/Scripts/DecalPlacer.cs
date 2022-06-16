using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalPlacer : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private GameObject _decalPrefab;
    [SerializeField] private Transform _raycastSpawner;
    void Start()
    {
        
    }

    void Update()
    {
        CreateRaycast();
    }
    private void CreateRaycast()
    {
        RaycastHit hitInfo;
        Physics.Raycast(_raycastSpawner.position, - transform.up, out hitInfo, _raycastDistance);
        if (hitInfo.collider != null && hitInfo.collider.tag == "tile" )
        {
            StartCoroutine(SpawnDecal(hitInfo));
        }
    }

    IEnumerator SpawnDecal(RaycastHit spawnPoint)
    {
        yield return new WaitForSeconds(0.1f);
        var decal = Instantiate(_decalPrefab);
        decal.transform.position = new Vector3(spawnPoint.point.x, spawnPoint.point.y + 0.05f, spawnPoint.point.z);
        decal.transform.forward = spawnPoint.normal * -1f;
        decal.transform.SetParent(spawnPoint.transform);      

        yield break;


    }
}
