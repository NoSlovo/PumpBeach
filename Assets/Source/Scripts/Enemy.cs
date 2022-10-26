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
    
    public void MoveToPoint(Transform point)
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
    }

    public void Sit()
    {
        _animator.Play(BaseAnimation.EnemySit);
    }
    
}
