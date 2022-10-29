using UnityEngine;

public class Home : SleepingPlace
{
    public override void MoveEnemyPoint(Enemy enemy)
    {
       enemy.MoveToPoint(_endPoint);
       enemy.transform.LookAt(_endPoint);
    }
}