using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sense : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("starting");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
    }

}
