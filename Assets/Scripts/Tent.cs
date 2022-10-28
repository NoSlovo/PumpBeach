using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tent : SleepingPlace
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.ActiveReactionTriger)
            {
                _bonfire.EnableElemenst();
                enemy.StopMove();
                MoveEnemy(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            
        }
    }


    private void MoveEnemy(Enemy enemy)
    {
        enemy.Crawling(_endPoint);
        enemy.transform.LookAt(_endPoint);
        StartCoroutine(MoveBack(enemy));
    }


    private IEnumerator MoveBack(Enemy enemy)
    {
        var waitForSecondsRealtime = new WaitForSecondsRealtime(5f);
        yield return waitForSecondsRealtime;
        enemy.transform.DOMove(_bonfire.EntryPosition.position, 5f).OnComplete(() =>
        {
            enemy.MoveToPoint(_deleteEnemyPoint.transform);
        });
        enemy.transform.LookAt(_bonfire.EntryPosition.position);
    }
}