using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJointCreate : MonoBehaviour
{
    private ConfigurableJoint _joint;
    private bool _permissionCreateJoint = true;
    private bool _permissionDeleteJoint = false;
    [SerializeField] private float _raycastDistance;
    void Start()
    {
        _joint = gameObject.GetComponent<ConfigurableJoint>();
    }

    void FixedUpdate()
    {
        
            CreateJoint();
        
    }
    void CreateJoint()
    {
        RaycastHit upCube;
        Physics.Raycast(transform.position, Vector3.up, out upCube, _raycastDistance);
        if (_joint.connectedBody == null&& _permissionCreateJoint)
        {

            if (upCube.collider != null && upCube.collider.tag == "YellowCube")
            {
                _joint.connectedBody = upCube.collider.gameObject.GetComponent<Rigidbody>();
                JointDrive drive = new JointDrive();
                drive.maximumForce = 10000;
                drive.positionSpring = 50000;
                _joint.yDrive = drive;
                _permissionCreateJoint = false;               

            }
            

        }
        else if (upCube.collider == null)
        {
            DeleteJoint();

            _permissionCreateJoint = true;
            _permissionDeleteJoint = false;
            

        }
        else if (_permissionDeleteJoint)
        {
            DeleteJoint();
        }

    }
    public void ChangePermission(bool permission)
    {
        _permissionDeleteJoint = permission;
    }

    void DeleteJoint()
    {
        _joint.connectedBody = null;
        JointDrive drive = new JointDrive();
        drive.maximumForce = 10000;
        drive.positionSpring = 0;
        _joint.yDrive = drive;
    }
}
