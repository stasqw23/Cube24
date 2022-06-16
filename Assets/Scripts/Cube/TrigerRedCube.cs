using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerRedCube : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent.GetComponent<DethPlayer>().Deth();
        }
    }

}
