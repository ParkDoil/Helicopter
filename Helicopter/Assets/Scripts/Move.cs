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

        // �õ��� �����ְ�, ���� ȸ���ӵ��� �ִ�ġ�� ���� ���������� �۵�
        if (_rotor.isStart && _rotor.SpinSpeed >= 18f)
        {
            // �����Ұ��
            if (_input.isMove)
            {
                UpDownSpeed = 0.000001f;
                MoveDir = new Vector3(0f, 0f, MoveSpeed);
            }

            // �ȴ����� ������ ���ڸ� ü��
            if (_input.Y == 0)
            {
                _rigid.velocity = Vector3.zero;
            }
            // �����ٸ� �Է°���ŭ �� �ۿ�
            else
            {
                _rigid.AddForce(0f, _input.Y * UpDownSpeed, 0f);
            }

            // ��ü ȸ��
            if (_input.X != 0)
            {
                transform.Rotate(0f, _input.X * HeliSpinSpeed, 0f);
            }

            MoveDir = transform.TransformDirection(MoveDir);
            _rigid.AddForce(MoveDir);
        }
    }
}
