using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

    private Transform _endPoint;
    private bool _activeReactionTriger;

    public bool ActiveReactionTriger => _activeReactionTriger;
    
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_endPoint != null)
        {
            if (Vector3.Distance(transform.position,_endPoint.position) < 1f)
            {
                _activeReactionTriger = true;
            }   
        }
    }

    public void MoveToPoint(Transform point)
    {
        _agent.enabled = true;
        _activeReactionTriger = false;
        _endPoint = point;
        _animator.Play(BaseAnimation.Run);
        _agent.SetDestination(point.position);
    }
    
    
    public void Crawling(Transform point)
    {
        _animator.Play(BaseAnimation.EnemyCrowling);
        transform.DOMove(point.position, 5f);
    }
    
    public void StopMove()
    {
        _agent.enabled = false;
    }

    public void Sit()
    {
        _agent.enabled = false;
        _animator.Play(BaseAnimation.EnemySit);
    }

    public void Sleep(Transform point)
    {
        _animator.Play(BaseAnimation.EnemyCrowling);
        transform.DOMove(point.position, 5f).OnComplete(() =>
        {
            _animator.Play(BaseAnimation.Sleep); 
        });
    }
    
}
