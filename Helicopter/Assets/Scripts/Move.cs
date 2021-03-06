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
    public float MoveSpeed = 2f;

    Vector3 MoveDir;

    void Start()
    {
        _rotor = GetComponent<Rotor>();
        _input = GetComponent<InputManager>();
        _rigid = GetComponent<Rigidbody>();

        MoveDir = Vector3.zero;
    }

    void Update()
    {
        UpDownSpeed = 0.7f;

        // 시동이 켜져있고, 로터 회전속도가 최대치에 근접 했을때에만 작동
        if (_rotor.isStart && _rotor.SpinSpeed >= 18f)
        {
            // 전진할경우
            if (_input.isMove)
            {


                UpDownSpeed = 0.3f;
                MoveDir = new Vector3(0f, 0f, MoveSpeed);
            }

            // 안누르고 있으면 제자리 체공
            if (_input.Y == 0 && false == _input.isMove)
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

            MoveDir = transform.TransformDirection(MoveDir);
            _rigid.AddForce(MoveDir, ForceMode.Force);
        }
    }
}
