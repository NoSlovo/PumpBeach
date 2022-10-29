using UnityEngine;

public class Tent : SleepingPlace
{
    public override void MoveAnemyPoint(Enemy enemy)
    {
        enemy.Crawling(_endPoint);
        enemy.transform.LookAt(_endPoint);
        StartCoroutine(MoveBack(enemy));
    }
}