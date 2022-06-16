using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tile")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
