using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public abstract class SleepingPlace : MonoBehaviour
{
    [SerializeField] protected Bonfire _bonfire;
    [SerializeField] protected Transform _endPoint;
    [SerializeField] protected DeleteTriger _deleteEnemyPoint;
    
    public event Action EnemyExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.ActiveReactionTriger)
            {
                enemy.StopMove();
                MoveEnemyPoint(enemy);
            }
        }
    }
    

    public abstract void MoveEnemyPoint(Enemy enemy);

    protected IEnumerator MoveBack(Enemy enemy)
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(5f);
        yield return waitForSecondsRealtime;
        enemy.MoveToPoint(_bonfire.EntryPosition);
        enemy.transform.DOMove(_bonfire.EntryPosition.position, 2f).OnComplete(() =>
        {
            enemy.MoveToPoint(_deleteEnemyPoint.transform);
            EnemyExit.Invoke();
        });
        enemy.transform.LookAt(_bonfire.EntryPosition.position);
    }
}
