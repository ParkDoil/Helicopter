using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    Vector3 vec;
    void Start()
    {
        vec = Target.position - transform.position;
    }

    void Update()
    {
        transform.position = Target.position - vec;
    }
}
