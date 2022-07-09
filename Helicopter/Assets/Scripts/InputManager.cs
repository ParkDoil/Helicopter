using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // ��ü ȸ��
    public float X { get; private set; }
    // �� �Ʒ�
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
