using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayerMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _spead;
    [SerializeField] private TowerRoot _towerRoot;
    [SerializeField] private MoneyTower _moneyTower;

    private int _invertValue = -1; 

    private void Awake() => _rb = GetComponent<Rigidbody>();
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _spead * _invertValue, _rb.velocity.y,_joystick.Vertical * _spead * _invertValue);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Run();
        }
        else
        {
            IdleAnimationPlay();
        }
    }

    private void Run()
    {
        if (_towerRoot.CurrenCount > 0 || _moneyTower.CurrentCount > 0)
        {
            _animator.Play(BaseAnimation.Crewling);
            _animator.Play(BaseAnimation.Run);
            transform.rotation = Quaternion.LookRotation( _rb.velocity);
        }
        else
        {
            _animator.Play(BaseAnimation.Run);
            transform.rotation = Quaternion.LookRotation( _rb.velocity);
        }
    }

    private void IdleAnimationPlay()
    {
        if (_towerRoot.CurrenCount == 0)
            _animator.Play("New State");
            
        _animator.Play(BaseAnimation.Idle);
    }
}
