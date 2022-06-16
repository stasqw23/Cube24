using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Transform _rightExtrenePoint;
    [SerializeField] Transform _leftExtrenePoint;



    void Update()
    {

    }
    public void MowePlayer(Vector3 moverDirection)
    {
        if (transform.position.x >= _rightExtrenePoint.position.x && moverDirection.x > 0)
        {

        }
        else if (transform.position.x <= _leftExtrenePoint.position.x && moverDirection.x < 0)
        {

        }
        else 
        {
             transform.Translate(moverDirection * _speed);
        }

    }
}
