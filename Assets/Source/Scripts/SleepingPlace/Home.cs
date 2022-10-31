using DG.Tweening;
using UnityEngine;

public class Home : SleepingPlace
{
    public override void MoveEnemyPoint(Enemy enemy)
    {
        enemy.transform.DOMove(_endPoint.position, 0.5f).OnComplete(() =>
        {
            StartCoroutine(MoveBack(enemy));
        });
       enemy.transform.LookAt(_endPoint);
    }
}