using System;
using DG.Tweening;
using UnityEngine;

public class SleepingBag : MonoBehaviour
{
    [SerializeField] protected Bonfire _bonfire;
    [SerializeField] protected Transform _endPoint;
    [SerializeField] protected DeleteTriger _deleteEnemyPoint;
    public event Action EnemyInside;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.ActiveReactionTriger)
            {
                EnemyInside.Invoke();
                enemy.StopMove();
                MoveEnemy(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }


    private void MoveEnemy(Enemy enemy)
    {
        enemy.transform.DOMove(_endPoint.position, 1f);
    }
}
