using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamTile : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    public float speedMove { get => _speedMove; set => _speedMove = value ; }


}
