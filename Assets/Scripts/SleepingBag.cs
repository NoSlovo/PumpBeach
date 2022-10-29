using DG.Tweening;


public class SleepingBag : SleepingPlace
{
    public override void MoveAnemyPoint(Enemy enemy)
    {
        enemy.transform.DOMove(_endPoint.position, 1f);
    }
    
}