using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{

    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private Rigidbody[] _allRigidbody;


    private void Awake()
    {
        for (int i = 0; i < _allRigidbody.Length; i++ )
        {
            _allRigidbody[i].isKinematic = true;
        }
    }
    public void MakePysical()
    {
        _animatorPlayer.enabled = false;
        for (int i = 0; i < _allRigidbody.Length; i++)
        {
            _allRigidbody[i].isKinematic = false;
        }
    }

}
