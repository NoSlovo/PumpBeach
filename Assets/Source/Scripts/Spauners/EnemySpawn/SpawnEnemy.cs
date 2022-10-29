using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
   [SerializeField] private List<Enemy> _enemyColection;
   public void CreateAndMove(Transform entryPoint)
   {
     var numberEnemy =  Random.Range(0, _enemyColection.Count);
     var enemy = _enemyColection[numberEnemy];
     var createEnemy = Instantiate(enemy);
     createEnemy.MoveToPoint(entryPoint);
   }
}
