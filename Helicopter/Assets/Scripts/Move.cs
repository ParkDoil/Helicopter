using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rotor _rotor;
    InputManager _input;
    Rigidbody _rigid;

    public float UpDownSpeed = 0.7f;
    public float HeliSpinSpeed = 0.5f;

    void Start()
    {
        _rotor = GetComponent<Rotor>();
        _input = GetComponent<InputManager>();
        _rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 시동이 켜져있고, 로터 회전속도가 최대치에 근접 했을때에만 작동
        if (_rotor.isStart && _rotor.SpinSpeed >= 18f)
        {
            // 안누르고 있으면 제자리 체공
            if (_input.Y == 0)
            {
                _rigid.velocity = Vector3.zero;
            }
            // 눌렀다면 입력값만큼 힘 작용
            else
            {
                _rigid.AddForce(0f, _input.Y * UpDownSpeed, 0f);
            }

            // 기체 회전
            if (_input.X != 0)
            {
                transform.Rotate(0f, _input.X * HeliSpinSpeed, 0f);
            }
        }
    }
}
