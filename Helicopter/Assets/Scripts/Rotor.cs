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
        // �õ��� �Ѱ� ����
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

    // �õ��� �����ִٸ�
    void PropellerSpinStart()
    {
        SpinSpeed = Mathf.Lerp(SpinSpeed, MaxSpinSpeed, Time.deltaTime);

        // ���� ȸ��
        MainRotor.transform.Rotate(0f, SpinSpeed, 0f);
        TailRotor.transform.Rotate(SpinSpeed, 0f, 0f);

        // ���߿� ���ֱ� ���ؼ� �߷� ����
        if (_rigid.useGravity == true)
        {
            _rigid.useGravity = false;
        }
    }

    // �õ��� �����ִٸ�
    void PropellerSpinEnd()
    {
        SpinSpeed = Mathf.Lerp(SpinSpeed, 0f, Time.deltaTime);

        // ���� ȸ��
        MainRotor.transform.Rotate(0f, SpinSpeed, 0f);
        TailRotor.transform.Rotate(SpinSpeed, 0f, 0f);

        // �Ʒ��� �������� ���� �߷� Ȱ��ȭ
        if(_rigid.useGravity == false)
        {
            _rigid.useGravity = true;
        }
    }
}
