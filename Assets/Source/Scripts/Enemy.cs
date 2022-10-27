using System;
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
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,_endPoint.position) < 0.3f)
        {
            StopMove();
        }
    }

    public void MoveToPoint(Transform point,SleepWolk sleepWolk = null)
    {
        _endPoint = point;
        _animator.Play(BaseAnimation.Run);
        _agent.SetDestination(point.position);
    }
    
    
    public void Crawling(Transform point)
    {
        _animator.Play(BaseAnimation.EnemyCrowling);
        transform.DOMove(point.position, 1f);
    }
    
    public void StopMove()
    {
        _agent.enabled = false;
        _animator.Play(BaseAnimation.Idle);
    }

    public void Sit()
    {
        _animator.Play(BaseAnimation.EnemySit);
    }
    
}
