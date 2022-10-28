using DG.Tweening;
using UnityEngine;

public class SleepingBag : SleepingPlace
{

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.ActiveReactionTriger)
            {
                MoneySpawn();
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
