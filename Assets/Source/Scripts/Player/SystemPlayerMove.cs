using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class SystemPlayerMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _spead;
    [SerializeField] private TowerRoot _towerRoot;
    [SerializeField] private AudioSource _audioSource;

    private int _invertValue = -1;
    private  float _velocite;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _spead * _invertValue, _rb.velocity.y,_joystick.Vertical * _spead * _invertValue);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _velocite += _spead * Time.deltaTime;
            _animator.SetFloat(BaseAnimation._parametrVelosity,_velocite);
            
            if (_towerRoot.CurrenCount > 0)
            {
                _animator.Play(BaseAnimation.Crewling);
                transform.rotation = Quaternion.LookRotation( _rb.velocity);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation( _rb.velocity);
            }
        }
        else
        {
            IdleAnimationPlay();
        }
        
    }
    
    public void SoundStepPlay()
    {
        _audioSource.Play();
    }

    private void Run()
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

    private void IdleAnimationPlay()
    {
        if (_towerRoot.CurrenCount == 0)
            _animator.Play("New State");
            
        _animator.Play(BaseAnimation.Idle);
    }
}
