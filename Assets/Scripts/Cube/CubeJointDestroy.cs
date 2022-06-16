using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJointDestroy : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    
    private ConfigurableJoint _joint;
    private bool _flagTrigerAnimation = true;

    void Start()
    {
        _joint = gameObject.GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        CreateRaycast();
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void CreateRaycast()
    {
        
        RaycastHit frontRightCube;
        RaycastHit frontLeftCube;
        RaycastHit frontMidlCube;

        Physics.Raycast(new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z), -Vector3.forward, out frontRightCube, _raycastDistance);
        Physics.Raycast(new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z), -Vector3.forward, out frontLeftCube, _raycastDistance);
        Physics.Raycast(transform.position, -Vector3.forward, out frontMidlCube, _raycastDistance);


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
            JointDestroy(existingColaider.transform);
        }
       
    }
    private void JointDestroy(Transform parent)
    {
        gameObject.GetComponent<CubeJointCreate>().ChangePermission(true);
        _joint.connectedBody = null;
        JointDrive drive = new JointDrive();
        drive.maximumForce = 10000;
        drive.positionSpring = 0;
        _joint.yDrive = drive;

        if (_flagTrigerAnimation)
        {
            StartCameraAnimation();
        }
        transform.parent.SetParent(parent);
    }
    private void StartCameraAnimation() 
    {
        var camera = GameObject.Find("Main Camera");
        var cameraAnimator = camera.GetComponent<Animator>();
        cameraAnimator.SetTrigger("Shak");
        _flagTrigerAnimation = false;
    }
}
