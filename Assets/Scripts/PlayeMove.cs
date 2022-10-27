using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private DynamicJoystick _joistick;
    [SerializeField] private float _spead;
    [SerializeField] private TowerRoot _towerRoot;

    private int _invertValue = -1; 

    private void Awake() => _rb = GetComponent<Rigidbody>();
    
    private void Update()
    {
        _rb.velocity = new Vector3(_joistick.Horizontal * _spead * _invertValue, _rb.velocity.y,_joistick.Vertical * _spead * _invertValue);

        if (_joistick.Horizontal != 0 || _joistick.Vertical != 0)
        {
            if (_towerRoot.CurrenCount > 0)
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
        else
        {
            if (_towerRoot.CurrenCount == 0)
                _animator.Play("New State");
            
            _animator.Play(BaseAnimation.Idle);
        }
    }
}
