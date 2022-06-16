using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethPlayer : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private RagdollControl _ragdollControl;
    [SerializeField] private Transform _CubeHolder;
    [SerializeField] private ParamTile _paramTile;
    [SerializeField] private ParticleSystem _warpEffect;
    [SerializeField] private GameControler _gameControler;


    void Start()
    {
    }

    void Update()
    {
        CreateRaycast();
        Debug.DrawRay(_CubeHolder.position, -Vector3.forward,Color.black);
    }
    public void Deth()
    {
        _ragdollControl.MakePysical();
        _paramTile.speedMove = 0;
        _warpEffect.Stop();
        _gameControler.StopGame();

    }
    private void CreateRaycast()
    {

        RaycastHit frontRightCube;
        RaycastHit frontLeftCube;
        RaycastHit frontMidlCube;

        Physics.Raycast(new Vector3(_CubeHolder.position.x - 0.4f, _CubeHolder.position.y, _CubeHolder.position.z), -Vector3.forward, out frontRightCube, _raycastDistance);
        Physics.Raycast(new Vector3(_CubeHolder.position.x + 0.4f, _CubeHolder.position.y, _CubeHolder.position.z), -Vector3.forward, out frontLeftCube, _raycastDistance);
        Physics.Raycast(_CubeHolder.position, -Vector3.forward, out frontMidlCube, _raycastDistance);


        Collider existingColaider = null;

        if (frontRightCube.collider != null)
        {
            existingColaider = frontRightCube.collider;
        }
        else if (frontLeftCube.collider != null)
        {
            existingColaider = frontLeftCube.collider;
        }
        else if (frontMidlCube.collider != null)
        {
            existingColaider = frontMidlCube.collider;
        }

        if (existingColaider != null && existingColaider.tag == "RedCube")
        {           
            Deth();
        }

    }
}
