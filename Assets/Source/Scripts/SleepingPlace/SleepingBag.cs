using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;


public class SleepingBag : SleepingPlace
{

    public override void MoveEnemyPoint(Enemy enemy)
    {
        enemy.Sleep(_endPoint);
        enemy.transform.LookAt(_endPoint.position);
        
        StartCoroutine(Daley(enemy));
    }


    private IEnumerator Daley(Enemy enemy)
    {
        yield return new WaitForSecondsRealtime(3f);
       StartCoroutine(MoveBack(enemy));
    }
    
}