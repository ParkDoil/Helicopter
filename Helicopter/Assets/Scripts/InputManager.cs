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
    public bool isMove { get; private set; }
    public bool isFire { get; private set; }

    void Update()
    {
        X = 0f;
        Y = 0f;
        isEngineStart = false;
        isMove = false;
        isFire = false;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");


        isEngineStart = Input.GetKeyDown(KeyCode.R);

        isMove = Input.GetKey(KeyCode.Keypad8);

        isFire = Input.GetKeyDown(KeyCode.Space);
    }
}
