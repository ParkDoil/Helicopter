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
        // �õ��� �����ְ�, ���� ȸ���ӵ��� �ִ�ġ�� ���� ���������� �۵�
        if (_rotor.isStart && _rotor.SpinSpeed >= 18f)
        {
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
        }
    }
}
