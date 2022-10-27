using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Home : MonoBehaviour
{
   [SerializeField] private Bonfire _bonfire;
   [SerializeField] private Transform _endPoint;

   private void OnTriggerStay(Collider other)
   {
      if (other.TryGetComponent(out Enemy enemy))
      {
         if (enemy.ActiveReactionTriger)
         {
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
