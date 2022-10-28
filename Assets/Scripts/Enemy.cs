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
            if (Vector3.Distance(transform.position,_endPoint.position) < 0.5f)
            {
                _activeReactionTriger = true;
            }   
        }
    }

    public void MoveToPoint(Transform point)
    {
        _activeReactionTriger = false;
        _endPoint = point;
        _animator.Play(BaseAnimation.Run);
        _agent.SetDestination(point.position);
        Debug.Log(point.position);
    }
    
    
    public void Crawling(Transform point)
    {
        _animator.Play(BaseAnimation.EnemyCrowling);
        transform.DOMove(point.position, 5f).OnComplete(() =>
        {
            
        });
    }
    
    public void StopMove()
    {
        _agent.isStopped = true;
    }

    public void Sit()
    {
        _agent.enabled = false;
        _animator.Play(BaseAnimation.EnemySit);
    }
    
}
