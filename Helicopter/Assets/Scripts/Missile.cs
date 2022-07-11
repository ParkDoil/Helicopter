using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody _rigid;

    public float MissileSpeed = 10f;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        _rigid.velocity = transform.forward * MissileSpeed;

        Destroy(gameObject, 5f);
    }

}
