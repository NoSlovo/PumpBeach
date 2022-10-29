using UnityEngine;

public class Home : SleepingPlace
{
    public override void MoveAnemyPoint(Enemy enemy)
    {
       enemy.MoveToPoint(_endPoint);
       enemy.transform.LookAt(_endPoint);
    }
}