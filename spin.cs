using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    //orbit a parent and child - spin.cs attached to cube red
    //parent cube is moved off world origin


    public GameObject insideCube;
      void Start()
    {
        //get a refrence to the blue cube
        insideCube = GameObject.Find("orb");
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
        SpinOnAxis();
    }

    void OrbitAround()
    {
        //rotatearound changes position and rotation
        transform.RotateAround(insideCube.transform.position, new Vector3(0, 0, 0),90f *Time.deltaTime);
    }
    void SpinOnAxis()
    {
        transform.RotateAround(transform.position, new Vector3(0,1,0),150f * Time.deltaTime);
    }

}
