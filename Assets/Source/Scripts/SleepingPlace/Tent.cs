using UnityEngine;

public class Tent : SleepingPlace
{
    public override void MoveEnemyPoint(Enemy enemy)
    {
        enemy.CrawlToPoint(_endPoint);
        enemy.transform.LookAt(_endPoint);
        StartCoroutine(MoveBack(enemy));
    }
}