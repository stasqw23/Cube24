using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTile : MonoBehaviour
{
    private ParamTile _param;

    private void Start()
    {
        _param = GetComponentInParent<ParamTile>();
    }

    void  FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * _param.speedMove * Time.fixedDeltaTime); 


    }
}
