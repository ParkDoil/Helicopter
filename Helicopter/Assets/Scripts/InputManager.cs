using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 몸체 회전
    public float X { get; private set; }
    // 위 아래
    public float Y { get; private set; }
    public bool isEngineStart { get; private set; }

    void Update()
    {
        X = 0f;
        Y = 0f;
        isEngineStart = false;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        
        isEngineStart = Input.GetKey(KeyCode.R);
    }
}
