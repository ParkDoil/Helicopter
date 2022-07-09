using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    InputManager _input;
    Rigidbody _rigid;

    public float MaxSpinSpeed = 20f;
    public float SpinSpeed = 0f;
    public bool isStart = false;

    public GameObject TailRotor;
    public GameObject MainRotor;

    void Start()
    {
        _input = GetComponent<InputManager>();
        _rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 시동을 켜고 끄기
        if(_input.isEngineStart)
        {
            if(isStart)
            {
                isStart = false;
            }
            else
            {
                isStart = true;
            }
        }

        if (isStart)
        {
            PropellerSpinStart();
        }
        else
        {
            PropellerSpinEnd();
        }
    }

    // 시동이 켜져있다면
    void PropellerSpinStart()
    {
        SpinSpeed = Mathf.Lerp(SpinSpeed, MaxSpinSpeed, Time.deltaTime);

        // 로터 회전
        MainRotor.transform.Rotate(0f, SpinSpeed, 0f);
        TailRotor.transform.Rotate(SpinSpeed, 0f, 0f);

        // 공중에 떠있기 위해서 중력 제거
        if (_rigid.useGravity == true)
        {
            _rigid.useGravity = false;
        }
    }

    // 시동이 꺼져있다면
    void PropellerSpinEnd()
    {
        SpinSpeed = Mathf.Lerp(SpinSpeed, 0f, Time.deltaTime);

        // 로터 회전
        MainRotor.transform.Rotate(0f, SpinSpeed, 0f);
        TailRotor.transform.Rotate(SpinSpeed, 0f, 0f);

        // 아래로 떨어지기 위해 중력 활성화
        if(_rigid.useGravity == false)
        {
            _rigid.useGravity = true;
        }
    }
}
