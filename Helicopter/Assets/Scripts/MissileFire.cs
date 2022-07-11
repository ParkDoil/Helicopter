using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFire : MonoBehaviour
{
    public GameObject FireLocation;
    public GameObject Misslie;
    InputManager _input;

    public float ReroadTime = 2f;
    float ShootTime;
    public bool isReroad { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<InputManager>();
        ShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.isFire && isReroad == false)
        {
            isReroad = true;

            Instantiate(Misslie, FireLocation.transform.position, transform.rotation);
        }

        ShootTime += Time.deltaTime;

        if (ShootTime >= ReroadTime)
        {
            ShootTime = 0f;
            isReroad = false;
        }
    }
}
