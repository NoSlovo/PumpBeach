using DG.Tweening;


public class SleepingBag : SleepingPlace
{
    public override void MoveEnemyPoint(Enemy enemy)
    {
        enemy.transform.DOMove(_endPoint.position, 1f);
        enemy.transform.LookAt(_endPoint.position);
        enemy.Sleep();
    }
    
}